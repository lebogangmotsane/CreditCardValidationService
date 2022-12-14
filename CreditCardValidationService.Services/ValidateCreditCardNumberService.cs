using CreditCardValidationService.Contracts;

namespace CreditCardValidationService.Services
{
    public class ValidateCreditCardNumberService : IValidateCreditCardNumberService
    {
        public ValidateCreditCardNumberService() { }

        public bool ValidateCreditCardNumber(string cardNumber)
        {
            var sum = 0;
            var parity = cardNumber.Length % 2;
         
            for (var i = cardNumber.Length - 1; i >= 0; i--)
            {
                var currentDigit = int.Parse(cardNumber[i].ToString());
                if (i % 2 == parity)
                {
                    currentDigit *= 2;
                }                   
                 if(currentDigit > 9)
                {
                    currentDigit -= 9;
                }                    
                sum += currentDigit;
            }
            return sum % 10 == 0;

        }

        public bool IsCreditCardNumberNumeric(string cardNumber)
        {
            bool isCardNumberNumeric = true;

            foreach (char cN in cardNumber)
            {
                if (cN < '0' || cN > '9')
                    isCardNumberNumeric = false;
            }

            return isCardNumberNumeric;
        }

    }
}