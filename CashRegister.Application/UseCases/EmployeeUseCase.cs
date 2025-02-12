using AutoMapper;
using CashRegister.Application.Dtos.Employees;
using CashRegister.Core.Entities;
using CashRegister.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Application.UseCases
{
    public class EmployeeUseCase(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        public async Task<IEnumerable<GetEmployeeDto>> GetEmployees() => mapper.Map<IEnumerable<GetEmployeeDto>>(await employeeRepository.GetEmployees());

        public async Task<GetEmployeeDto?> GetEmployeeById(IdEmployeeDto employeeDto) => mapper.Map<GetEmployeeDto>(await employeeRepository.GetEmployeeById(employeeDto.Id));
        
        public async Task<GetEmployeeDto> CreateEmployee(CreateEmployeeDto employeeDto)
        {
            Employee employee = mapper.Map<Employee>(employeeDto);
            await employeeRepository.CreateEmployee(employee);

            return mapper.Map<GetEmployeeDto>(employee);
        }

        public async Task<GetEmployeeDto> UpdateEmployee(ModifyEmployeeDto employeeDto)
        {
            Employee employee = mapper.Map<Employee>(employeeDto);
            await employeeRepository.UpdateEmployee(employee);

            return mapper.Map<GetEmployeeDto>(employee);
        }

        public Task DeleteEmployeeById(IdEmployeeDto employeeDto) => employeeRepository.DeleteEmployeeById(employeeDto.Id);
    }
}
