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
        
        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (value.Length>2)
                {
                    _position = value;
                }
            }
        }
        private string _position;
        public double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value>250)
                {
                    _salary = value;
                }
            }
        }
        private double _salary;
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
            return $"Adi Soyadi: {FullName}\n Nomresi: {No}\nEmekhaqqi: {Salary}\nDepartament adi: {DepartmentName}\n";
        }
    }
}
