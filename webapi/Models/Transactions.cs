using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Transactions
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]  
        public DateOnly TransactionDate { get; set; }

        // Category Foreign key
        [ForeignKey("ReferencedCategory")]
        public int CategoryID { get; set; }
        public virtual Category? ReferencedCategory { get; set; }

        // User Foreign key
        [ForeignKey("ReferencedUser")]
        public string UserID { get; set; }
        public virtual ApiUser? ReferencedUser { get; set; }
    }
}
