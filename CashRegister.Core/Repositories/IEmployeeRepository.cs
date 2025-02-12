using CashRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Core.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetEmployees();

        public Task<Employee?> GetEmployeeById(int id);

        public Task CreateEmployee(Employee employee);

        public Task UpdateEmployee(Employee employee);

        public Task DeleteEmployeeById(int id);
    }
}
