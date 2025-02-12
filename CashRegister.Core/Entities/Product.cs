using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Core.Entities
{
    public class Product : EntityBase
    {
        public required string Label { get; set; }

        public required decimal Price { get; set; }

        public required int IdTax {  get; set; }

        [ForeignKey(nameof(IdTax))]
        public required Tax Tax { get; set; }

        public required ICollection<StockMovement> StockMovements { get; set; }
    }
}
