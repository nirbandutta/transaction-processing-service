using AutoMapper;
using TransactionProcessingService.DataLayer.Models;
using TransactionProcessingService.Service.Models.Response;

namespace TransactionProcessingService.Service.Extensions
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureServiceModelsMapping(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<DirectEntryAccount, DirectEntryAccountModel>();
            cfg.CreateMap<DirectEntryTransaction, DirectEntryTransactionModel>();
        }
    }

}
