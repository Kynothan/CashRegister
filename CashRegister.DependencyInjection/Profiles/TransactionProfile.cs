using AutoMapper;
using CashRegister.Application.Dtos.Transactions;
using CashRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.DependencyInjection.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile() 
        {
            CreateMap<Transaction, GetTransactionDto>();

            CreateMap<CreateTransactionDto, Transaction>()
                .ForMember(m => m.Id, p => p.Ignore())
                .ForMember(m => m.CreationDate, p => p.Ignore())
                .ForMember(m => m.ModificationDate, p => p.Ignore())
                .ForMember(m => m.IdProduct, p => p.MapFrom(dat => dat.Product.Id))
                .ForMember(m => m.IdTax, p => p.MapFrom(dat => dat.Tax.Id))
                .ForMember(m => m.UnitPrice, p => p.Ignore())
                .ForMember(m => m.TaxValue, p => p.Ignore());
                //.ForMember(m => m.IdPayment, p => p.Ignore())
                //.ForMember(m => m.Payment, p => p.Ignore());
                //.ForMember(m => m.IdPayment, p => p.MapFrom(dat => dat.Payment.Id));

            CreateMap<IdTransactionDto, Transaction>()
                .ForMember(m => m.Id, p => p.Ignore())
                .ForMember(m => m.IdProduct, p => p.Ignore())
                .ForMember(m => m.CreationDate, p => p.Ignore())
                .ForMember(m => m.Product, p => p.Ignore())
                .ForMember(m => m.Quantity, p => p.Ignore())
                .ForMember(m => m.ModificationDate, p => p.Ignore())
                .ForMember(m => m.UnitPrice, p => p.Ignore())
                .ForMember(m => m.TaxValue, p => p.Ignore())
                .ForMember(m => m.IdTax, p => p.Ignore())
                .ForMember(m => m.Tax, p => p.Ignore());
                //.ForMember(m => m.IdPayment, p => p.Ignore())
                //.ForMember(m => m.Payment, p => p.Ignore());
        }
    }
}
