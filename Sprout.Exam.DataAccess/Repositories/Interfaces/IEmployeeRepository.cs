using Sprout.Exam.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> EditEmployeeAsync(Employee employee);
        Task<int> CreateEmployeeAsync(Employee employee);
        Task<int> DeleteEmployeeAsync(Employee employee);
    }
}
