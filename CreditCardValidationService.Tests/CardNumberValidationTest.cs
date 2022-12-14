using CreditCardValidationService.Contracts;
using CreditCardValidationService.Services;
using NUnit.Framework;

namespace CreditCardValidationService.Tests
{
    [TestFixture]
    public class CardNumberValidationTest
    {
        private ValidateCreditCardNumberService _service;

        [SetUp]
        public void Setup()
        {
            _service = new ValidateCreditCardNumberService();
        }

        [TestCase]
        public void IsCardNumberValid()
        {
            var result1 = _service.ValidateCreditCardNumber("49927398716");
            Assert.That(result1, Is.True, "isValid");           
           
        }


        [TestCase]
        public void IsCardNumberValidTest2()
        {
            var result2 = _service.ValidateCreditCardNumber("49927398717");
            Assert.That(result2, Is.False, "isNotValid");
        }


        [TestCase]
        public void IsCardNumberValidTest3()
        {
            var result3 = _service.ValidateCreditCardNumber("1234567812345678");
            Assert.That(result3, Is.False, "isNotValid");
        }


        [TestCase]
        public void IsCardNumberValidTest4()
        {
            var result4 = _service.ValidateCreditCardNumber("1234567812345670");
            Assert.That(result4, Is.True, "isValid");
        }


        [TestCase]
        public void IsCardNumberValidTest5()
        {
            var result5 = _service.ValidateCreditCardNumber("2222405343248877");
            Assert.That(result5, Is.True, "isValid");

        }
        [TestCase]
        public void IsCardNumberValidTest6()
        {
            var result6 = _service.ValidateCreditCardNumber("2222990905257051");
            Assert.That(result6, Is.True, "isValid");
        }
    }
    }