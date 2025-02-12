using CashRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Core.Repositories
{
    public interface ITaxRepository
    {
        public Task<IEnumerable<Tax>> GetTaxes();

        public Task<Tax?> GetTaxById(int id);

        public Task CreateTax(Tax tax);
    }
}
