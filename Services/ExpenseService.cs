using ExpenseTracker.Data.Models;
using ExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services
{
    public class ExpenseService
    {
        private readonly ExpenseTrackerContext _context;
        public ExpenseService(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public async Task<List<Expense>> GetAllExpensesAsync()
        {
            return await _context.Expenses.Include(x=>x.Category).ToListAsync();
        }

        public async Task<Expense> AddExpenseAsync(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task DeleteExpenseAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            _context.Entry(expense).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Expense> GetExpenseByIdAsync(int id)
        {
            return await _context.Expenses.FindAsync(id);
        }

		public async Task<List<Expense>> GetExpensesByCategoryIdAsync(int categoryId)
		{
			return await _context.Expenses
				.Where(e => e.CategoryId == categoryId)
				.ToListAsync();
		}

        public async Task<DateTime> GetEarliestExpenseDateAsync()
        {
            return await _context.Expenses.MinAsync(expense => expense.Date);
        }

        public async Task<DateTime> GetLatestExpenseDateAsync()
        {
            return await _context.Expenses.MaxAsync(expense => expense.Date);
        }

        public async Task<float> GetCurrentMonthExpenseSumAsync()
        {
            var currentDate = DateTime.UtcNow;
            return await _context.Expenses
                .Where(expense => expense.Date.Year == currentDate.Year && expense.Date.Month == currentDate.Month)
                .SumAsync(expense => expense.Amount);
        }

    }
}
