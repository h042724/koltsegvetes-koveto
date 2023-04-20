using System.ComponentModel.DataAnnotations;

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
    }
}
