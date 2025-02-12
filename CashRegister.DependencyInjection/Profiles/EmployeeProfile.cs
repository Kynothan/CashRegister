using AutoMapper;
using CashRegister.Application.Dtos.Employees;
using CashRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.DependencyInjection.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, GetEmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(m => m.Id, p => p.Ignore())
                .ForMember(m => m.CreationDate, p => p.Ignore())
                .ForMember(m => m.ModificationDate, p => p.Ignore());

            CreateMap<ModifyEmployeeDto, Employee>()
                .ForMember(m => m.CreationDate, p => p.Ignore())
                .ForMember(m => m.ModificationDate, p => p.MapFrom(dat => DateTime.Now));
            
            CreateMap<IdEmployeeDto, Employee>()
                .ForMember(m => m.Id, p => p.Ignore())
                .ForMember(m => m.Name, p => p.Ignore())
                .ForMember(m => m.CreationDate, p => p.Ignore())
                .ForMember(m => m.ArrivalDate, p => p.Ignore())
                .ForMember(m => m.ModificationDate, p => p.Ignore());
        }
    }
}
