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
        public string Fullname { get;  set; }
        //public Department(string name, int workerLimit, Employee[] employees, double SalaryLimit)
        //{
        //    if (employees.Length <= 0)
        //    {
        //        Console.WriteLine("Bu Deyer Bos Ola Bilmez");
        //        return;
        //    }
        //    if (Name.Length <= 2)
        //    {
        //        Console.WriteLine("daxil etdiyuniz adda melumat yoxdur");
        //    }

        //    Employees = employees;

        //    if (workerLimit <= 1)
        //    {

        //        Console.WriteLine(" Bu Sayda Ishci Tapilmadi");
        //        return;
        //    }
        //    if (SalaryLimit <= 250)
        //    {
        //        Console.WriteLine("Bu Maashda Ishci Yoxdur");
        //        return;
        //    }
        //}
        public double CalcSalaryAverage(Department department)
        {
            double TotalSalaray = 0;
            int Counter = 0;
            foreach (Employee item in department.Employees)
            {
                TotalSalaray += item.Salary;
                Counter++;

            }
            return TotalSalaray / Counter;
        }
   
        public Department(string name, int workerlimit, double salaryLimit)
        {
            Name = name;
            Workerlimit = workerlimit;
            SalaryLimit = salaryLimit;
        }

        public override string ToString()
        {
            return $"Departament adi: {Name}\nIshci sayi: {Workerlimit}\nMaas limiti: {SalaryLimit}";
        }
       
    }
}
