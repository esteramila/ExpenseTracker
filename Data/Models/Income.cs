namespace ExpenseTracker.Data.Models
{
    public class Income
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public IncomeType Type { get; set; }
    }
    public enum IncomeType
    {
        Salary,
        Scholarship,
        Gift,
        LuckyWinnings
    }
}
