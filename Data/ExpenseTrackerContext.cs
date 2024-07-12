using ExpenseTracker.Components.Pages;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Data.Models;

namespace ExpenseTracker.Data
{
    public class ExpenseTrackerContext : DbContext
     {
        public ExpenseTrackerContext(DbContextOptions<ExpenseTrackerContext> options)
            : base(options) 
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Category>()
                .HasData(new Category[]
                {
                    new Category() { Id = 1, Name = "Food" },
                    new Category() { Id = 2, Name = "Travel" },
                    new Category() { Id = 3, Name = "Entertainment" },
                    new Category() { Id = 4, Name = "Education" },
                    new Category() { Id = 5, Name = "Clothes" },
                    new Category() { Id = 6, Name = "House" },
                });

            modelBuilder.Entity<Expense>()
                .HasData(new Expense[]
                {
                    new Expense() { Id = 1, Title = "Grocery Shopping", Date = new DateTime(2023, 7, 1), Amount = 150.0f, Planned = true, CategoryId = 1 },
                    new Expense() { Id = 2, Title = "Movie Tickets", Date = new DateTime(2023, 7, 2), Amount = 40.0f, Planned = false, CategoryId = 3 },
                    new Expense() { Id = 3, Title = "Online Course", Date = new DateTime(2023, 7, 3), Amount = 100.0f, Planned = true, CategoryId = 4 },
                    new Expense() { Id = 4, Title = "New Jeans", Date = new DateTime(2023, 7, 4), Amount = 80.0f, Planned = false, CategoryId = 5 },
                });

            modelBuilder.Entity<Income>()
                .HasData(new Income[]
                {
                    new Income() { Id = 1, Title = "Monthly Salary", Date = new DateTime(2023, 7, 5), Amount = 3000.0f, Type = IncomeType.Salary },
                    new Income() { Id = 2, Title = "Scholarship Award", Date = new DateTime(2023, 7, 6), Amount = 500.0f, Type = IncomeType.Scholarship },
                    new Income() { Id = 3, Title = "Birthday Gift", Date = new DateTime(2023, 7, 7), Amount = 200.0f, Type = IncomeType.Gift },
                    new Income() { Id = 4, Title = "Lottery Winnings", Date = new DateTime(2023, 7, 8), Amount = 1000.0f, Type = IncomeType.LuckyWinnings },
                });
        }

    }
}
