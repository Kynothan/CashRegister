using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Application.Dtos.Stocks
{
    public class GetStockDto
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        public required string Label { get; set; }

        public required string Place { get; set; }
    }
}
