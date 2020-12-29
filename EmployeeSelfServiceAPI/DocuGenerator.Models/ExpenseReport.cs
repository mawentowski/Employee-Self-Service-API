using System;
namespace EmployeeSelfService.Models
{
    public class ExpenseReport: Entity
    {
        public decimal Amount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
    }
}
