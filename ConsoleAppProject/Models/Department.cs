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
        public double CalcSalaryAverage { get; set; }

        public Department(string name, Employee[] employees,int WorkerLimit, double SalaryLimit)
        {
            if(employees.Length<=0)
            {
                Console.WriteLine("Bu Deyer Bos Ola Bilmez");
                return;
            }
            Name = name;
            Employees = employees;

            if (WorkerLimit <= 1)
            {
                Console.WriteLine(" Bu Sayda Ishci Tapilmadi");
            }
            if(SalaryLimit <= 250)
            {
                Console.WriteLine("Bu Maashda Ishci Yoxdur");
            }

          
        }
      
       

    }
}
