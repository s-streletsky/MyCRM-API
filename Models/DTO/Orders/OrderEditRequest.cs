using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM_API.Models.DTO.Orders
{
    public class OrderEditRequest : OrderRequest
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
    }
}
