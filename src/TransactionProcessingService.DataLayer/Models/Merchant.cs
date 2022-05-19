using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionProcessingService.DataLayer.Models
{
    [Table("Merchants")]
    public class Merchant
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int MerchantId { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("ExternalRef")]
        [Required]
        [StringLength(100)]
        public string ExternalReference { get; set; }

        [ForeignKey("MerchantId")]
        public virtual List<Order> Orders { get; set; }
    }
}
