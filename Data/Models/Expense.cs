namespace ExpenseTracker.Data.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public bool Planned { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
