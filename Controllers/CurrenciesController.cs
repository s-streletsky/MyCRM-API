using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCRM_API.Db;
using MyCRM_API.Models.Entities;

namespace MyCRM_API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public CurrenciesController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<CurrencyEntity>>> GetAllList()
        {
            var entities = await dataContext.Currencies.ToListAsync();

            return Ok(entities);
        }
    }
}
