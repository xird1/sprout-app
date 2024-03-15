using Sprout.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.DataAccess.Repositories.Interfaces
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
