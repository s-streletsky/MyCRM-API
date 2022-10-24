using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM_API.Models.DTO.OrdersItems
{
    public class OrderItemRequest
    {
        public int OrderId { get; set; }
        public int StockItemId { get; set; }
        public float Quantity { get; set; }
        public float Discount { get; set; }
    }
}
