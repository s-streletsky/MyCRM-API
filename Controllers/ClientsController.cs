using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCRM_API.Db;
using MyCRM_API.Models;
using MyCRM_API.Models.DTO.Clients;
using MyCRM_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM_API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly IDateTimeProvider dateTimeProvider;

        public ClientsController(DataContext dataContext, IMapper mapper, IDateTimeProvider dateTimeProvider)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.dateTimeProvider = dateTimeProvider;
        }

        [HttpGet]
        public async Task<ActionResult<PageInfo<ClientAllResponse>>> GetAll([FromQuery] int page)
        {
            int pageSize = 5;

            IQueryable<ClientEntity> source = dataContext.Clients;
            var totalPages = PageInfo<Object>.PagesCount(source, pageSize);

            if (page < 1 || page > totalPages)
            {
                return NotFound(new { Message = $"Page {page} does not exist! Total pages: {totalPages}" });
            }
            
            var entities = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var clients = mapper.Map<List<ClientAllResponse>>(entities);

            var pageResponse = new PageInfo<ClientAllResponse>(totalPages, page, clients);

            return Ok(pageResponse);
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<ClientAllResponse>>> GetAllList()
        {
            var entities = await dataContext.Clients.ToListAsync();
            var clients = mapper.Map<IEnumerable<ClientAllResponse>>(entities);

            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientResponse>> Get(int id)
        {
            var entity = await dataContext.Clients.FindAsync(id);

            if (entity == null)
            {
                return NotFound(new { id = id });
            }

            var client = new ClientResponse();
            mapper.Map(entity, client);

            return Ok(client);
        }

        [HttpGet("{id}/profile")]
        public async Task<ActionResult<ClientProfileResponse>> GetProfile(int id)
        {
            var entity = await dataContext.Clients.FindAsync(id);

            if (entity == null) {
                return NotFound(new { id = id });
            }

            var client = new ClientProfileResponse();
            mapper.Map(entity, client);

            client.OrdersQuantity = await dataContext.Orders.Where(o => o.ClientId == id).CountAsync();
            client.PaymentsTotal = await dataContext.Payments.Where(p => p.ClientId == id).SumAsync(p => p.Amount);

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<ClientEntity>> Create([FromBody] ClientRequest client)
        {
            if (!ModelState.IsValid) {
                return BadRequest(client);
            }

            var newClientEntity = new ClientEntity();
            mapper.Map(client, newClientEntity);
            newClientEntity.Date = dateTimeProvider.UtcNow;

            await dataContext.Clients.AddAsync(newClientEntity);
            await dataContext.SaveChangesAsync();

            return Ok(newClientEntity);
        }

        [HttpPut]
        public async Task<ActionResult<ClientEntity>> Edit([FromBody] ClientEditRequest client)
        {
            if (!ModelState.IsValid) {
                return BadRequest(client);
            }

            var entity = await dataContext.Clients.FindAsync(client.Id);

            if (entity == null) {
                return NotFound(new { id = client.Id });
            }

            mapper.Map(client, entity);
            await dataContext.SaveChangesAsync();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            dataContext.Remove(new ClientEntity() { Id = id });
            await dataContext.SaveChangesAsync();

            return Ok(id);
        }
    }
}
