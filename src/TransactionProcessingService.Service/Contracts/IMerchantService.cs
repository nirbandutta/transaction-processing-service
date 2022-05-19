using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionProcessingService.Service.Models;

namespace TransactionProcessingService.Service.Contracts
{
    public interface IMerchantService
    {
        public Task<IEnumerable<Merchant>> GetAllMerchants();
    }
}
