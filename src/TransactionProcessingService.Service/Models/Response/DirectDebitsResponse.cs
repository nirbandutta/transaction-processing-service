using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TransactionProcessingService.Service.Models.Response
{

    public class DirectDebitsResponse 
    {
        public DirectDebitsResponse()
        {
            DirectEntryAccounts = new List<DirectEntryAccountModel>();
        }

        [JsonPropertyName("directEntryAccounts")]
        public IList<DirectEntryAccountModel> DirectEntryAccounts { get; set; }
    }
}