using ConsoleAppProject.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.Models
{
    class Employee
    {
        static int Count = 1000;
        public string No { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public Departments departmentNames { get; set; }


        public Employee(string no,string fullname, string position,double salary, Departments departmentNames)
        {
            Count++;
            No = no;
            Position = position;
            Salary = salary;
           
            switch ((int)departmentNames)
            {
                case 0:
                    No += "MA" + Count;
                    break;
                case 1:
                    No += "RD" + Count;
                    break;
                case 2:
                    No += "FI" + Count;
                    break;
                case 3:
                    No += "CS" + Count;
                    break;
                case 4:
                    No += "HR" + Count;
                    break;
            }
        }
       
        public override string ToString()
        {
            return $"Nomresi: {No}\nVezifesi: {Position}\nEmekhaqqi: {Salary}";
        }


    }
}
