using Microsoft.EntityFrameworkCore;
using TransactionProcessingService.DataLayer.Models;

namespace TransactionProcessingService.DataLayer
{
    public class SqlServerAppDbContext :DbContext
    {
        public SqlServerAppDbContext(DbContextOptions <SqlServerAppDbContext> options) : base(options)
        {
        }

        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
