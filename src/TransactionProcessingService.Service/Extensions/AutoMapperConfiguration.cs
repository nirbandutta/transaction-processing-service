using AutoMapper;
using TransactionProcessingService.DataLayer.Models;
using TransactionProcessingService.Service.Models.Response;
using DBMerchant = TransactionProcessingService.DataLayer.Models.Merchant;
using ServiceMerchant = TransactionProcessingService.Service.Models.Merchant;


namespace TransactionProcessingService.Service.Extensions
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureServiceModelsMapping(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<DirectEntryAccount, DirectEntryAccountModel>();
            cfg.CreateMap<DirectEntryTransaction, DirectEntryTransactionModel>();

            cfg.CreateMap<DBMerchant, ServiceMerchant>();
            cfg.CreateMap<ServiceMerchant, DBMerchant>();
        }
    }

}
