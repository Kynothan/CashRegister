using CashRegister.Application.Dtos.Stocks;
using CashRegister.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CashRegister.Controllers
{
    [ApiController]
    [Route("Api/Stocks")]
    public class StocksController(StockUseCase stockUseCase) : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = "Get Stocks")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Stocks has not been found")]
        [SwaggerResponse(StatusCodes.Status200OK, "Stocks has been found", typeof(GetStockDto))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<GetStockDto> stocks = await stockUseCase.GetStocks();

            if (stocks is null)
                return NotFound();

            return Ok(stocks);
        }

        [HttpGet]
        [Route("{id:int}")]
        [SwaggerOperation(Summary = "Get Stock by id")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Stock has not been found")]
        [SwaggerResponse(StatusCodes.Status200OK, "Stock has been found", typeof(GetStockDto))]
        public async Task<IActionResult> Get(int id)
        {
            IdStockDto idStockDto = new IdStockDto { Id = id };

            GetStockDto? stock = await stockUseCase.GetStockById(idStockDto);

            if (stock is null)
                return NotFound();

            return Ok(stock);
        }

        [HttpHead]
        [Route("{id:int}")]
        [SwaggerOperation(Summary = "Get Stock by id")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Stock has not been found")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Stock has been found")]
        public async Task<IActionResult> Head(int id)
        {
            IdStockDto idStockDto = new IdStockDto { Id = id };

            GetStockDto? stock = await stockUseCase.GetStockById(idStockDto);

            if (stock is null)
                return NotFound();

            return NoContent();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create Stock")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Stock have incorrect data")]
        [SwaggerResponse(StatusCodes.Status200OK, "Stock has been created")]
        public async Task<IActionResult> Post([FromBody] CreateStockDto createStockDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GetStockDto getStockDto = await stockUseCase.CreateStock(createStockDto);

            return Ok(getStockDto);
        }
    }
}
