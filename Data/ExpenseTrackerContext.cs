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
		}
	}
}
