using System;
using System.Collections.Generic;
using AutoMapper;
using TransactionProcessingService.DataLayer.Contracts;
using TransactionProcessingService.DataLayer.Enums;
using TransactionProcessingService.DataLayer.Models;
using TransactionProcessingService.Service.Contracts;
using TransactionProcessingService.Service.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace TransactionProcessingService.Service.UnitTests.Tests
{
    [TestFixture]
    public class DirectDebitsServiceTests
    {
        private Mock<ICommonService> _commonSvc;
        private Mock<IGenericDirectDebitRepository> _bankAccountRepository;
        private Mock<IAccountListRepository> _accountListRepository;
        private Mock<IProcessDateRepository> _processDateRepository;
        private Mock<IMapper> _mapper;
        private Mock<ILogger<DirectDebitsService>> _logger;
        private const string _publicHolidayDate = "2021-12-25";
        private const string _publicHolidayDateForNullTransaction = "2021-10-04";
        private const string _businessDate = "2021-10-07";
        private readonly DateTime _getNextToHolidayDate = DateTime.Parse("2021-12-27");
        private readonly DateTime _getNextToHolidayDateForNullTransaction = DateTime.Parse("2021-10-05");
        private readonly IEnumerable<int> _accountList = new List<int>() { 1 };
        private readonly DirectEntryAccount _accountDetails = new DirectEntryAccount
        {
            AccountID = 23,
            CompanyID = 1234,
            GenerateByCompanyID = false,
            IsBankInfoFromTrn = true,
            IsAccountLevelCredit = true,
            IsDisbursementLink = false,
            IsAdhoc = true,
            TrnTypesIncluded = "yes"
        };
        private readonly DirectEntryTransaction _tranDetails = new DirectEntryTransaction
        {
            AccountID = 23,
            CompanyID = 1234,
            CleanSpecialCharsOnAccTitle = false,
            TemplateTypeID = 12,
            TrnID = 98765,
            CustomerID = 45678,
            Amount = 56,
            CustRef = "CUST-123",
            Receipt = "REC-123"

        };


        [SetUp]
        public void Init()
        {
            _commonSvc = new Mock<ICommonService>();
            _bankAccountRepository = new Mock<IGenericDirectDebitRepository>();
            _accountListRepository = new Mock<IAccountListRepository>();
            _processDateRepository = new Mock<IProcessDateRepository>();
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILogger<DirectDebitsService>>();

            _processDateRepository.Setup(x => x.IsPublicHoliday(DateTime.Parse(_publicHolidayDate))).ReturnsAsync(true);
            _processDateRepository.Setup(x => x.IsPublicHoliday(DateTime.Parse(_businessDate))).ReturnsAsync(false);
            _processDateRepository.Setup(x => x.IsPublicHoliday(DateTime.Parse(_publicHolidayDateForNullTransaction))).ReturnsAsync(true);
            _commonSvc.Setup(x => x.GetNextBusinessDay(DateTime.Parse(_publicHolidayDate))).ReturnsAsync(_getNextToHolidayDate);
            _commonSvc.Setup(x => x.GetNextBusinessDay(DateTime.Parse(_publicHolidayDateForNullTransaction))).ReturnsAsync(_getNextToHolidayDateForNullTransaction);
            _accountListRepository.Setup(x => x.GetAccountList(false, 1, 3)).ReturnsAsync(_accountList);
            _bankAccountRepository.Setup(x => x.GetAccountDetails(1, "NAB", DirectEntryType.DIRECTDEBIT)).ReturnsAsync(_accountDetails);
            _bankAccountRepository.Setup(x => x.GetDirectDebitTransactionListing(_accountDetails.AccountID, _accountDetails.CompanyID, _getNextToHolidayDate, null)).ReturnsAsync(new List<DirectEntryTransaction>() { _tranDetails });
            _bankAccountRepository.Setup(x => x.GetDirectDebitTransactionListing(_accountDetails.AccountID, _accountDetails.CompanyID, DateTime.Parse(_businessDate), null)).ReturnsAsync(new List<DirectEntryTransaction>());
            _bankAccountRepository.Setup(x => x.UpdateSettlementDate(_getNextToHolidayDate, 12345, 1, "Receipt-1", 560));
        }


        [Theory]
        [TestCase(_businessDate, "RanToCompletion")]
        [TestCase(_publicHolidayDate, "RanToCompletion")]
        [TestCase(_publicHolidayDateForNullTransaction, "Faulted")]
        public void ProcessGenericDirectDebits_Test(string input, string expectedResult)
        {
            var sDate = DateTime.Parse(input);
            var svc = new DirectDebitsService(_bankAccountRepository.Object, _accountListRepository.Object, _processDateRepository.Object, _mapper.Object, _logger.Object, _commonSvc.Object);
            var result = svc.ProcessGenericDirectDebits("NAB", sDate);
            Assert.AreEqual(expectedResult, result.Status.ToString());
        }
    }
}
