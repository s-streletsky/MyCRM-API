using Microsoft.EntityFrameworkCore;
using MyCRM_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM_API
{
    public class AppContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
