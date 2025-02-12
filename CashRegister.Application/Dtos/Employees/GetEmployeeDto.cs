using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Application.Dtos.Employees
{
    public class GetEmployeeDto
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        public required string Name { get; set; }

        public required DateTime ArrivalDate { get; set; }
    }
}
