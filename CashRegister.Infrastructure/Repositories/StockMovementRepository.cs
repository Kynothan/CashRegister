using CashRegister.Core.Entities;
using CashRegister.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Infrastructure.Repositories
{
    public class StockMovementRepository(CashRegisterContext cashRegisterContext) : IStockMovementRepository
    {
        public async Task CreateStockMovement(StockMovement stockMovement)
        {
            cashRegisterContext.StockMovement.Add(stockMovement);
            await cashRegisterContext.SaveChangesAsync();
        }

        public async Task<StockMovement?> GetStockMovementById(int id)
        {
            return await cashRegisterContext.StockMovement.FindAsync(id);
        }
    }
}
