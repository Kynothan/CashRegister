using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Core.Entities
{
    public class Stock : EntityBase
    {
        public required string Label { get; set; }

        public required string Place { get; set; }

        public required ICollection<StockMovement> StockMovements { get; set; }
    }
}
