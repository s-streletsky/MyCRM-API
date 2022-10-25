using MyCRM_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM_API.Models.DTO.OrdersItems
{
    public class AllOrderItemsDto
    {
        public int Id { get; set; }
        public StockItemEntity StockItem { get; set; }
        public OrderEntity Order { get; set; }
        public float Quantity { get; set; }
    }
}
