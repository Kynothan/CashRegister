using CashRegister.Application.Dtos.Employees;
using CashRegister.Application.UseCases;
using CashRegister.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CashRegister.Controllers
{
    [ApiController]
    [Route("Api/Employees")]
    public class EmployeesController(EmployeeUseCase employeeUseCase) : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = "Get Employees")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Employees has not been found")]
        [SwaggerResponse(StatusCodes.Status200OK, "Employees has been found", typeof(GetEmployeeDto))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<GetEmployeeDto> employees = await employeeUseCase.GetEmployees();

            if (employees is null)
                return NotFound();

            return Ok(employees);
        }

        [HttpGet]
        [Route("{id:int}")]
        [SwaggerOperation(Summary = "Get Employee by id")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Employee has not been found")]
        [SwaggerResponse(StatusCodes.Status200OK, "Employee has been found", typeof(GetEmployeeDto))]
        public async Task<IActionResult> Get(int id)
        {
            IdEmployeeDto idEmployeeDto = new IdEmployeeDto { Id = id };

            GetEmployeeDto? employee = await employeeUseCase.GetEmployeeById(idEmployeeDto);

            if (employee is null)
                return NotFound();

            return Ok(employee);
        }

        [HttpHead]
        [Route("{id:int}")]
        [SwaggerOperation(Summary = "Get Employee by id")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Employee has not been found")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Employee has been found")]
        public async Task<IActionResult> Head(int id)
        {
            IdEmployeeDto idEmployeeDto = new IdEmployeeDto { Id = id };

            GetEmployeeDto? employee = await employeeUseCase.GetEmployeeById(idEmployeeDto);

            if (employee is null)
                return NotFound();

            return NoContent();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create Employee")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Employee have incorrect data")]
        [SwaggerResponse(StatusCodes.Status200OK, "Employee has been created")]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GetEmployeeDto getEmployeeDto = await employeeUseCase.CreateEmployee(createEmployeeDto);

            return Ok(getEmployeeDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        [SwaggerOperation(Summary = "Update Employee")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Employee have incorrect data")]
        [SwaggerResponse(StatusCodes.Status200OK, "Employee has been modified")]
        public async Task<IActionResult> Put(int id, [FromBody] ModifyEmployeeDto modifyEmployeeDto)
        {
            if (modifyEmployeeDto.Id != id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                GetEmployeeDto? bddEmployee = await employeeUseCase.UpdateEmployee(modifyEmployeeDto);

                return Ok(bddEmployee);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [SwaggerOperation(Summary = "Remove Employee")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Employee does not exist")]
        public async Task<IActionResult> Delete(int id)
        {
            IdEmployeeDto idEmployeeDto = new IdEmployeeDto { Id = id };

            await employeeUseCase.DeleteEmployeeById(idEmployeeDto);

            return NoContent();
        }
    }
}
