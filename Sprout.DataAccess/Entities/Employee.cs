using System;
using System.ComponentModel.DataAnnotations;

namespace Sprout.DataAccess.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        [StringLength(100)]
        public string TIN { get; set; }
        public int EmployeeTypeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
