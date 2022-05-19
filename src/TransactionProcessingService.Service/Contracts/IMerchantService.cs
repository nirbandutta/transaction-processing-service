using System.Threading.Tasks;
using TransactionProcessingService.Service.Models;
using TransactionProcessingService.Service.Models.Response;

namespace TransactionProcessingService.Service.Contracts
{
    public interface IMerchantService
    {
        public Task<GetAllMerchantsResponse> GetAllMerchants();

        public Task<Merchant> GetMerchantById(int id);

        public Task<bool> AddMerchant(Merchant merchant);
    }
}
