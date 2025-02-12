using AutoMapper;
using CashRegister.Application.Dtos.Taxes;
using CashRegister.Core.Entities;
using CashRegister.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Application.UseCases
{
    public class TaxUseCase(ITaxRepository taxRepository, IMapper mapper)
    {
        public async Task<IEnumerable<GetTaxDto>> GetTaxes() => mapper.Map<IEnumerable<GetTaxDto>>(await taxRepository.GetTaxes());

        public async Task<GetTaxDto?> GetTaxById(IdTaxDto taxDto) => mapper.Map<GetTaxDto>(await taxRepository.GetTaxById(taxDto.Id));

        public async Task<GetTaxDto> CreateTax(CreateTaxDto taxDto)
        {
            Tax tax = mapper.Map<Tax>(taxDto);
            await taxRepository.CreateTax(tax);

            return mapper.Map<GetTaxDto>(tax);
        }
    }
}
