using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
	public class Expense
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[Display(Name = "Név")]
		public string Name { get; set; }
		[Required]
		[Display(Name = "Kategória")]
		public string Category { get; set; }
		[Required]
		[Display(Name = "Tranzakció dátuma")]
		public DateTime TransactionDate { get; set; }

		[Required]
		[ForeignKey("Id")]
		public Guid UserGuid { get; set; }

    }
}
