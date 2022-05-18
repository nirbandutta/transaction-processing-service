using TransactionProcessingService.DataLayer.Extensions;

namespace TransactionProcessingService.DataLayer.Models
{
    public class DirectEntryTransaction
    {
        private string _destAccTitle = "";
        private string _sourceAccTitle = "";

        public bool CleanSpecialCharsOnAccTitle { get; set; }
        public int TemplateTypeID { get; set; }
        public long TrnID { get; set; }
        public int TrnType { get; set; }
        public long AccountID { get; set; }
        public long CompanyID { get; set; }
        public long CustomerID { get; set; }
        public string CustomerNumber { get; set; }
        public long Amount { get; set; }
        public long Surcharge { get; set; }
        public string CustRef { get; set; }
        public string Receipt { get; set; }
        public string SourceAccRouting { get; set; }

        public string SourceAccNo { get; set; } = "";

        public string SourceAccTitle
        {
            get => _sourceAccTitle;
            set
            {
                _sourceAccTitle = value;
                if (CleanSpecialCharsOnAccTitle) 
                    value = value.Replace("`", " ");
                if (value == "") 
                    value = "ACCOUNT";
            }
        }

        public string DestAccRouting { get; set; }

        public string DestAccNo { get; set; } = "";

        public string DestAccTitle
        {
            get => _destAccTitle;
            set
            {
                _destAccTitle = value;
                if (CleanSpecialCharsOnAccTitle) _destAccTitle.Replace("`", " ");

                if (_destAccTitle == "") _destAccTitle = "ACCOUNT";
            }
        }

        public bool AAMPayment { get; set; }
        public string AccountNumber { get; set; }
        public string SettlementDate { get; set; }
        public string LodgementReference2 { get; set; }
        public string LodgementReference1 { get; set; }
        public string Debit_Remitter { get; set; }
    }
}