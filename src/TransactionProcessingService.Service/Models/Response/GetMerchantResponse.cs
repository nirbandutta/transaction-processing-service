using System.Text.Json.Serialization;

namespace TransactionProcessingService.Service.Models.Response
{
    public class GetMerchantResponse
    {
        [JsonPropertyName("merchant")]
        public Merchant Merchant { get; set; }
    }
}