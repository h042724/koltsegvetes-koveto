using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.Models;

namespace webapi.Configurations.Entities
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                { ID = 1, Name = "Grocery", ExpenseOrIncome = "expense", IconName = "nutrition" },
                new Category
                { ID = 2, Name = "Transportation", ExpenseOrIncome = "expense", IconName = "directions_car" },
                new Category
                { ID = 3, Name = "Entertainment", ExpenseOrIncome = "expense", IconName = "attractions" },
                new Category
                { ID = 4, Name = "Salary", ExpenseOrIncome = "income", IconName = "payments" },
                new Category
                { ID = 5, Name = "Investments", ExpenseOrIncome = "income", IconName = "monetization_on" },
                new Category
                { ID = 6, Name = "Rental", ExpenseOrIncome = "income", IconName = "real_estate_agent" }
                );
        }
    }
}
