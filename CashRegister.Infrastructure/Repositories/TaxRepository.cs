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
    public class TaxRepository(CashRegisterContext cashRegisterContext) : ITaxRepository
    {
        public async Task CreateTax(Tax tax)
        {
            cashRegisterContext.Tax.Add(tax);
            await cashRegisterContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tax>> GetTaxes()
        {
            return await cashRegisterContext.Tax.ToListAsync();
        }

        public async Task<Tax?> GetTaxById(int id)
        {
            return await cashRegisterContext.Tax.FindAsync(id);
        }
    }
}
