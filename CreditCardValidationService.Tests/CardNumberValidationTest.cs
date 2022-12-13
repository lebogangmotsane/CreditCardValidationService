using CreditCardValidationService.Contracts;
using CreditCardValidationService.Repository;
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

        [Test]
        public void IsCardNumberValid()
        {
            var result1 = _service.ValidateCreditCardNumber("49927398716");
            Assert.IsTrue(result1, "isValid");           
           
        }


        [Test]
        public void IsCardNumberValidTest2()
        {
            var result2 = _service.ValidateCreditCardNumber("49927398717");
            Assert.IsFalse(result2, "isNotValid");
        }


        [Test]
        public void IsCardNumberValidTest3()
        {
            var result3 = _service.ValidateCreditCardNumber("1234567812345678");
            Assert.IsFalse(result3, "isNotValid");
        }


        [Test]
        public void IsCardNumberValidTest4()
        {
            var result4 = _service.ValidateCreditCardNumber("1234567812345670");
            Assert.That(result4, "isValid");
        }


        [Test]
        public void IsCardNumberValidTest5()
        {
            var result5 = _service.ValidateCreditCardNumber("2222405343248877");
            Assert.That(result5, "isValid");

        }
        [Test]
        public void IsCardNumberValidTest6()
        {
            var result6 = _service.ValidateCreditCardNumber("2222990905257051");
            Assert.IsTrue(result6, "isValid");
        }
    }
    }