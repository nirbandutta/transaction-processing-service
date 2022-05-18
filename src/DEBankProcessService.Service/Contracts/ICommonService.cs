using System;
using System.Threading.Tasks;

namespace TransactionProcessingService.Service.Contracts
{
    public interface ICommonService
    {
        Task<DateTime> GetNextBusinessDay(DateTime sDate);
        Task<bool> IsWeekendOrPublicHoliday(DateTime sDate);
    }
}