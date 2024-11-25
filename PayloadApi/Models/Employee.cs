public class Employee
{
    public int EmployeeId { get; set; }  // Primary key
    public string Name { get; set; }     // Employee name
    public string Position { get; set; } // Job position/title
    public decimal Salary { get; set; }  // Salary of the employee

    public int Age { get; set; }
}
