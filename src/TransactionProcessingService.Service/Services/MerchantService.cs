using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionProcessingService.DataLayer.Contracts;
using TransactionProcessingService.Service.Contracts;
using TransactionProcessingService.Service.Models;

namespace TransactionProcessingService.Service.Services
{
    public class MerchantService : IMerchantService
    {
        private readonly IMerchantRepository _merchantRepository;
        public MerchantService(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        public async Task<IEnumerable<Merchant>> GetAllMerchants()
        {
            var merchants = await _merchantRepository.GetMerchants();

            return new List<Merchant>();
        }

    }
}
