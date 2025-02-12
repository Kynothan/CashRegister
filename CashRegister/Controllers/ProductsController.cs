using CashRegister.Application.Dtos.Products;
using CashRegister.Application.UseCases;
using CashRegister.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CashRegister.Controllers
{
    [ApiController]
    [Route("Api/Products")]
    public class ProductsController(ProductUseCase productUseCase) : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = "Get Products")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Products has not been found")]
        [SwaggerResponse(StatusCodes.Status200OK, "Products has been found", typeof(GetProductDto))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<GetProductDto> products = await productUseCase.GetProducts();

            if (products is null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        [SwaggerOperation(Summary = "Get Product by id")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Product has not been found")]
        [SwaggerResponse(StatusCodes.Status200OK, "Product has been found", typeof(GetProductDto))]
        public async Task<IActionResult> Get(int id)
        {
            IdProductDto idProductDto = new IdProductDto { Id = id };

            GetProductDto? product = await productUseCase.GetProductById(idProductDto);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpHead]
        [Route("{id:int}")]
        [SwaggerOperation(Summary = "Get Product by id")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Product has not been found")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Product has been found")]
        public async Task<IActionResult> Head(int id)
        {
            IdProductDto idProductDto = new IdProductDto { Id = id };

            GetProductDto? product = await productUseCase.GetProductById(idProductDto);

            if (product is null)
                return NotFound();

            return NoContent();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create Product")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Product have incorrect data")]
        [SwaggerResponse(StatusCodes.Status200OK, "Product has been created")]
        public async Task<IActionResult> Post([FromBody] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GetProductDto getProductDto = await productUseCase.CreateProduct(createProductDto);

            return Ok(getProductDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        [SwaggerOperation(Summary = "Update Product")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Product have incorrect data")]
        [SwaggerResponse(StatusCodes.Status200OK, "Product has been modified")]
        public async Task<IActionResult> Put(int id, [FromBody] ModifyProductDto modifyProductDto)
        {
            if (modifyProductDto.Id != id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                GetProductDto? bddProduct = await productUseCase.UpdateProduct(modifyProductDto);

                return Ok(bddProduct);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [SwaggerOperation(Summary = "Remove Product")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Product does not exist")]
        public async Task<IActionResult> Delete(int id)
        {
            IdProductDto idProductDto = new IdProductDto { Id = id };

            await productUseCase.DeleteProductById(idProductDto);

            return NoContent();
        }
    }
}
