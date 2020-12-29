using System;
namespace EmployeeSelfService.Models
{
    public class LeaveRequest: Entity
    {
        public string EmployeeName { get; set; }
        public DateRange DateRange { get; set; }
        public string Reason { get; set; }
        public bool IsApproved { get; set; }
    }
}
