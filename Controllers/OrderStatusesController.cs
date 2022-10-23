using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCRM_API.Db;
using MyCRM_API.Models.DTO.Clients;
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
    public class OrderStatusesController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public OrderStatusesController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<ClientAllResponse>>> GetAllList()
        {
            var entities = await dataContext.OrderStatuses.ToListAsync();
            var orderStatuses = mapper.Map<IEnumerable<OrderStatusEntity>>(entities);

            return Ok(orderStatuses);
        }
    }
}
