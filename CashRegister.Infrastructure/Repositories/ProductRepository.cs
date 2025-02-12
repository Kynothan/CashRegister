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
    public class ProductRepository(CashRegisterContext cashRegisterContext) : IProductRepository
    {
        public async Task CreateProduct(Product product)
        {
            Tax? tax = await cashRegisterContext.Tax.FindAsync(product.IdTax);

            if (tax is null)
                throw new KeyNotFoundException(nameof(product.Tax));

            product.Tax = tax;

            cashRegisterContext.Product.Add(product);

            await cashRegisterContext.SaveChangesAsync();
        }

        public async Task DeleteProductById(int id)
        {
            Product? product = await cashRegisterContext.Product.FindAsync(id);

            if (product is null)
                return;

            cashRegisterContext.Product.Remove(product);
            await cashRegisterContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await cashRegisterContext.Product.Include(p => p.Tax).ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await cashRegisterContext.Product.Include(p => p.Tax).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateProduct(Product product)
        {
            Tax? tax = await cashRegisterContext.Tax.FindAsync(product.IdTax);

            if (tax is null)
                throw new KeyNotFoundException(nameof(product.Tax));

            Product? existingProduct = await cashRegisterContext.Product.FindAsync(product.Id);

            if (existingProduct is not null)
                cashRegisterContext.Entry(existingProduct).State = EntityState.Detached;
            else
                throw new KeyNotFoundException();

            product.CreationDate = existingProduct.CreationDate;
            product.Tax = tax;

            cashRegisterContext.Product.Update(product);
            await cashRegisterContext.SaveChangesAsync();
        }
    }
}
