using System;

namespace EmployeeSelfService.Models
{
    public class Employee: Entity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactAreaCode { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
        public string Positiontitle { get; set; }
        public string Supervisor { get; set; }
        public string Status { get; set; }
        public string[] UsualDaysOfEmployment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
    }
}
