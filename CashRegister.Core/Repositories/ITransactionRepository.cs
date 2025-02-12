using CashRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Core.Repositories
{
    public interface ITransactionRepository
    {
        public Task<Transaction?> GetTransactionById(int id);

        public Task CreateTransaction(Transaction transaction);
    }
}
