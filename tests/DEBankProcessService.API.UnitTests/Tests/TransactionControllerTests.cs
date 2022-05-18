using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TransactionProcessingService.API.Controllers;
using TransactionProcessingService.Service.Contracts;
using TransactionProcessingService.Service.Models.Request;
using TransactionProcessingService.Service.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace TransactionProcessingService.API.UnitTests.Tests
{
    [TestFixture]
    public class TransactionControllerTests
    {
          private Mock<IDirectDebitsService> _directDebitServiceMock;
          private Mock<ILogger<TransactionController>> _logger;

          private const string ValidBankName = "ANZ";
          private const string InvalidBankName = "XYZABC";
          private const string ServerError = "Err";
          private const string NoDataFound = "ABC";


        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<TransactionController>>();
            _directDebitServiceMock = new Mock<IDirectDebitsService>();
            _directDebitServiceMock.Setup(x => x.ProcessGenericDirectDebits(ValidBankName, DateTime.Today)).ReturnsAsync(new DirectDebitsResponse());
            _directDebitServiceMock.Setup(x => x.ProcessGenericDirectDebits(InvalidBankName, DateTime.Today));
            _directDebitServiceMock.Setup(x => x.ProcessGenericDirectDebits(NoDataFound, DateTime.Today));
            _directDebitServiceMock.Setup(x => x.ProcessGenericDirectDebits(ServerError, DateTime.Today)).ThrowsAsync(new Exception());
        }

        [Theory]
        [TestCase(ValidBankName, 200)]
        [TestCase(NoDataFound, 404)]
        [TestCase(InvalidBankName, 400)]
        public async Task ProcessGenericDirectDebitsAsync_Test(string input, int expected)
        {
            var request = new DirectDebitsRequest
            {
                BankName = input,
                DateToProcess = DateTime.Today
            };

            var trnCon = new TransactionController(_directDebitServiceMock.Object, _logger.Object);
            MockModelState(request, trnCon);
            var result = (ObjectResult)await trnCon.ProcessGenericDirectDebitsAsync(request);
            Assert.AreEqual(expected, result.StatusCode);
        }

        protected void MockModelState<TModel, TController>(TModel model, TController controller) where TController : ControllerBase
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            foreach(var validationResult in validationResults)
            {
                controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }
        }
      

    }
}
