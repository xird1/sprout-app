using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.Entities;

namespace Sprout.Exam.WebApp
{
    public static class StaticEmployees
    {
        public static List<Employee> ResultList = new()
        {
            new Employee
            {
                Birthdate = new DateTime(1993,03,25),
                FullName = "Jane Doe",
                Id = 1,
                TIN = "123215413",
                EmployeeTypeId = 1
            },
            new Employee
            {
                Birthdate = new DateTime(1993, 05, 28),
                FullName = "John Doe",
                Id = 2,
                TIN = "957125412",
                EmployeeTypeId = 2
            }
        };
    }
}
