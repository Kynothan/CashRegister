using CashRegister.Core.Entities;
using CashRegister.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Infrastructure.Repositories
{
    public class EmployeeRepository(CashRegisterContext cashRegisterContext) : IEmployeeRepository
    {
        public async Task CreateEmployee(Employee employee)
        {
            cashRegisterContext.Employee.Add(employee);
            await cashRegisterContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeById(int id)
        {
            Employee? employee = await cashRegisterContext.Employee.FindAsync(id);

            if (employee is null)
                return;

            cashRegisterContext.Employee.Remove(employee);
            await cashRegisterContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await cashRegisterContext.Employee.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await cashRegisterContext.Employee.FindAsync(id);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            Employee? existingEmployee = await cashRegisterContext.Employee.FindAsync(employee.Id);

            if (existingEmployee is not null)
                cashRegisterContext.Entry(existingEmployee).State = EntityState.Detached;
            else
                throw new KeyNotFoundException();

            employee.CreationDate = existingEmployee.CreationDate;

            cashRegisterContext.Employee.Update(employee);
            await cashRegisterContext.SaveChangesAsync();
        }
    }
}
