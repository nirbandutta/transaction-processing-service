using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TransactionProcessingService.DataLayer.Contracts;

namespace TransactionProcessingService.DataLayer.Repositories
{
    public class ProcessDateRepository : IProcessDateRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProcessDateRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> IsPublicHoliday(DateTime sDate)
        {
            var sqlStatement = @"SELECT HolidayDate FROM ipp_trn.dbo.PublicHolidays WHERE HolidayDate = @sDate";
            var parameters = new DynamicParameters();
            parameters.Add("@sDate", sDate, DbType.Date, ParameterDirection.Input);

            var result = await _dbConnection.QueryAsync(sqlStatement, parameters);
            return result.Any();
        }
    }
}