using CreditCardValidationService.Contracts;
using CreditCardValidationService.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
//using System.Web.Http;

namespace CreditCardValidationService.Controllers
{
    [ApiVersionNeutral]
    [ApiController]
    [Route("api/validate")]

    public class CreditCardValidationController : Controller
    {

        private readonly IValidateCreditCardNumberService _service;
        public CreditCardValidationController(IValidateCreditCardNumberService service)
        {
            _service = service;
        }

        [HttpGet, Route("{cardNumber}")]
        public IActionResult Validate(string cardNumber)
        {
            try
            {
                var isNumericString =  _service.IsCreditCardNumberNumeric(cardNumber);
                if (!isNumericString == false)
                {
                    bool ValidatedResult = _service.ValidateCreditCardNumber(cardNumber);

                    ValidationResponse response = new ValidationResponse
                    {
                        IsValid = ValidatedResult
                    };

                    return Ok(response);
                }
                else
                {
                    BadRequestExceptionResponse badRequest = new BadRequestExceptionResponse
                    {
                        Error = "Credit card number must be numeric"
                    };
                    return BadRequest(badRequest);
                } 

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            finally
            {
                Console.Write("Re-try with a different number.");
            }

        }
            
       } 
}
