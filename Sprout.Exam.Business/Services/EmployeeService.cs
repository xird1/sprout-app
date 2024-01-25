using AutoMapper;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Services.Interfaces;
using Sprout.Exam.DataAccess.Entities;
using Sprout.Exam.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private Mapper _employeeMapper;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDto, Employee>().ReverseMap().ForMember(x => x.Birthdate,
                opt => opt.MapFrom(src => ((DateTime)src.Birthdate).ToShortDateString()));
                cfg.CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
                cfg.CreateMap<Employee, EditEmployeeDto>().ReverseMap();
            });
            _employeeMapper = new Mapper(mapperConfig);
        }

        public async Task<decimal> CalculateSalary(int employeeId, CalculateEmployeeDto input)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(employeeId);
            var employee = EmployeeFactory.GetEmployee(existingEmployee.EmployeeTypeId, input);
            return employee.CalculateSalary();
        }

        public async Task<int> CreateEmployeeAsync(CreateEmployeeDto employee)
        {
            try
            {
                var employeeToCreate = _employeeMapper.Map<CreateEmployeeDto, Employee>(employee);
                return await _employeeRepository.CreateEmployeeAsync(employeeToCreate);
            }
            catch (Exception ex)
            {
                //log exception
                return 0;
            }
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(id);
                employee.IsDeleted = true;
                return await _employeeRepository.DeleteEmployeeAsync(employee);
            }
            catch (Exception ex)
            {
                //log exception
                return 0;
            }
        }

        public async Task<EmployeeDto> EditEmployeeAsync(EditEmployeeDto employee)
        {
            try
            {
                var employeeToUpdate = await _employeeRepository.GetByIdAsync(employee.Id);
                var pendingChanges = _employeeMapper.Map<EditEmployeeDto, Employee>(employee, employeeToUpdate);
                var updatedEmployee = await _employeeRepository.EditEmployeeAsync(pendingChanges);
                return _employeeMapper.Map<Employee, EmployeeDto>(updatedEmployee);
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            return _employeeMapper.Map<Employee, EmployeeDto>(employee);
        }

        public async Task<List<EmployeeDto>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            return _employeeMapper.Map<IEnumerable<Employee>, List<EmployeeDto>>(employees);
        }
    }
}
