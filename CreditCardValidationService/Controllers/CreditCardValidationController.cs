using CreditCardValidationService.Contracts;
using CreditCardValidationService.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CreditCardValidationService.Controllers
{
    [ApiController]
    [Route("api/validate")]

    public class CreditCardValidationController : ApiController
    {

        private readonly IValidateCreditCardNumberService _service;
        public CreditCardValidationController(IValidateCreditCardNumberService service)
        {
            _service = service;
        }

        [HttpGet("{cardNumber}")]
        public ActionResult<bool> Validate(string cardNumber, Exception badRequestExceptionResponse)
        {
            try
            {
                var isNumericString = _service.IsCreditCardNumberNumeric(cardNumber);
                if (isNumericString == false)
                {

                    throw badRequestExceptionResponse;
                }
                bool result = _service.ValidateCreditCardNumber(cardNumber);
                return result;

            }
            catch(Exception ex) {
                return false;
            }

        }
            
       } 
}
