using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Services.Interfaces;
using Sprout.Exam.Business.Validator;
using Sprout.Exam.WebApp.Controllers;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.Tests
{
    [TestClass]
    public class EmployeeControllerTest
    {

        private Mock<IEmployeeService> _employeeServiceMock;
        private Fixture _fixture;
        private EmployeesController _employeesController;
        private EmployeeValidator _validator;

        public EmployeeControllerTest()
        {
            _fixture = new Fixture();
            _employeeServiceMock = new Mock<IEmployeeService>();
            _validator = new EmployeeValidator();
        }

        [TestMethod]
        public async Task EmployeeController_ShouldGetListOfEmployees_ReturnOk()
        {
            var employeeList = _fixture.CreateMany<EmployeeDto>(3).ToList();

            _employeeServiceMock.Setup(service => service.GetEmployeesAsync()).Returns(Task.FromResult(employeeList));

            _employeesController = new EmployeesController(_employeeServiceMock.Object, _validator);

            var result = await _employeesController.Get();
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);

        }
    }
}