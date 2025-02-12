using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Core.Entities
{
    public class Tax : EntityBase
    {
        public required string Label { get; set; }

        public required decimal TaxCoefficient { get; set; }
    }
}
