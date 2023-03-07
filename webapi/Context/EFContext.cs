using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Context
{
	public class EFContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
	{
		//readonly DbContextOptions<EFContext> options;
		/*public EFContext(DbContextOptions<EFContext> _options) : base(_options)
		{
			this.options = _options;
		}*/

		public virtual DbSet<Expense> Expenses { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//if (options == null)
				optionsBuilder.UseSqlite("Data Source=.//DB//koltsegvetes-koveto.db");
		}
	}
}
