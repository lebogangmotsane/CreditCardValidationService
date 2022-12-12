using CreditCardValidationService.Contracts;

namespace CreditCardValidationService.Repository
{
    public class ValidateCreditCardNumberService : IValidateCreditCardNumberService
    {
        public ValidateCreditCardNumberService() { }


       public bool ValidateCreditCardNumber(string cardNumber)
        {
            int sum = cardNumber.Where((currentDigit) => currentDigit >= '0' && currentDigit <= '9')
                .Reverse()  //loop backwards through digits of the card
                .Select((currentDigit, i) => (
                currentDigit - 48) * (i % 2 == 0 ? 1 : 2))
                .Sum((currentDigit) => currentDigit / 10 + currentDigit % 10); //

            return sum % 10 == 0;

        }

        public bool IsCreditCardNumberNumeric(string cardNumber)
        {
            foreach (char cN in cardNumber)
            {
                if (cN < '0' || cN > '9')
                    return false;
            }

            return true;

        }

    }
}