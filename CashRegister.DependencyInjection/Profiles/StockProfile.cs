using AutoMapper;
using CashRegister.Application.Dtos.Stocks;
using CashRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.DependencyInjection.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Stock, GetStockDto>();
            CreateMap<CreateStockDto, Stock>()
                .ForMember(m => m.Id, p => p.Ignore())
                .ForMember(m => m.CreationDate, p => p.Ignore())
                .ForMember(m => m.ModificationDate, p => p.Ignore())
                .ForMember(m => m.StockMovements, p => p.Ignore());

            CreateMap<IdStockDto, Stock>()
                .ForMember(m => m.Id, p => p.Ignore())
                .ForMember(m => m.Label, p => p.Ignore())
                .ForMember(m => m.CreationDate, p => p.Ignore())
                .ForMember(m => m.Place, p => p.Ignore())
                .ForMember(m => m.ModificationDate, p => p.Ignore())
                .ForMember(m => m.StockMovements, p => p.Ignore());
        }
    }
}
