using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionProcessingService.DataLayer.Contracts;
using TransactionProcessingService.DataLayer.Models;

namespace TransactionProcessingService.DataLayer.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly SqlServerAppDbContext _dbContext;
        public MerchantRepository(SqlServerAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddMerchant(Merchant merchant)
        {
            _dbContext.Merchants.Add(merchant);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Merchant> GetMerchantById(int Id)
        {
            return await _dbContext.Merchants.Where(a => a.MerchantId == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Merchant>> GetMerchants()
        {
            return await _dbContext.Merchants.ToListAsync();
        }
    }
}