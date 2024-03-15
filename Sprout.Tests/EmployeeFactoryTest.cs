using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Models;
using Sprout.Exam.Business.Services;
using Sprout.Exam.Common.Enums;

namespace Sprout.Exam.Tests
{
    [TestClass]
    public class EmployeeFactoryTest
    {
        [TestMethod]
        public void EmployeeFactory_ShouldGetRegularEmployee()
        {
            var employeeToCheck = new CalculateEmployeeDto
            {
                AbsentDays = 1
            };
            var employeeTypeId = 1;

            var regularEmployee = EmployeeFactory.GetEmployee(employeeTypeId, employeeToCheck);

            Assert.IsNotNull(regularEmployee);
            Assert.IsInstanceOfType(regularEmployee, typeof(Regular));
        }

        [TestMethod]
        public void EmployeeFactory_ShouldCalculateRegularEmployee()
        {
            var employeeToCheck = new CalculateEmployeeDto
            {
                AbsentDays = 1
            };
            var employeeTypeId = 1;
            var expectedSalary = 16690.91m;

            var regularEmployee = EmployeeFactory.GetEmployee(employeeTypeId, employeeToCheck);
            var actualSalary = regularEmployee.CalculateSalary();

            Assert.AreEqual(expectedSalary, actualSalary);
        }

        [TestMethod]
        public void EmployeeFactory_ShouldGetContractualEmployee()
        {
            var employeeToCheck = new CalculateEmployeeDto
            {
                WorkedDays = 1
            };
            var employeeTypeId = 2;

            var contractualEmployee = EmployeeFactory.GetEmployee(employeeTypeId, employeeToCheck);

            Assert.IsNotNull(contractualEmployee);
            Assert.IsInstanceOfType(contractualEmployee, typeof(Contractual));
        }

        [TestMethod]
        public void EmployeeFactory_ShouldCalculateContractualEmployee()
        {
            var employeeToCheck = new CalculateEmployeeDto
            {
                WorkedDays = 15.5m
            };
            var employeeTypeId = 2;
            var expectedSalary = 7750.00m;

            var contractualEmployee = EmployeeFactory.GetEmployee(employeeTypeId, employeeToCheck);
            var actualSalary = contractualEmployee.CalculateSalary();

            Assert.AreEqual(expectedSalary, actualSalary);
        }
    }
}