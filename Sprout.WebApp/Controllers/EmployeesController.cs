using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sprout.Business.DataTransferObjects;
using Sprout.Common.Enums;
using Sprout.Business.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using Sprout.Business.Validator;
using Sprout.Business.DataTransferObjects;

namespace Sprout.WebApp.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        private readonly EmployeeValidator _employeeValidator;

        public EmployeesController(IEmployeeService employeeService, EmployeeValidator employeeValidator)
        {
            _employeeService = employeeService;
            _employeeValidator = employeeValidator;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditEmployeeDto input)
        {
            var employee = await _employeeService.GetByIdAsync(input.Id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                var validation = _employeeValidator.ValidateRequest(input);
                if (validation.HasError)
                {
                    return BadRequest(validation.ErrorMessage);
                }
                var result = await _employeeService.EditEmployeeAsync(input);
                if (result == null)
                {
                    return StatusCode(500);
                }
                return Ok(result);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeDto input)
        {
            var validation = _employeeValidator.ValidateRequest(input);
            if (validation.HasError)
            {
                return BadRequest(validation.ErrorMessage);
            }
            var id = await _employeeService.CreateEmployeeAsync(input);
            if (id == 0)
            {
                return StatusCode(500);
            }
            return Created($"/api/employees/{id}", id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                var result = await _employeeService.DeleteEmployeeAsync(id);
                if (id == 0)
                {
                    return StatusCode(500);
                }
                return Ok(result);
            }
        }

        [HttpPost("{id}/calculate")]
        public async Task<IActionResult> Calculate(int id, CalculateEmployeeDto input)
        {
            var result = await _employeeService.CalculateSalary(id, input);
            return Ok(result);
        }

    }
}
