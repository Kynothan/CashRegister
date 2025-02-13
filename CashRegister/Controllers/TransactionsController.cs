using CashRegister.Application.Dtos.Transactions;
using CashRegister.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CashRegister.Controllers
{
    [ApiController]
    [Route("Api/Transactions")]
    public class TransactionsController(TransactionUseCase transactionUseCase) : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = "Get Transactions")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Transactions has not been found")]
        [SwaggerResponse(StatusCodes.Status200OK, "Transactions has been found", typeof(GetTransactionDto))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<GetTransactionDto> transactions = await transactionUseCase.GetTransactions();

            if (transactions is null)
                return NotFound();

            return Ok(transactions);
        }

        [HttpGet]
        [Route("{id:int}")]
        [SwaggerOperation(Summary = "Get Transaction by id")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Transaction has not been found")]
        [SwaggerResponse(StatusCodes.Status200OK, "Transaction has been found", typeof(GetTransactionDto))]
        public async Task<IActionResult> Get(int id)
        {
            IdTransactionDto idTransactionDto = new IdTransactionDto { Id = id };

            GetTransactionDto? transaction = await transactionUseCase.GetTransactionById(idTransactionDto);

            if (transaction is null)
                return NotFound();

            return Ok(transaction);
        }

        [HttpHead]
        [Route("{id:int}")]
        [SwaggerOperation(Summary = "Get Transaction by id")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Transaction has not been found")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Transaction has been found")]
        public async Task<IActionResult> Head(int id)
        {
            IdTransactionDto idTransactionDto = new IdTransactionDto { Id = id };

            GetTransactionDto? transaction = await transactionUseCase.GetTransactionById(idTransactionDto);

            if (transaction is null)
                return NotFound();

            return NoContent();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create Transaction")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Transaction have incorrect data")]
        [SwaggerResponse(StatusCodes.Status200OK, "Transaction has been created")]
        public async Task<IActionResult> Post([FromBody] CreateTransactionDto createTransactionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GetTransactionDto getTransactionDto = await transactionUseCase.CreateTransaction(createTransactionDto);

            return Ok(getTransactionDto);
        }
    }
}
