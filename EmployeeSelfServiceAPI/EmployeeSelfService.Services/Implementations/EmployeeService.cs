using System;
using EmployeeSelfService.Models;

namespace EmployeeSelfService.Services.Implementations
{
    public class EmployeeService: EntityService<Employee>
    {
        public EmployeeService()
        {
            AddEntity(new Employee
            {
                FirstName = "Mark",
                MiddleName = "Alan",
                LastName = "Wentowski",
                StreetAddress = "518 Eastdale Rd S",
                StreetAddressLine2 = "",
                City = "Montgomery",
                PostCode = "36117",
                Country = "United States",
                AreaCode = "334",
                PhoneNumber = "306-2810",
                Email = "mawentowski@gmail.com",
                BirthDate = new DateTime(1986, 12, 16),
                EmergencyContactName = "Kaye Wentowski",
                EmergencyContactAreaCode = "334",
                EmergencyContactPhoneNumber = "306-2810",
                Positiontitle = "Tehnical Writer",
                Supervisor = "Bob Smith",
                Status = "Active",
                UsualDaysOfEmployment = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" },
                StartDate = new DateTime(2015, 1, 1),
                ContractEndDate = new DateTime(2022, 5, 15)
            });
        }
    }
}
