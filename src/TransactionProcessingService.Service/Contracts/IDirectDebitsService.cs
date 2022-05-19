using System;
using System.Threading.Tasks;
using TransactionProcessingService.Service.Models.Response;

namespace TransactionProcessingService.Service.Contracts
{
    public interface IDirectDebitsService
    {
        public Task<DirectDebitsResponse> ProcessGenericDirectDebits(string bankName, DateTime dateToProcess);        
       
    }
}
