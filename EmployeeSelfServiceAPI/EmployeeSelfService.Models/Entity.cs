using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSelfService.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
