using ConsoleAppProject.Models;
using ConsoleAppProject.Services;
using System;

namespace ConsoleAppProject
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();

            do
            {
                Console.WriteLine("________________________ Human Resource Management_________________________");
                Console.WriteLine(" Size Uygun Olan Emeliyyatin Nomresini Daxil Edin");
                Console.WriteLine("1: Department Yaratmaq");
                Console.WriteLine("2: Departamentlerin siyahisini Gostermek ");
                Console.WriteLine("3: Departmanetde deyisiklik etmek");
                Console.WriteLine("4: Iscilerin siyahisini gostermek");
                Console.WriteLine("5: Departamentdeki iscilerin siyahisini gostermrek ");
                Console.WriteLine("6: Isci elave etmek");
                Console.WriteLine("7: Isci uzerinde deyisiklik etmek ");
                Console.WriteLine("8: Departamentden isci silinmesi ");
                Console.Write(" Emeliyyatin Nomresini Daxil Edin:");

                string choose = Console.ReadLine();
                int chooseNum;
                int.TryParse(choose, out chooseNum);

                switch (chooseNum)
                {
                    case 1:
                        Console.Clear();
                        AddDepartment(ref humanResourceManager);
                       
                        break;
                    case 2:
                        Console.Clear();
                        GetDepartments(ref humanResourceManager);
                        
                        break;
                    case 3:
                        Console.Clear();
                        EditDepartment(ref humanResourceManager);
                        
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Iscilerin siyahisini gostermek");
                      
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Iscilerin siyahisini gostermek");
                     
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Departmanetde deyisiklik etmek");
                      
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Departmanetde deyisiklik etmek");
                        
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("Departmanetde deyisiklik etmek");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun Daxil Edin");
                        break;
                }

            } while (true);

            static void GetDepartments(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Departments.Length > 0)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        Console.WriteLine($" {item} ");
                        Console.WriteLine("____________");
                    }
                }
                else
                {
                    Console.WriteLine("Departament movcud deyil. Ilk once departament yaradin...\n\n");
                }

            }
            static void AddDepartment(ref HumanResourceManager humanResourceManager)
            {
                string name;
                bool check = true;
                do
                {
                    if (check)
                    {
                        Console.Write("Departmentin Adini Daxil Edin:");
                    }
                    else
                    {
                        Console.WriteLine("Duzgun Daxil Edin:");
                    }
                    name = Console.ReadLine();
                    check = false;
                } while (!humanResourceManager.CheckName(name));
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Daxil Etdiyiniz Department Movcuddur Yeniden Daxil Edin:");
                        name = Console.ReadLine();
                    }
                    check = true;
                } while (!humanResourceManager.CheckName(name));

                Console.WriteLine("Isci sayini daxil edin:");
                checkWN:
                string WorkerLimit = Console.ReadLine();
                int WorkerLimitNum = 0;
                while (!int.TryParse(WorkerLimit, out WorkerLimitNum)|| WorkerLimitNum < 1)
                {
                    Console.WriteLine("Duzgun daxil edin:");
                    goto checkWN;
                }

                Console.WriteLine("Maash limitini daxil edin:");
                checkSL:
                string SalaryLimit = Console.ReadLine();
                int SalaryLimitNum = 0;
                while (!int.TryParse(SalaryLimit, out SalaryLimitNum) || SalaryLimitNum < 250)
                {
                    Console.WriteLine("Duzgun daxil edin:");
                    goto checkSL;
                }

                humanResourceManager.AddDeparment(name, WorkerLimitNum, SalaryLimitNum);
            }
            
        }
        static void EditDepartment(ref HumanResourceManager humanResourceManager)
        {

            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("Once Daxil edin:");
                return;

            }
            foreach (Department item in humanResourceManager.Departments)
            {
                Console.WriteLine($"{item}");
                Console.WriteLine("________________________");
            }
            Console.WriteLine("Deyisiklik edeceyiniz departmenti daxil edin");

            string name = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(name))
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == name.ToLower())
                    {
                        Console.WriteLine("Deyishikliyi Qeyd Edin");
                        string Newname= Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(name))
                        {

                            item.Name = Newname;
                        }
                    }
                }
            }
            

        }


    }
}


