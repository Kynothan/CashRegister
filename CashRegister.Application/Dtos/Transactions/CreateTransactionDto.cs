using CashRegister.Application.Dtos.Payments;
using CashRegister.Application.Dtos.Products;
using CashRegister.Application.Dtos.Taxes;
using CashRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Application.Dtos.Transactions
{
    public class CreateTransactionDto
    {
        public required IdProductDto Product { get; set; }

        public required uint Quantity { get; set; }

        public required IdTaxDto Tax { get; set; }

        //public required IdPaymentDto Payment { get; set; }
    }
}
