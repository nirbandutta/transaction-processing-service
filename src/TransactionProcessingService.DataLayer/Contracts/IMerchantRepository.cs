using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionProcessingService.DataLayer.Models;

namespace TransactionProcessingService.DataLayer.Contracts
{
    public interface IMerchantRepository
    {
        public Task<IEnumerable<Merchant>> GetMerchants();

        public Task<Merchant> GetMerchantById(int Id);

        public Task<bool> AddMerchant(Merchant merchant);


    }
}
