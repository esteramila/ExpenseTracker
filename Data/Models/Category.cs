using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Expense> Expenses { get; set; } // nu schimba tabelu, dar face legatura one-to-many intre category si expenses 
    }
}
