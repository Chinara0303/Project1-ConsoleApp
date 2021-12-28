using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.Models
{
    class Department
    {
        public string Name { get; set; }
        public double SalaryLimit
        {
            get
            {
                return _salarylimit;
            }
            set
            {
                if (value>250)
                {
                    _salarylimit = value;
                }
            }
        }
        private double _salarylimit;
        public int WorkerLimit 
        {
            get
            {
                return _workerlimit;
            }
            set
            {
                if (value>1)
                {
                    _workerlimit = value;
                }
            }
        }
        private int _workerlimit;

        public Employee[] Employees = { };
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
        public Department(string name, int workerlimit, double salarylimit)
        {
            Name = name;
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;
            Employees = new Employee[0];
        }
        public override string ToString()
        {
            return $"Departament adi: {Name}\nIshci sayi: {WorkerLimit}\nMaash Limiti:{SalaryLimit}\n";
        }
       
       
    }
}
