using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Core.Entities
{
    public class Transaction : EntityBase
    {
        public required int IdProduct { get; set; }

        [ForeignKey(nameof(IdProduct))]
        public required Product Product { get; set; }

        public required uint Quantity { get; set; }

        public required decimal UnitPrice { get; set; }

        public required decimal TaxValue { get; set; }

        public required int IdTax { get; set; }

        [ForeignKey(nameof(IdTax))]
        public required Tax Tax { get; set; }

        //public required int IdPayment { get; set; }

        //[ForeignKey(nameof(IdPayment))]
        //public required Payment Payment { get; set; }
    }
}
