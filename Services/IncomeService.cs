﻿using ExpenseTracker.Data.Models;
using ExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services
{
	public class IncomeService
	{
		private readonly ExpenseTrackerContext _context;
		public IncomeService(ExpenseTrackerContext context)
		{
			_context = context;
		}

		public async Task<List<Income>> GetAllIncomesAsync()
		{
			return await _context.Incomes.ToListAsync();
		}

		public async Task<Income> AddIncomeAsync(Income income)
		{
            income.ConvertDateToUtc();
            _context.Incomes.Add(income);
			await _context.SaveChangesAsync();
			return income;
		}

		public async Task DeleteIncomeAsync(int id)
		{
			var income = await _context.Incomes.FindAsync(id);
			if (income != null)
			{
				_context.Incomes.Remove(income);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateIncomeAsync(Income income)
		{
            income.ConvertDateToUtc();
            _context.Entry(income).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task<Income> GetIncomeByIdAsync(int id)
		{
			return await _context.Incomes.FindAsync(id);
		}

	}
}