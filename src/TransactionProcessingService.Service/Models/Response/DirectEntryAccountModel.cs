using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TransactionProcessingService.Service.Models.Response
{
    public class DirectEntryAccountModel
    {

        [JsonPropertyName("accountId")]
        public long AccountID { get; set; }

        [JsonPropertyName("companyId")]
        public long CompanyID { get; set; }

        [JsonPropertyName("generateByCompanyId")]
        public bool GenerateByCompanyID { get; set; }

        [JsonPropertyName("isBankInfoFromTrn")]
        public bool IsBankInfoFromTrn { get; set; }

        [JsonPropertyName("isAccountLevelCredit")]
        public bool IsAccountLevelCredit { get; set; }

        [JsonPropertyName("isDisbursementLink")]
        public bool IsDisbursementLink { get; set; }

        [JsonPropertyName("isAdhoc")]
        public bool IsAdhoc { get; set; }

        [JsonPropertyName("trnTypesIncluded")]
        public string TrnTypesIncluded { get; set; }

        [JsonPropertyName("isAggregatedAccountModule")]
        public bool IsAggregatedAccountModule { get; set; }

        [JsonPropertyName("isIncludeCC")]
        public bool IsIncludeCC { get; set; }

        [JsonPropertyName("isAutoPayments")]
        public bool IsAutoPayments { get; set; }

        [JsonPropertyName("isWithBalancingRecord")]
        public bool IsWithBalancingRecord { get; set; }

        [JsonPropertyName("fromAccountId")]
        public int FromAccountID { get; set; }

        [JsonPropertyName("amountCalculationType")]
        public int AmountCalculationType { get; set; }

        [JsonPropertyName("templateTypeId")]
        public int TemplateTypeID { get; set; }

        [JsonPropertyName("debitBankName")]
        public string Debit_BankName { get; set; }

        [JsonPropertyName("debitBankAssignedNumber")]
        public string Debit_BankAssignedNumber { get; set; }

        [JsonPropertyName("debitBankAssignedName")]
        public string Debit_BankAssignedName { get; set; }

        [JsonPropertyName("debitAccTitle")]
        public string Debit_AccTitle { get; set; }


        [JsonPropertyName("debitAccRouting")]
        public string Debit_AccRouting { get; set; }

        [JsonPropertyName("debitAccNo")]
        public string Debit_AccNo { get; set; }

        [JsonPropertyName("debitRemitter")]
        public string Debit_Remitter { get; set; }

        [JsonPropertyName("debitEntryDescriptor")]
        public string Debit_EntryDescriptor { get; set; }

        [JsonPropertyName("debitLodgementRef")]
        public string Debit_LodgementRef { get; set; }

        [JsonPropertyName("settlementTime")]
        public string SettlementTime { get; set; }

        [JsonPropertyName("creditBankName")]
        public string Credit_BankName { get; set; }

        [JsonPropertyName("creditBankAssignedNumber")]
        public string Credit_BankAssignedNumber { get; set; }

        [JsonPropertyName("creditBankAssignedName")]
        public string Credit_BankAssignedName { get; set; }

        [JsonPropertyName("creditAccTitle")]
        public string Credit_AccTitle { get; set; }

        [JsonPropertyName("creditAccRouting")]
        public string Credit_AccRouting { get; set; }

        [JsonPropertyName("creditAccNo")]
        public string Credit_AccNo { get; set; }

        [JsonPropertyName("creditRemitter")]
        public string Credit_Remitter { get; set; }

        [JsonPropertyName("creditEntryDescriptor")]
        public string Credit_EntryDescriptor { get; set; }

        [JsonPropertyName("creditLodgementRef")]
        public string Credit_LodgementRef { get; set; }

        [JsonPropertyName("runNumber")]
        public int RunNumber { get; set; }

        public IList<DirectEntryTransactionModel> DirectEntryTransactions { get; set; } =
            new List<DirectEntryTransactionModel>();

    }
}
