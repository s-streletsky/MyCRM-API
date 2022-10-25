using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCRM_API.Db;
using MyCRM_API.Models;
using MyCRM_API.Models.DTO.StockArrivals;
using MyCRM_API.Models.Entities;

namespace MyCRM_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StockArrivalsController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly IDateTimeProvider dateTimeProvider;

        public StockArrivalsController(DataContext dataContext, IMapper mapper, IDateTimeProvider dateTimeProvider)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.dateTimeProvider = dateTimeProvider;
        }

        [HttpGet]
        public async Task<ActionResult<PageInfo<StockArrivalAllResponse>>> GetAll([FromQuery] int page)
        {
            int pageSize = 5;

            IQueryable<StockArrivalEntity> source = dataContext.StockArrivals;
            var totalPages = PageInfo<Object>.PagesCount(source, pageSize);

            if (page < 1 || page > totalPages)
            {
                return NotFound(new { Message = $"Page {page} does not exist! Total pages: {totalPages}" });
            }

            var entities = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var stockArrivals = mapper.Map<List<StockArrivalAllResponse>>(entities);

            var pageResponse = new PageInfo<StockArrivalAllResponse>(totalPages, page, stockArrivals);

            return Ok(pageResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockArrivalResponse>> Get(int id)
        {
            var entity = await dataContext.StockArrivals.FindAsync(id);

            if (entity == null) {
                return NotFound(new { id = id });
            }

            var stockArrival = new StockArrivalResponse();
            mapper.Map(entity, stockArrival);

            return Ok(stockArrival);
        }

        [HttpPost]
        public async Task<ActionResult<StockArrivalEntity>> Create([FromBody] StockArrivalRequest stockArrival)
        {
            if (!ModelState.IsValid) {
                return BadRequest(stockArrival);
            }

            var newStockArrivalEntity = new StockArrivalEntity();
            mapper.Map(stockArrival, newStockArrivalEntity);
            newStockArrivalEntity.Date = dateTimeProvider.UtcNow;

            await dataContext.StockArrivals.AddAsync(newStockArrivalEntity);
            await dataContext.SaveChangesAsync();

            return Ok(newStockArrivalEntity);
        }

        [HttpPut]
        public async Task<ActionResult<StockArrivalEntity>> Edit([FromBody] StockArrivalResponse stockArrival)
        {
            if (!ModelState.IsValid) {
                return BadRequest(stockArrival);
            }

            var entity = await dataContext.StockArrivals.FindAsync(stockArrival.Id);

            if (entity == null) {
                return NotFound(new { id = stockArrival.Id });
            }

            mapper.Map(stockArrival, entity);
            await dataContext.SaveChangesAsync();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            dataContext.Remove(new StockArrivalEntity() { Id = id });
            await dataContext.SaveChangesAsync();

            return Ok(id);
        }
    }
}
