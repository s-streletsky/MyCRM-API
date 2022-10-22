using MyCRM_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM_API.Models.DTO.ExchangeRates
{
    public class ExchangeRateAllResponse
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public CurrencyEntity Currency { get; set; }
        public double Value { get; set; }
    }
}
