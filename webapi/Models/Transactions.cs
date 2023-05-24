using Microsoft.AspNetCore.Identity;
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

        // Category Foreign key
        [ForeignKey("ReferencedCategory")]
        public virtual int CategoryID { get; set; }
        public virtual Category? ReferencedCategory { get; set; }

        // User Foreign key
        [ForeignKey("ReferencedUser")]
        public virtual string UserID { get; set; }
        public virtual IdentityUser? ReferencedUser { get; set; }
    }
}
