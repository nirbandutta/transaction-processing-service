using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionProcessingService.Service.Models
{
    public class Merchant
    {
        public int MerchantId { get; set; }
        public string Name { get; set; }

        public string ExternalReference { get; set; }
    }
}
