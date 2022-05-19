using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionProcessingService.DataLayer.Models
{
    public class Order
    {
        [Column("OrderID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int OrderID { get; set; }

        [Column("OrderDate")]
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public int MerchantId { get; set; }
    }
}
