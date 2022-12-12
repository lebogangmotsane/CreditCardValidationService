using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidationService.Models
{
    public class BadRequestExceptionResponse
    {
        public string StatusCode { get; set; } = "400";
        public bool IsValid { get; set; } = false;
    }
}
