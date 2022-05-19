using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using TransactionProcessingService.DataLayer.Contracts;

namespace TransactionProcessingService.DataLayer.Repositories
{

    public class AccountListRepository : IAccountListRepository
    {
        private readonly IDbConnection _dbConnection;

        public AccountListRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<int>> GetAccountList(bool generateByCompanyId, int statusActive, int runNumber)
        {
            var sqlStatement =
                @"select td.AccountId from ipputilities.dbo.tbDirectDebitaccounts td inner join ipp_crm.dbo.Accounts on Accounts.AccountId = td.AccountId where td.GenerateByCompanyID = @companyId And td.StatusId = @statusId And Accounts.StatusId = @statusId and td.RunNumber = @runNumber";

            var parameters = new DynamicParameters();
            parameters.Add("@companyId", generateByCompanyId, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@statusId", statusActive, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@runNumber", runNumber, DbType.Int32, ParameterDirection.Input);

            return await _dbConnection.QueryAsync<int>(sqlStatement, parameters);
        }
    }
}