using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.Models
{
    class Department
    {
        public string Name { get; set; }
        public int Workerlimit { get; set; }
        public double SalaryLimit { get; set; }
        public Employee[] Employees { get; set; }
        public double CalcSalaryAverage(Department department)
        {
            double TotalSalary = 0;
            int Counter = 0;
            foreach (Employee item in department.Employees)
            {
                TotalSalary += item.Salary;
                Counter++;
            }
            return TotalSalary / Counter;
        }
        public Department(string name, int workerlimit, double salaryLimit)
        {
            Name = name;
            Workerlimit = workerlimit;
            SalaryLimit = salaryLimit;
        }
        public override string ToString()
        {
            return $"Departament adi: {Name}\nIshci sayi: {Workerlimit}\nMaash Limiti:{SalaryLimit}\n";
        }
       
    }
}
