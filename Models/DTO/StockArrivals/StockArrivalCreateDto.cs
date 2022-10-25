using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM_API.Models.DTO.StockArrivals
{
    public class StockArrivalCreateDto
    {
        public int StockItemId { get; set; }
        public float Quantity { get; set; }
    }
}
