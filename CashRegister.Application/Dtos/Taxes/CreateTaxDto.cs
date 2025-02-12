using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Application.Dtos.Taxes
{
    public class CreateTaxDto
    {
        public required string Label { get; set; }

        public required decimal TaxCoefficient { get; set; }
    }
}
