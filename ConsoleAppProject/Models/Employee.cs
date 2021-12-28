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
        public  string DepartmentName { get; set; }
        public Employee(string fullname, string position, double salary, string departmentName)
        {
            Count++;
            No += departmentName.ToUpper().Substring(0, 2) + Count;
            
            Salary = salary;
            DepartmentName = departmentName;
            Position = position;
            FullName = fullname;
            
        }
        public override string ToString()
        {
            return $"Adi Soyadi: {FullName}\n Nomresi: {No}\nVezifesi: {Position}\nEmekhaqqi: {Salary}";
        }
    }
}
