using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetEmployeesAsync();
        Task<EmployeeDto> GetByIdAsync(int id);
        Task<EmployeeDto> EditEmployeeAsync(EditEmployeeDto employee);
        Task<int> CreateEmployeeAsync(CreateEmployeeDto employee);
        Task<int> DeleteEmployeeAsync(int id);
        Task<decimal> CalculateSalary(int employeeId, CalculateEmployeeDto input);
    }
}
