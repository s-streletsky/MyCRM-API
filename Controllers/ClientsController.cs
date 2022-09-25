using Microsoft.AspNetCore.Mvc;
using MyCRM_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly AppContext appContext;
        public ClientsController(AppContext appContext)
        {
            this.appContext = appContext;
        }

        [HttpGet(Name = "GetAllClients")]
        public IEnumerable<Client> Getall()
        {
            return appContext.Clients.ToList();
        }

        [HttpPost]
        public void Create()
        {
            var client1 = new Client();
            client1.Date = DateTime.UtcNow;
            client1.Name = "Stanislav";
            client1.Phone = "063 777 55 33";
            client1.Email = "st@mail.com";

            var client2 = new Client();
            client2.Date = DateTime.UtcNow;
            client2.Name = "Tatiana";
            client2.Phone = "063 555 33 11";
            client2.Email = "tat@mail.com";

            var client3 = new Client();
            client3.Date = DateTime.UtcNow;
            client3.Name = "Maria";
            client3.Phone = "063 999 77 55";
            client3.Email = "maria@mail.com";

            appContext.Add(client1);
            appContext.Add(client2);
            appContext.Add(client3);
            appContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute]int id)
        {
            appContext.Remove(new Client() { Id = id });
            appContext.SaveChanges();
        }
    }
}
