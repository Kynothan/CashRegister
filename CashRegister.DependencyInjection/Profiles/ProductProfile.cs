using AutoMapper;
using CashRegister.Application.Dtos.Products;
using CashRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CashRegister.DependencyInjection.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductDto>();
            CreateMap<CreateProductDto, Product>()
                .ForMember(m => m.Id, p => p.Ignore())
                .ForMember(m => m.CreationDate, p => p.Ignore())
                .ForMember(m => m.ModificationDate, p => p.Ignore())
                .ForMember(m => m.IdTax, p => p.MapFrom(dat => dat.Tax.Id))
                .ForMember(m => m.StockMovements, p => p.Ignore());

            CreateMap<ModifyProductDto, Product>()
                .ForMember(m => m.CreationDate, p => p.Ignore())
                .ForMember(m => m.ModificationDate, p => p.MapFrom(dat => DateTime.Now))
                .ForMember(m => m.IdTax, p => p.MapFrom(dat => dat.Tax.Id))
                .ForMember(m => m.StockMovements, p => p.Ignore());

            CreateMap<IdProductDto, Product>()
                .ForMember(m => m.Id, p => p.Ignore())
                .ForMember(m => m.Label, p => p.Ignore())
                .ForMember(m => m.CreationDate, p => p.Ignore())
                .ForMember(m => m.Price, p => p.Ignore())
                .ForMember(m => m.Tax, p => p.Ignore())
                .ForMember(m => m.ModificationDate, p => p.Ignore())
                .ForMember(m => m.IdTax, p => p.Ignore())
                .ForMember(m => m.StockMovements, p => p.Ignore());
        }
    }
}
