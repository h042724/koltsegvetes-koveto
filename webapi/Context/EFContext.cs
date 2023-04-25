using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi.Configurations.Entities;
using webapi.Models;

namespace webapi.Context
{
    public class EFContext : IdentityDbContext<ApiUser>
    {
        public EFContext(DbContextOptions options) : base(options) {  }

        public DbSet<Transactions> transactions { get; set; }
        public DbSet<Category> category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.//DB//koltsegvetes-koveto.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
