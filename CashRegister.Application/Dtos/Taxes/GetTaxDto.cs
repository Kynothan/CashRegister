using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Application.Dtos.Taxes
{
    public class GetTaxDto
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        public required string Label { get; set; }

        public required decimal TaxCoefficient { get; set; }
    }
}
