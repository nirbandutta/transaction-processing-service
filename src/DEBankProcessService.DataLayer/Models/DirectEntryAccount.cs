using System.Collections.Generic;

namespace TransactionProcessingService.DataLayer.Models
{
    public class DirectEntryAccount
    {
        public long AccountID { get; set; }
        public long CompanyID { get; set; }
        public bool GenerateByCompanyID { get; set; }
        public bool IsBankInfoFromTrn { get; set; }
        public bool IsAccountLevelCredit { get; set; }
        public bool IsDisbursementLink { get; set; }
        public bool IsAdhoc { get; set; }
        public string TrnTypesIncluded { get; set; }
        public bool IsAggregatedAccountModule { get; set; }
        public bool IsIncludeCC { get; set; }
        public bool IsAutoPayments { get; set; }
        public bool IsWithBalancingRecord { get; set; }
        public int FromAccountID { get; set; }
        public int AmountCalculationType { get; set; }
        public int TemplateTypeID { get; set; }
        public string Debit_BankName { get; set; }
        public string Debit_BankAssignedNumber { get; set; }
        public string Debit_BankAssignedName { get; set; }
        public string Debit_AccTitle { get; set; }
        public string Debit_AccRouting { get; set; }
        public string Debit_AccNo { get; set; }
        public string Debit_Remitter { get; set; }
        public string Debit_EntryDescriptor { get; set; }
        public string Debit_LodgementRef { get; set; }
        public string SettlementTime { get; set; }
        public string Credit_BankName { get; set; }
        public string Credit_BankAssignedNumber { get; set; }
        public string Credit_BankAssignedName { get; set; }
        public string Credit_AccTitle { get; set; }
        public string Credit_AccRouting { get; set; }
        public string Credit_AccNo { get; set; }
        public string Credit_Remitter { get; set; }
        public string Credit_EntryDescriptor { get; set; }
        public string Credit_LodgementRef { get; set; }
        public int RunNumber { get; set; }
        public IList<DirectEntryTransaction> DirectEntryTransactions { get; set; } = new List<DirectEntryTransaction>();
    }
}