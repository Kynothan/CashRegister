using CashRegister.Core.Entities;
using CashRegister.Core.Repositories;
using Microsoft.EntityFrameworkCore;
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
            Product? product = await cashRegisterContext.Product.FindAsync(transaction.IdProduct);

            if (product is null)
                throw new KeyNotFoundException(nameof(transaction.Product));

            Tax? tax = await cashRegisterContext.Tax.FindAsync(transaction.IdTax);

            if (tax is null)
                throw new KeyNotFoundException(nameof(transaction.Tax));

            //Payment? payment = await cashRegisterContext.Payment.FindAsync(transaction.IdPayment);

            //if (payment is null)
            //    throw new KeyNotFoundException(nameof(transaction.Payment));

            transaction.Product = product;
            transaction.Tax = tax;
            //transaction.Payment = payment;
            //transaction.TaxValue = product.Price * tax.TaxCoefficient;
            //transaction.UnitPrice = product.Price - transaction.TaxValue;

            cashRegisterContext.Transaction.Add(transaction);

            await cashRegisterContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await cashRegisterContext.Transaction.Include(p => p.Product).Include(p => p.Tax).ToListAsync();
        }

        public async Task<Transaction?> GetTransactionById(int id)
        {
            return await cashRegisterContext.Transaction.Include(p => p.Product).Include(p => p.Tax).SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
