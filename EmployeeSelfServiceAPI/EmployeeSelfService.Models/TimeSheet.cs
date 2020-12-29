using System;
namespace EmployeeSelfService.Models
{
    public class TimeSheet: Entity
    {
        public int EmployeeId { get; set; }
        public DateRange[] DateRanges { get; set; }
    }
}
