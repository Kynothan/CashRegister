using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Core.Entities
{
    public class Employee : EntityBase
    {
        public required string Name { get; set; }

        public required DateTime ArrivalDate { get; set; }
    }
}
