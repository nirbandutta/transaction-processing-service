using System.Text.Json.Serialization;

namespace TransactionProcessingService.Service.Models.Response
{
    public class DirectEntryTransactionModel
    {

        [JsonPropertyName("cleanSpecialCharsOnAccTitle")]
        public bool CleanSpecialCharsOnAccTitle { get; set; }

        [JsonPropertyName("templateTypeId")]
        public int TemplateTypeID { get; set; }

        [JsonPropertyName("trnId")]
        public long TrnID { get; set; }

        [JsonPropertyName("trnType")]
        public int TrnType { get; set; }

        [JsonPropertyName("accountId")]
        public long AccountID { get; set; }

        [JsonPropertyName("companyId")]
        public long CompanyID { get; set; }

        [JsonPropertyName("customerId")]
        public long CustomerID { get; set; }

        [JsonPropertyName("customerNumber")]
        public string CustomerNumber { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("surcharge")]
        public long Surcharge { get; set; }

        [JsonPropertyName("custRef")]
        public string CustRef { get; set; }

        [JsonPropertyName("receipt")]
        public string Receipt { get; set; }

        [JsonPropertyName("sourceAccRouting")]
        public string SourceAccRouting { get; set; }

        [JsonPropertyName("sourceAccNo")]
        public string SourceAccNo { get; set; }

        [JsonPropertyName("sourceAccTitle")]
        public string SourceAccTitle { get; set; }

        [JsonPropertyName("destAccRouting")]
        public string DestAccRouting { get; set; }

        [JsonPropertyName("destAccNo")]
        public string DestAccNo { get; set; }

        [JsonPropertyName("destAccTitle")]
        public string DestAccTitle { get; set; }

        [JsonPropertyName("aamPayment")]
        public bool AAMPayment { get; set; }

        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("settlementDate")]
        public string SettlementDate { get; set; }

        [JsonPropertyName("lodgementReference1")]
        public string LodgementReference1 { get; set; }

        [JsonPropertyName("lodgementReference2")]
        public string LodgementReference2 { get; set; }

        [JsonPropertyName("debitRemitter")]
        public string Debit_Remitter { get; set; }
    }
}
