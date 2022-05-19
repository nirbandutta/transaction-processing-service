using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TransactionProcessingService.DataLayer.Contracts;
using TransactionProcessingService.DataLayer.Enums;
using TransactionProcessingService.DataLayer.Models;

namespace TransactionProcessingService.DataLayer.Repositories
{
    public class GenericDirectDebitRepository : IGenericDirectDebitRepository
    {
        private readonly IDbConnection _dbConnection;

        public GenericDirectDebitRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<DirectEntryAccount> GetAccountDetails(int accountId, string bank, DirectEntryType accountType)
        {
            var sb = new StringBuilder();
            sb.AppendLine(
                "EXEC IPPUtilities.dbo.pr_SupportApp_GetDirectEntryDetails  @AccountID = @pa1, @BankName=@pa2 , @directentrytype = @pa3");

            var parameters = new DynamicParameters();
            parameters.Add("@pa1", accountId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@pa2", bank, DbType.String, ParameterDirection.Input);
            parameters.Add("@pa3", accountType, DbType.Int32, ParameterDirection.Input);

            return await _dbConnection.QuerySingleAsync<DirectEntryAccount>(sb.ToString(), parameters);
        }

        public async Task<List<DirectEntryTransaction>> GetDirectDebitTransactionListing(long accountId, long companyId,
            DateTime dateToProcess, string settlementTime)
        {
            var sb = new StringBuilder();
            sb.AppendLine(
                "EXEC IPPUtilities.dbo.pr_SupportApp_GetDirectDebitTransactions  @CompanyID = @pa1, @AccountID=@pa2 , @SettlementDateStart = @pa3, @CutOff = @pa4");

            var parameters = new DynamicParameters();
            parameters.Add("@pa1", companyId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@pa2", accountId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@pa3", dateToProcess, DbType.Date, ParameterDirection.Input);
            if (string.IsNullOrEmpty(settlementTime))
                parameters.Add("@pa4", dateToProcess + " " + settlementTime, DbType.DateTime, ParameterDirection.Input);

            var results = await _dbConnection.QueryAsync<DirectEntryTransaction>(sb.ToString(), parameters);
            return results.ToList();
        }

        public async Task UpdateSettlementDate(DateTime dateToProcess, long trnId, long accountId, string receipt,
            long amount)
        {
            //var processingDate = DateTime.Parse(dateToProcess);
            var sqlStatement = @"UPDATE IPP_TRN.dbo.TRNDATACORE SET SETTLEMENTDATE = @processingDate
                WHERE TRNID = @trnID AND ACCOUNTID = @accountID AND RTRIM(RECEIPT) = @receipt AND AMOUNT = @amount";

            var parameters = new DynamicParameters();
            parameters.Add("@processingDate", dateToProcess, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@trnID", trnId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@accountID", accountId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@receipt", receipt, DbType.String, ParameterDirection.Input);
            parameters.Add("@amount", amount, DbType.Int64, ParameterDirection.Input);

            await _dbConnection.ExecuteAsync(sqlStatement, parameters);
        }
    }
}