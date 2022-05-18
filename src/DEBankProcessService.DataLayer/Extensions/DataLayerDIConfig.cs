using System.Data;
using TransactionProcessingService.DataLayer.Contracts;
using TransactionProcessingService.DataLayer.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace TransactionProcessingService.DataLayer.Extensions
{
    public static class DataLayerDiConfig
    {
        public static void AddDataAccessServices(this IServiceCollection services, string crmConnectionString,
            string trnConnectionString)
        {
            services.AddTransient<IDbConnection>(_ => new SqlConnection(crmConnectionString));
            services.AddScoped<IGenericDirectDebitRepository, GenericDirectDebitRepository>();
            services.AddScoped<IAccountListRepository, AccountListRepository>();
            services.AddScoped<IProcessDateRepository, ProcessDateRepository>();
        }
    }
}