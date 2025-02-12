using AutoMapper;
using CashRegister.Application.Dtos.Employees;
using CashRegister.Application.Dtos.Products;
using CashRegister.Core.Entities;
using CashRegister.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Application.UseCases
{
    public class ProductUseCase(IProductRepository productRepository, IMapper mapper)
    {
        public async Task<IEnumerable<GetProductDto>> GetProducts() => mapper.Map<IEnumerable<GetProductDto>>(await productRepository.GetProducts());

        public async Task<GetProductDto?> GetProductById(IdProductDto productDto) => mapper.Map<GetProductDto>(await productRepository.GetProductById(productDto.Id));

        public async Task<GetProductDto> CreateProduct(CreateProductDto productDto)
        {
            Product product = mapper.Map<Product>(productDto);
            await productRepository.CreateProduct(product);

            return mapper.Map<GetProductDto>(product);
        }

        public async Task<GetProductDto> UpdateProduct(ModifyProductDto productDto)
        {
            Product product = mapper.Map<Product>(productDto);
            await productRepository.UpdateProduct(product);

            return mapper.Map<GetProductDto>(product);
        }

        public Task DeleteProductById(IdProductDto productDto) => productRepository.DeleteProductById(productDto.Id);
    }
}
