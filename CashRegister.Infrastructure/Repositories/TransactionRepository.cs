using CashRegister.Core.Entities;
using CashRegister.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Infrastructure.Repositories
{
    public class TransactionRepository(CashRegisterContext cashRegisterContext) : ITransactionRepository
    {
        public async Task CreateTransaction(Transaction transaction)
        {
            cashRegisterContext.Transaction.Add(transaction);
            await cashRegisterContext.SaveChangesAsync();
        }

        public async Task<Transaction?> GetTransactionById(int id)
        {
            return await cashRegisterContext.Transaction.FindAsync(id);
        }
    }
}
