using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionProcessingService.DataLayer.Contracts;
using TransactionProcessingService.Service.Contracts;
using TransactionProcessingService.Service.Models;
using TransactionProcessingService.Service.Models.Response;

namespace TransactionProcessingService.Service.Services
{
    public class MerchantService : IMerchantService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<MerchantService> _logger;
        private readonly IMerchantRepository _merchantRepository;

        public MerchantService(IMapper mapper,
            ILogger<MerchantService> logger, IMerchantRepository merchantRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _merchantRepository = merchantRepository;
        }

        public async Task<bool> AddMerchant(Merchant merchant)
        {
            return await _merchantRepository.AddMerchant(_mapper.Map<DataLayer.Models.Merchant>(merchant));
        }

        public async Task<GetAllMerchantsResponse> GetAllMerchants()
        {
            var response = new GetAllMerchantsResponse();

            var merchants = await _merchantRepository.GetMerchants();

            foreach (var merchant in merchants)
            {
                response.Merchants.Add(_mapper.Map<Merchant>(merchant));
            }

            return response;
        }

        public async Task<Merchant> GetMerchantById(int id)
        {

            var dbMerchant = await _merchantRepository.GetMerchantById(id);

            return _mapper.Map<Merchant>(dbMerchant);

        }
    }
}
