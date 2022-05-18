using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TransactionProcessingService.Service.Models.Request
{
    public class DirectDebitsRequest
    {
        [Required]
        [MinLength(3), MaxLength(4)]
        [JsonPropertyName("bankName")]
        public string BankName { get; set; }

        [Required]        
        [JsonPropertyName("dateToProcess")]
        public DateTime DateToProcess { get; set; }    


    }
}
