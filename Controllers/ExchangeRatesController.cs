using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCRM_API.Db;
using MyCRM_API.Models;
using MyCRM_API.Models.DTO.Clients;
using MyCRM_API.Models.DTO.ExchangeRates;
using MyCRM_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM_API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly IDateTimeProvider dateTimeProvider;

        public ExchangeRatesController(DataContext dataContext, IMapper mapper, IDateTimeProvider dateTimeProvider)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.dateTimeProvider = dateTimeProvider;
        }

        [HttpGet]
        public async Task<ActionResult<PageInfo<ExchangeRateAllResponse>>> GetAll([FromQuery] int page)
        {
            int pageSize = 5;

            IQueryable<ExchangeRateEntity> source = dataContext.ExchangeRates;
            var totalPages = PageInfo<Object>.PagesCount(source, pageSize);

            if (page < 1 || page > totalPages)
            {
                return NotFound(new { Message = $"Page {page} does not exist! Total pages: {totalPages}" });
            }

            var entities = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var exchangeRates = mapper.Map<List<ExchangeRateAllResponse>>(entities);

            var pageResponse = new PageInfo<ExchangeRateAllResponse>(totalPages, page, exchangeRates);

            return Ok(pageResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExchangeRateResponse>> Get(int id)
        {
            var entity = await dataContext.ExchangeRates.FindAsync(id);

            if (entity == null) {
                return NotFound(new { id = id });
            }

            var exchangeRate = new ExchangeRateResponse();
            mapper.Map(entity, exchangeRate);

            return Ok(exchangeRate);
        }

        [HttpPost]
        public async Task<ActionResult<ExchangeRateEntity>> Create([FromBody] ExchangeRateRequest exchangeRate)
        {
            if (!ModelState.IsValid) {
                return BadRequest(exchangeRate);
            }

            var newExchangeRateEntity = new ExchangeRateEntity();
            mapper.Map(exchangeRate, newExchangeRateEntity);
            newExchangeRateEntity.Date = dateTimeProvider.UtcNow;

            await dataContext.ExchangeRates.AddAsync(newExchangeRateEntity);
            await dataContext.SaveChangesAsync();

            return Ok(newExchangeRateEntity);
        }

        [HttpPut]
        public async Task<ActionResult<ExchangeRateEntity>> Edit([FromBody] ExchangeRateEditRequest exchangeRate)
        {
            if (!ModelState.IsValid) {
                return BadRequest(exchangeRate);
            }

            var entity = await dataContext.ExchangeRates.FindAsync(exchangeRate.Id);

            if (entity == null) {
                return NotFound(new { id = exchangeRate.Id });
            }

            mapper.Map(exchangeRate, entity);
            await dataContext.SaveChangesAsync();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            dataContext.Remove(new ExchangeRateEntity() { Id = id });
            await dataContext.SaveChangesAsync();

            return Ok(id);
        }
    }
}
