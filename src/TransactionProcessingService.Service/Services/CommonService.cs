using System;
using System.Threading.Tasks;
using TransactionProcessingService.DataLayer.Contracts;
using TransactionProcessingService.Service.Contracts;

namespace TransactionProcessingService.Service.Services
{
    public class CommonService : ICommonService
    {
        private readonly IProcessDateRepository _processDateRepository;

        public CommonService(IProcessDateRepository processDateRepository)
        {
            _processDateRepository = processDateRepository;
        }

        public async Task<DateTime> GetNextBusinessDay(DateTime sDate)
        {           
            var dtVal = sDate.AddDays(1);

            while (await IsWeekendOrPublicHoliday(dtVal))
            {
                dtVal =  dtVal.AddDays(1);
            }

            return dtVal;
        }

        public async Task<bool> IsWeekendOrPublicHoliday(DateTime sDate)
        {            
            if ((int)(sDate.DayOfWeek) == 6 || (int)(sDate.DayOfWeek) == 0)
            {
                // Saturday or Sunday
                return true;
            }
            return await _processDateRepository.IsPublicHoliday(sDate);
        }
    }
}
