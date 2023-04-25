using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Transactions
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]  
        public DateOnly TransactionDate { get; set; }

        // Foreign key   
        [Display(Name = "Category")]
        [ForeignKey("ReferencedCategory")]
        public virtual int CategoryID { get; set; }

        public virtual Category? ReferencedCategory { get; set; }
    }
}
