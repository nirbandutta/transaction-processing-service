using System;
using System.Threading.Tasks;

namespace TransactionProcessingService.DataLayer.Contracts
{
    public interface IProcessDateRepository
    {
        public Task<bool> IsPublicHoliday(DateTime sDate);
    }
}