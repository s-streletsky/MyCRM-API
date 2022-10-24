using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCRM_API.Db;
using MyCRM_API.Models;
using MyCRM_API.Models.DTO.Clients;
using MyCRM_API.Models.DTO.Orders;
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
    public class OrdersController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly IDateTimeProvider dateTimeProvider;

        public OrdersController(DataContext dataContext, IMapper mapper, IDateTimeProvider dateTimeProvider)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.dateTimeProvider = dateTimeProvider;
        }

        [HttpGet]
        public async Task<ActionResult<PageInfo<OrderResponse>>> GetAll([FromQuery] int page)
        {
            int pageSize = 5;

            IQueryable<OrderEntity> source = dataContext.Orders;
            var totalPages = PageInfo<Object>.PagesCount(source, pageSize);

            if (page < 1 || page > totalPages)
            {
                return NotFound(new { Message = $"Page {page} does not exist! Total pages: {totalPages}" });
            }

            var entities = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var orders = mapper.Map<List<OrderResponse>>(entities);

            var pageResponse = new PageInfo<OrderResponse>(totalPages, page, orders);

            return Ok(pageResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderFullResponse>> Get(int id)
        {
            var entity = await dataContext.Orders.FindAsync(id);

            if (entity == null) {
                return NotFound(new { id = id });
            }

            var order = new OrderFullResponse();
            mapper.Map(entity, order);

            order.Items = await dataContext.OrdersItems.Where(i => i.OrderId == id).ToListAsync();
            order.Total = (float)await dataContext.OrdersItems.Where(i => i.OrderId == id).SumAsync(i => i.Total);
            order.PaymentsTotal = await dataContext.Payments.Where(p => p.OrderId == id).SumAsync(p => p.Amount);
            order.Debt = order.Total - order.PaymentsTotal;

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderEntity>> Create([FromBody] OrderRequest order)
        {
            if (!ModelState.IsValid) {
                return BadRequest(order);
            }

            var newOrder = new OrderEntity();
            mapper.Map(order, newOrder);
            newOrder.Date = dateTimeProvider.UtcNow;
            newOrder.StatusId = 4; 

            await dataContext.Orders.AddAsync(newOrder);
            await dataContext.SaveChangesAsync();

            return Ok(newOrder);
        }

        [HttpPut]
        public async Task<ActionResult<OrderEntity>> Edit([FromBody] OrderEditRequest order)
        {
            if (!ModelState.IsValid) {
                return BadRequest(order);
            }

            var entity = await dataContext.Orders.FindAsync(order.Id);

            if (entity == null) {
                return NotFound(new { id = order.Id });
            }

            mapper.Map(order, entity);
            await dataContext.SaveChangesAsync();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            dataContext.Remove(new OrderEntity() { Id = id });
            await dataContext.SaveChangesAsync();

            return Ok(id);
        }
    }
}
