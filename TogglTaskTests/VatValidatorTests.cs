using System;
using System.Collections.Generic;
using System.Web.Services.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TogglTask;

namespace TogglTaskTests
{
    [TestClass]
    public class VatValidatorTests
    {
        [TestMethod]
        public void VatValidator_Should_Return_True_When_Vat_Is_Correct()
        {
            var vatList = new List<string>()
            {
                "CZ28987373",
                "DE296459264",
                "DE292188391",
                "NL802465602B01",
                "NL151412984B01",
                "PL9492191021",
                "CZ64610748",
                "IT06700351213"
            };
            foreach (var vatNumber in vatList)
            {
                VatValidator_Check_Validate_Result(vatNumber, true);
            }
        } 

        [TestMethod]
        public void VatValidator_Should_Return_False_When_Vat_Is_InCorrect()
        {
            var vatList = new List<string>()
            {
                string.Empty,
                "123456",
                "CZ",
                "SE556900620701",
                "GB163980581",
            };
            foreach (var vatNumber in vatList)
            {
                VatValidator_Check_Validate_Result(vatNumber, false);
            }
        }
  
        [TestMethod]
        public void VatValidator_Should_Throw_Exception_When_Input_Is_Incorrect()
        {
            var vatList = new List<string>()
            {
                "UK999999",
                "XX123",
            };
            foreach (var vatNumber in vatList)
            {
                try
                {
                    VatValidator_Check_Validate_Result(vatNumber);
                }
                catch (SoapException)
                {
                    Assert.IsTrue(true);
                }
            }
        }

        private void VatValidator_Check_Validate_Result(string vatNumber, bool expectedResult)
        {
            var vatValidator = new VatValidator();

            var result = vatValidator.Validate(vatNumber);

            Assert.AreEqual(result, expectedResult);
        }

        private void VatValidator_Check_Validate_Result(string vatNumber)
        {
            var vatValidator = new VatValidator();

            vatValidator.Validate(vatNumber);

            Assert.Fail("No exception");
        }
    }
}
