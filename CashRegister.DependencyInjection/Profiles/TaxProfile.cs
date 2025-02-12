using AutoMapper;
using CashRegister.Application.Dtos.Taxes;
using CashRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.DependencyInjection.Profiles
{
    public class TaxProfile : Profile
    {
        public TaxProfile()
        {
            CreateMap<Tax, GetTaxDto>();
            CreateMap<CreateTaxDto, Tax>()
                .ForMember(m => m.Id, p => p.Ignore())
                .ForMember(m => m.CreationDate, p => p.Ignore())
                .ForMember(m => m.ModificationDate, p => p.Ignore());

            CreateMap<IdTaxDto, Tax>()
                .ForMember(m => m.Id, p => p.Ignore())
                .ForMember(m => m.Label, p => p.Ignore())
                .ForMember(m => m.CreationDate, p => p.Ignore())
                .ForMember(m => m.TaxCoefficient, p => p.Ignore())
                .ForMember(m => m.ModificationDate, p => p.Ignore());
        }
    }
}
