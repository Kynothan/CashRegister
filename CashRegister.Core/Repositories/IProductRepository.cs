using CashRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Core.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();

        public Task<Product?> GetProductById(int id);

        public Task CreateProduct(Product product);

        public Task UpdateProduct(Product product);

        public Task DeleteProductById(int id);
    }
}
