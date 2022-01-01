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
        
        public Department(string name, int workerlimit, double salarylimit)
        {
            Name = name;
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;
            Employees = new Employee[0];
        }
        public double CalcSalaryAverage()
        {
            double TotalSalary = 0;
            int Counter = 0;
            if (Employees.Length<=0)
            {
                return 0;
            }
            else
            {
                foreach (Employee item in Employees)
                {
                    if (item!=null)
                    {
                        TotalSalary += item.Salary;
                        Counter++;
                    }
                }
                return TotalSalary / Counter;
            }
        }
        public int Wcounter()
        {
            int TotalW = 0;
            foreach (Employee item in Employees)
            {
                if (item!=null)
                {
                    TotalW++;
                }
            }
            return TotalW;
        }
        public double Scounter()
        {
            double salarynow = 0;
            foreach (Employee item in Employees)
            {
                if (item != null)
                {
                    salarynow += item.Salary;
                }
            }
            return salarynow;
        }
        public override string ToString()
        {
            return $"Departament adi: {Name}\nIshci sayi: {WorkerLimit}\nMaash Limiti:{SalaryLimit}\n";
            
        }

        
    }
}
