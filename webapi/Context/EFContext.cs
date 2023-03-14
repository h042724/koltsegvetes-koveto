using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Context
{
    public class EFContext : DbContext
    {
        public DbSet<Expenses> expenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.//DB//koltsegvetes-koveto.db");
        }
    }
}
