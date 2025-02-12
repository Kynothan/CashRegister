using CashRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Core.Repositories
{
    public interface IStockMovementRepository
    {
        public Task<StockMovement?> GetStockMovementById(int id);

        public Task CreateStockMovement(StockMovement stockMovement);
    }
}
