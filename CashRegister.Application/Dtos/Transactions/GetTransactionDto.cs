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
    public class GetTransactionDto
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        public required GetProductDto Product { get; set; }

        public required uint Quantity { get; set; }

        public required decimal UnitPrice { get; set; }

        public required decimal TaxValue { get; set; }

        public required GetTaxDto Tax { get; set; }

        // public required Payment Payment { get; set; }
    }
}
