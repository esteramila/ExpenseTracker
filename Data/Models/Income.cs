namespace ExpenseTracker.Data.Models
{
    public class Income
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public IncomeType Type { get; set; }

        public void ConvertDateToUtc()
        {
            if (Date.Kind == DateTimeKind.Local)
            {
                Date = Date.ToUniversalTime();
            }
            else if (Date.Kind == DateTimeKind.Unspecified)
            {
                Date = DateTime.SpecifyKind(Date, DateTimeKind.Utc);
            }
        }
    }

    public enum IncomeType
    {
        Salary,
        Scholarship,
        Gift,
        LuckyWinnings
    }
}
