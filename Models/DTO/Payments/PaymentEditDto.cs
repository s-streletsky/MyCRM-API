using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM_API.Models.DTO.Payments
{
    public class PaymentEditDto : PaymentCreateDto
    {
        public int Id { get; set; }
    }
}
