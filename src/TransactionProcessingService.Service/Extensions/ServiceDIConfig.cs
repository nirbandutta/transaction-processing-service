using AutoMapper;
using TransactionProcessingService.DataLayer.Extensions;
using TransactionProcessingService.Service.Contracts;
using TransactionProcessingService.Service.Services;
using Microsoft.Extensions.DependencyInjection;


namespace TransactionProcessingService.Service.Extensions
{
    public static class ServiceDIConfig
    {
        public static void RegisterServices(this IServiceCollection services, string crmConnectionString, string trnConnectionString)
        {
            services.AddScoped<IDirectDebitsService, DirectDebitsService>();
            services.AddScoped<IMerchantService, MerchantService>();
            services.AddSingleton(new MapperConfiguration(cfg => cfg.ConfigureServiceModelsMapping()).CreateMapper());
            services.AddScoped<ICommonService, CommonService>();
            services.AddDataAccessServices(crmConnectionString, trnConnectionString);


        }
    }
}
