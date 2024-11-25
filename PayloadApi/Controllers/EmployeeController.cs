using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PayloadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDbConnection _dbConnection;

        public EmployeeController(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // GET: api/employee/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            // Call the GetEmployeeById stored procedure
            var parameters = new { EmployeeId = id };
            var employee = await _dbConnection.QuerySingleOrDefaultAsync<Employee>(
                "GetEmployeeById",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST: api/employee
        [HttpPost]
        public async Task<IActionResult> InsertEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is required.");
            }

            var parameters = new
            {
                Name = employee.Name,
                Position = employee.Position,
                Salary = employee.Salary,
                Age = employee.Age // Add Age parameter here
            };

            var result = await _dbConnection.ExecuteAsync(
                "InsertEmployee",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            if (result > 0)
            {
                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeId }, employee);
            }

            return BadRequest("Error inserting employee.");
        }


    }
}
