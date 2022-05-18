using System;
using System.Threading.Tasks;
using AutoMapper;
using TransactionProcessingService.DataLayer.Contracts;
using TransactionProcessingService.DataLayer.Enums;
using TransactionProcessingService.Service.Contracts;
using TransactionProcessingService.Service.Enums;
using TransactionProcessingService.Service.Models.Response;
using Microsoft.Extensions.Logging;

namespace TransactionProcessingService.Service.Services
{
    public class DirectDebitsService : IDirectDebitsService
    {
        private readonly ICommonService _commonSvc;
        private readonly IGenericDirectDebitRepository _bankAccountRepository;
        private readonly IAccountListRepository _accountListRepository;
        private readonly IProcessDateRepository _processDateRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DirectDebitsService> _logger;
        private DayType _typeOfDay = DayType.BUSINESSDAY;

        public DirectDebitsService(IGenericDirectDebitRepository bankAccountRepository,
            IAccountListRepository accountListRepository, IProcessDateRepository processDateRepository, IMapper mapper,
            ILogger<DirectDebitsService> logger, ICommonService commonSvc)
        {
            _bankAccountRepository = bankAccountRepository;
            _accountListRepository = accountListRepository;
            _processDateRepository = processDateRepository;
            _mapper = mapper;
            _logger = logger;
            _commonSvc = commonSvc;
        }
        public async Task<DirectDebitsResponse> ProcessGenericDirectDebits(string bankName, DateTime dateToProcess)
        {
            const bool generateByCompanyId = false;
            const int statusActive = 1;
            const int runNumber = 3;
            _logger.LogInformation("Start of service method ProcessGenericDirectDebits.....");
            
            var checkPublicHoliday = await _processDateRepository.IsPublicHoliday(dateToProcess);
            if (checkPublicHoliday)
            {
                _typeOfDay = DayType.PUBLICHOLIDAY;
            }

            var accountList = await _accountListRepository.GetAccountList(generateByCompanyId, statusActive, runNumber);          
            var directDebitResponse = new DirectDebitsResponse();
            var getNextBusinessDay = await _commonSvc.GetNextBusinessDay(dateToProcess);            
            foreach (var accountId in accountList)
            {
                var accountDetails = await _bankAccountRepository.GetAccountDetails(accountId, bankName, DirectEntryType.DIRECTDEBIT);

                if (accountDetails != null)
                {
                    if (_typeOfDay == DayType.PUBLICHOLIDAY)
                    {                
                        _logger.LogInformation($"Next business Day to be processed is.....: {getNextBusinessDay}");
                        var transactionDetails = await _bankAccountRepository.GetDirectDebitTransactionListing(accountDetails.AccountID, accountDetails.CompanyID, getNextBusinessDay, accountDetails.SettlementTime);
                        accountDetails.DirectEntryTransactions = transactionDetails;

                        foreach (var detail in transactionDetails)
                        {
                            await _bankAccountRepository.UpdateSettlementDate(getNextBusinessDay, detail.TrnID, detail.AccountID, detail.Receipt, detail.Amount);
                        }
                    }
                    else
                    {
                        accountDetails.DirectEntryTransactions = await _bankAccountRepository.GetDirectDebitTransactionListing(accountDetails.AccountID, accountDetails.CompanyID, dateToProcess);
                    }

                    directDebitResponse.DirectEntryAccounts.Add(_mapper.Map<DirectEntryAccountModel>(accountDetails));
                }
            }

            return directDebitResponse;
        }
    }
}
