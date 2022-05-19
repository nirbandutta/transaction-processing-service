using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TransactionProcessingService.Service.Models.Response
{

    public class GetAllMerchantsResponse
    {
        [JsonPropertyName("merchants")]
        public IList<Merchant> Merchants { get; set; }

        public GetAllMerchantsResponse()
        {
            Merchants = new List<Merchant>();
        }
    }
}