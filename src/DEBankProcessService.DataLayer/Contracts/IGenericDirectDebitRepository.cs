using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionProcessingService.DataLayer.Enums;
using TransactionProcessingService.DataLayer.Models;

namespace TransactionProcessingService.DataLayer.Contracts
{
    public interface IGenericDirectDebitRepository
    {
        public Task<DirectEntryAccount> GetAccountDetails(int accountId, string bank, DirectEntryType accountType);

        public Task<List<DirectEntryTransaction>> GetDirectDebitTransactionListing(long accountId, long companyId,
            DateTime dateToProcess, string settlementTime = null);

        public Task UpdateSettlementDate(DateTime dateToProcess, long trnId, long accountId, string receipt,
            long amount);
    }
}