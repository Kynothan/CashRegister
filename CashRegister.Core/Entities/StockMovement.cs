using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Core.Entities
{
    public class StockMovement : EntityBase
    {
        public required ICollection<Product> Products { get; set; }

        public required uint Quantity { get; set; }

        public required int IdStock { get; set; }

        [ForeignKey(nameof(IdStock))]
        public required Stock Stock { get; set; }

    }
}
