using Microsoft.EntityFrameworkCore;
using Sprout.Exam.DataAccess.Data;
using Sprout.Exam.DataAccess.Entities;
using Sprout.Exam.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _dbContext.Employees.Where(e => e.IsDeleted == false).ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted == false);
        }

        public async Task<int> CreateEmployeeAsync(Employee employee)
        {
            _dbContext.Add(employee);
            await _dbContext.SaveChangesAsync();
            return employee.Id;
        }

        public async Task<Employee> EditEmployeeAsync(Employee employee)
        {
            _dbContext.Update(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<int> DeleteEmployeeAsync(Employee employee)
        {
            _dbContext.Update(employee);
            await _dbContext.SaveChangesAsync();
            return employee.Id;
        }
    }
}
