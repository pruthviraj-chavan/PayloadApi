using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

public class EmployeeRepository
{
    private readonly IDbConnection _dbConnection;

    public EmployeeRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    // Fetch employee by ID
    public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
    {
        var sql = "SELECT * FROM Employees WHERE EmployeeId = @EmployeeId";
        return await _dbConnection.QueryFirstOrDefaultAsync<Employee>(sql, new { EmployeeId = employeeId });
    }

    // Fetch all employees
    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        var sql = "SELECT * FROM Employees";
        return await _dbConnection.QueryAsync<Employee>(sql);
    }

    // Insert a new employee
    public async Task InsertEmployeeAsync(Employee employee)
    {
        var sql = "INSERT INTO Employees (Name, Salary, Position) VALUES (@Name, @Salary, @Position)";
        await _dbConnection.ExecuteAsync(sql, employee);
    }

    // Update an existing employee
    public async Task UpdateEmployeeAsync(Employee employee)
    {
        var sql = "UPDATE Employees SET Name = @Name, Salary = @Salary, Position = @Position WHERE EmployeeId = @EmployeeId";
        await _dbConnection.ExecuteAsync(sql, employee);
    }

    // Delete an employee by ID
    public async Task DeleteEmployeeAsync(int employeeId)
    {
        var sql = "DELETE FROM Employees WHERE EmployeeId = @EmployeeId";
        await _dbConnection.ExecuteAsync(sql, new { EmployeeId = employeeId });
    }
}
