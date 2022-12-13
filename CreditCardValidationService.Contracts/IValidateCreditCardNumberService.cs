using CreditCardValidationService.Models;

namespace CreditCardValidationService.Contracts
{
    public interface IValidateCreditCardNumberService
    {
        bool ValidateCreditCardNumber(string cardNumber);
        bool IsCreditCardNumberNumeric(string cardNumber);
    }
}