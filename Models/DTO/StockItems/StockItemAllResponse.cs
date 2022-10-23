using MyCRM_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM_API.Models.DTO.StockItems
{
    public class StockItemAllResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ManufacturerEntity Manufacturer { get; set; }
        public CurrencyEntity Currency { get; set; }
        public double PurchasePrice { get; set; }
        public double RetailPrice { get; set; }
        public double Quantity { get; set; }
    }
}
