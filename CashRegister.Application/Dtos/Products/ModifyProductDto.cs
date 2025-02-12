using CashRegister.Application.Dtos.Taxes;
using CashRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Application.Dtos.Products
{
    public class ModifyProductDto
    {
        public required int Id { get; set; }

        public required string Label { get; set; }

        public required decimal Price { get; set; }

        public required IdTaxDto Tax { get; set; }
    }
}
