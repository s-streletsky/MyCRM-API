using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM_API.Models.Entities
{
    public class CountryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
