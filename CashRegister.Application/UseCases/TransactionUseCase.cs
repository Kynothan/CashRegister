using AutoMapper;
using CashRegister.Application.Dtos.Transactions;
using CashRegister.Core.Entities;
using CashRegister.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Application.UseCases
{
    public class TransactionUseCase(ITransactionRepository transactionRepository, IMapper mapper)
    {
        public async Task<IEnumerable<GetTransactionDto>> GetTransactions() => mapper.Map<IEnumerable<GetTransactionDto>>(await transactionRepository.GetTransactions());

        public async Task<GetTransactionDto?> GetTransactionById(IdTransactionDto transactionDto) => mapper.Map<GetTransactionDto>(await transactionRepository.GetTransactionById(transactionDto.Id));

        public async Task<GetTransactionDto> CreateTransaction(CreateTransactionDto transactionDto)
        {
            Transaction transaction = mapper.Map<Transaction>(transactionDto);
            await transactionRepository.CreateTransaction(transaction);

            return mapper.Map<GetTransactionDto>(transaction);
        }
    }
}
