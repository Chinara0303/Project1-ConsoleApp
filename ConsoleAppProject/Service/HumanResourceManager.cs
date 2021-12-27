using ConsoleAppProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        public Department[] Departments => _departments;
        private Department[] _departments;
        public Employee[] employees => _employees;
        private Employee[] _employees;
        public HumanResourceManager()
        {
            _departments = new Department[0];
            _employees = new Employee[0];
        }

        public void AddDeparment(string Name, int Workerlimit, double SalaryLimit)
        {
            Department department = new Department(Name, Workerlimit, SalaryLimit);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;
        }
        public bool CheckName(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                if (Char.IsUpper(str[0]))
                {
                    foreach (var chr in str)
                    {
                        if (Char.IsLetter(chr) == false)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public void AddEmployee(string fullname, string position, double salary, string departmentName)
        {
            Employee employee = new Employee(fullname, position, salary, departmentName);
            Array.Resize(ref _employees, _employees.Length + 1);
            _employees[_employees.Length - 1] = employee;

        }

        public void EditDepartments(string Name, string NewName)
        {
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == NewName.ToLower())
                {
                    item.Name = NewName;
                    Console.WriteLine("Deyishiklik Ugurla Elave Edildi:");
                    break;
                }
            }
        }

        public void EditEmployee(string no, string fullname, string position, double salary)
        {
            foreach (Employee item in _employees)
            {
                if (item.No == no)
                {
                    item.FullName = fullname;
                    item.Position = position;
                    item.Salary = salary;
                }
            }
            return;
        }

        public void RemoveEmployee(string No, string DepartmentName)
        {
            for (int i = 0; i < _employees.Length; i++)
            {
                if (_employees[i].No == No)
                {
                    _employees = null;
                    return;
                }
            }
        }

        public void GetEmployees(string No, string FullName, string DepartmentName, double Salary)
        {
            Employee[] employees = new Employee[0];

            foreach (Employee item in _employees)
            {
                if (item.FullName == FullName)
                {
                    Array.Resize(ref employees, employees.Length + 1);
                    employees[employees.Length - 1] = item;
                    item.No = No;
                    item.DepartmentName = DepartmentName;
                    item.Salary = Salary;
                }

            }
        }

        public void GetEmployeesByDepartments(string departmentname)
        {
            foreach (Employee item in _employees)
            {
                if (item.DepartmentName.ToLower()== departmentname.ToLower())
                {
                    Console.WriteLine($"{item}");
                    Console.WriteLine("_____________");
                }
                
            }
        }

    }   
}