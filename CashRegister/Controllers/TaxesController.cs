using CashRegister.Application.Dtos.Taxes;
using CashRegister.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CashRegister.Controllers
{
    [ApiController]
    [Route("Api/Taxes")]
    public class TaxesController(TaxUseCase taxUseCase) : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = "Get Taxes")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Taxes has not been found")]
        [SwaggerResponse(StatusCodes.Status200OK, "Taxes has been found", typeof(GetTaxDto))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<GetTaxDto> taxes = await taxUseCase.GetTaxes();

            if (taxes is null)
                return NotFound();

            return Ok(taxes);
        }

        [HttpGet]
        [Route("{id:int}")]
        [SwaggerOperation(Summary = "Get Tax by id")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Tax has not been found")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tax has been found", typeof(GetTaxDto))]
        public async Task<IActionResult> Get(int id)
        {
            IdTaxDto idTaxDto = new IdTaxDto { Id = id };

            GetTaxDto? tax = await taxUseCase.GetTaxById(idTaxDto);

            if (tax is null)
                return NotFound();

            return Ok(tax);
        }

        [HttpHead]
        [Route("{id:int}")]
        [SwaggerOperation(Summary = "Get Tax by id")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Tax has not been found")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Tax has been found")]
        public async Task<IActionResult> Head(int id)
        {
            IdTaxDto idTaxDto = new IdTaxDto { Id = id };

            GetTaxDto? tax = await taxUseCase.GetTaxById(idTaxDto);

            if (tax is null)
                return NotFound();

            return NoContent();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create Tax")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Tax have incorrect data")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tax has been created")]
        public async Task<IActionResult> Post([FromBody] CreateTaxDto createTaxDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GetTaxDto getTaxDto = await taxUseCase.CreateTax(createTaxDto);

            return Ok(getTaxDto);
        }
    }
}
