using CashRegister.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Core.Entities
{
    public class Payment : EntityBase
    {
        public required ICollection<Transaction> Transactions { get; set; }

        public required PaymentStatus Status { get; set; }
        
        public required string PayementMethod { get; set; }
    }
}
