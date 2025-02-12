using CashRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Core.Repositories
{
    public interface IStockRepository
    {
        public Task<IEnumerable<Stock>> GetStocks();

        public Task<Stock?> GetStockById(int id);

        public Task CreateStock(Stock stock);
    }
}
