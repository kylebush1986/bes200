using EmployeesApi.Data;
using EmployeesApi.Models.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    public class EmployeesController : ControllerBase
    {
        private readonly IManageEmployeeData _employeeData;

        public EmployeesController(IManageEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpDelete("employees/{id:int}")]
        public async Task<ActionResult> RemoveEmployee(int id)
        {
            await _employeeData.FireAsync(id);

            return NoContent();

        }

        [HttpPut("employees/{id:int}/firstname")]
        public async Task<ActionResult> ChangeFirstName(int id, [FromBody] string firstName)
        {
            bool wasModified = await _employeeData.ChangeFirstNameAsync(id, firstName);

            if(wasModified)
            {
                return NoContent();
            } else
            {
                return NotFound();
            }
        }

        [HttpPost("employees")]
        public async Task<ActionResult> AddAnEmployee([FromBody] PostEmployeeRequest request)
        {
            // validate.
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // hire them.
            GetEmployeeDetailsResponse response = await _employeeData.HireAsync(request);
            /// return a 201.
            /// return a Location header
            /// add the url of the new thing to the location header
            /// send them a copy of the new employees
            return CreatedAtRoute("employees#getbyid", new { id = response.Id }, response);
        }

        [HttpGet("employees")]
        [Produces("application/json")]
        public async Task<ActionResult<GetEmployeesResponse>> GetAllEmployees()
        {
            GetEmployeesResponse response = await _employeeData.GetAllActiveEmployeesAsync();

            return Ok(response);
        }

        // GET /employees/19 -> 200 or NotFound
        [Produces("application/json")]
        [HttpGet("/employees/{id:int}", Name ="employees#getbyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<GetEmployeeDetailsResponse>> GetAnEmployee(int id)
        {
            GetEmployeeDetailsResponse response = await _employeeData.GetEmployeeDetailsAsync(id);

            if(response == null)
            {
                return NotFound();
            } else
            {
                return Ok(response);
            }
        }
    }
}
