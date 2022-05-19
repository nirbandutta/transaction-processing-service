using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransactionProcessingService.DataLayer.Contracts
{
    public interface IAccountListRepository
    {
        public Task<IEnumerable<int>> GetAccountList(bool generateByCompanyId, int statusActive, int runNumber);
    }
}