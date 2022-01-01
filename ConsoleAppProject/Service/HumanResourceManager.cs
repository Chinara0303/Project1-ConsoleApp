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
        public HumanResourceManager()
        {
            _departments = new Department[0];
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
            foreach (Department item in _departments)
            {
                if (employee.DepartmentName.ToLower() == departmentName.ToLower())
                {
                    Array.Resize(ref item.Employees, item.Employees.Length + 1);
                    item.Employees[item.Employees.Length - 1] = employee;
                }
            }
        }
        public void EditDepartments(string Name, string NewName)
        {
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == NewName.ToLower())
                {
                    item.Name = NewName;
                    break;
                }
            }
        }
        public void EditEmployee(string no, string fullname, string position, double salary)
        {
            foreach (Department item in _departments)
            {
                foreach (Employee item1 in item.Employees)
                {
                    if (item1!=null && item1.No==no)
                    {
                          item1.FullName = fullname;
                          item1.Position=position;
                          item1.Salary = salary;
                    }
                }
            }
        }
        public void RemoveEmployee(string No, string DepartmentName)
        {
            foreach (Department item in _departments)
            {
                for (int i = 0; i < item.Employees.Length; i++)
                {
                    if (item.Employees[i] != null && item.Employees[i].No == No && item.Employees[i].DepartmentName.ToLower()==DepartmentName.ToLower())
                    {
                        item.Employees[i] = null;
                        return;
                    }
                }
            }
        }
        public void GetEmployees(string No, string FullName, string DepartmentName, double Salary)
        {
            Employee[] employees = new Employee[0];

            foreach (Department item in _departments )
            {
                foreach (Employee item1 in employees)
                {
                    if (item1!=null && item1.FullName == FullName)
                    {
                        Array.Resize(ref employees, employees.Length + 1);
                        employees[employees.Length - 1] = item1;
                        item1.No = No;
                        item1.DepartmentName = DepartmentName;
                        item1.Salary = Salary;
                    }
                }

            }
        }
        public void GetEmployeesByDepartments(string departmentname)
        {
            foreach (Department item in _departments)
            {
                foreach (Employee item1 in item.Employees)
                {
                    if (item1!=null && item1.DepartmentName.ToLower() == departmentname.ToLower())
                    {
                        item1.DepartmentName = departmentname.ToLower();
                    }
                }
            }
        }

        public Department[] GetDepartments()
        {
            if (_departments.Length<0)
            {
                return null;
            }
            return _departments;
        }
    }   
}