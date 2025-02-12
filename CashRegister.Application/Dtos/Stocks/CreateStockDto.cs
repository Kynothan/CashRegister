using CashRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Application.Dtos.Stocks
{
    public class CreateStockDto
    {
        public required string Label { get; set; }

        public required string Place { get; set; }
    }
}
