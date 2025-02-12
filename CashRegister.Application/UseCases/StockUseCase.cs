using AutoMapper;
using CashRegister.Application.Dtos.Stocks;
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
    public class StockUseCase(IStockRepository stockRepository, IMapper mapper)
    {
        public async Task<IEnumerable<GetStockDto>> GetStocks() => mapper.Map<IEnumerable<GetStockDto>>(await stockRepository.GetStocks());

        public async Task<GetStockDto?> GetStockById(IdStockDto stockDto) => mapper.Map<GetStockDto>(await stockRepository.GetStockById(stockDto.Id));

        public async Task<GetStockDto> CreateStock(CreateStockDto stockDto)
        {
            Stock stock = mapper.Map<Stock>(stockDto);
            await stockRepository.CreateStock(stock);

            return mapper.Map<GetStockDto>(stock);
        }

    }
}
