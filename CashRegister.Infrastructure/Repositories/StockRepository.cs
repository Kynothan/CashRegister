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
    public class StockRepository(CashRegisterContext cashRegisterContext) : IStockRepository
    {
        public async Task CreateStock(Stock stock)
        {
            cashRegisterContext.Stock.Add(stock);
            await cashRegisterContext.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<Stock>> GetStocks()
        {
            return await cashRegisterContext.Stock.ToListAsync();
        }

        public async Task<Stock?> GetStockById(int id)
        {
            return await cashRegisterContext.Stock.FindAsync(id);
        }
    }
}
