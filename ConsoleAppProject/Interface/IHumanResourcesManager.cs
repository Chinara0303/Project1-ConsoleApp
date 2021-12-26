using ConsoleAppProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.Services
{
    interface IHumanResourceManager 
    {
        Employee[] employees { get; }
        Department[] Departments { get; }
        void AddDeparment(string Name, int Workerlimit, double SalaryLimit);
        Employee[] GetEmployees(string No, string FullName, string DepartmentName, double Salary);
        Department[] GetEmployeesByDepartments( string No, string Fullname, string Position, double Salary);
       void EditDepartments(string Name, string NewName);
        void AddEmployee( string fullname, string position, double salary, string departmentName);
        void RemoveEmployee(string No, string DepartmentName);
        void EditEmployee(string No, string Fullname, string Position, double Salary);
         
    }
}
