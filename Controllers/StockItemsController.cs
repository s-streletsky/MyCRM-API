using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCRM_API.Db;
using MyCRM_API.Models;
using MyCRM_API.Models.DTO.Manufacturers;
using MyCRM_API.Models.DTO.StockItems;
using MyCRM_API.Models.Entities;

namespace MyCRM_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StockItemsController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public StockItemsController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PageInfo<StockItemAllResponse>>> GetAll([FromQuery] int page)
        {
            int pageSize = 5;

            IQueryable<StockItemEntity> source = dataContext.StockItems;
            var totalPages = PageInfo<Object>.PagesCount(source, pageSize);

            if (page < 1 || page > totalPages) {
                return NotFound(new { Message = $"Page {page} does not exist! Total pages: {totalPages}" });
            }

            var entities = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var stockItems = mapper.Map<List<StockItemAllResponse>>(entities);

            var pageResponse = new PageInfo<StockItemAllResponse>(totalPages, page, stockItems);

            return Ok(pageResponse);
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<ManufacturerResponse>>> GetAllList()
        {
            var entities = await dataContext.StockItems.ToListAsync();

            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockItemResponse>> Get(int id)
        {
            var entity = await dataContext.StockItems.FindAsync(id);

            if (entity == null) {
                return NotFound(new { id = id });
            }

            var stockItem = new StockItemResponse();
            mapper.Map(entity, stockItem);

            return Ok(stockItem);
        }

        [HttpPost]
        public async Task<ActionResult<StockItemEntity>> Create([FromBody] StockItemRequest stockItem)
        {
            if (!ModelState.IsValid) {
                return BadRequest(stockItem);
            }

            var newStockItemEntity = new StockItemEntity();
            mapper.Map(stockItem, newStockItemEntity);

            await dataContext.StockItems.AddAsync(newStockItemEntity);
            await dataContext.SaveChangesAsync();

            return Ok(newStockItemEntity);
        }

        [HttpPut]
        public async Task<ActionResult<StockItemResponse>> Edit([FromBody] StockItemResponse stockItem)
        {
            if (!ModelState.IsValid) {
                return BadRequest(stockItem);
            }

            var entity = await dataContext.StockItems.FindAsync(stockItem.Id);

            if (entity == null) {
                return NotFound(new { id = stockItem.Id });
            }

            mapper.Map(stockItem, entity);
            await dataContext.SaveChangesAsync();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            dataContext.Remove(new StockItemEntity() { Id = id });
            await dataContext.SaveChangesAsync();

            return Ok(id);
        }
    }
}
