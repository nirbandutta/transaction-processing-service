using System.Data;
using TransactionProcessingService.DataLayer.Contracts;
using TransactionProcessingService.DataLayer.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace TransactionProcessingService.DataLayer.Extensions
{
    public static class DataLayerDiConfig
    {
        public static void AddDataAccessServices(this IServiceCollection services, string crmConnectionString,
            string trnConnectionString)
        {
            services.AddTransient<IDbConnection>(_ => new SqlConnection(crmConnectionString));
            services.AddDbContext<SqlServerAppDbContext>(options => options.UseSqlServer(crmConnectionString));

            services.AddScoped<IGenericDirectDebitRepository, GenericDirectDebitRepository>();
            services.AddScoped<IAccountListRepository, AccountListRepository>();
            services.AddScoped<IProcessDateRepository, ProcessDateRepository>();
            services.AddScoped<IMerchantRepository, MerchantRepository>();
        }
    }
}