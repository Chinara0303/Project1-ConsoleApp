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
                Console.WriteLine("3: Departmentde deyisiklik etmek");
                Console.WriteLine("4: Iscilerin siyahisini gostermek");//AD SOYAD CIXARTMIR
                Console.WriteLine("5: Departamentdeki iscilerin siyahisini gostermek ");
                Console.WriteLine("6: Isci elave etmek");//LIMITDEN ARTIQ ISHCI ELAVE EDIR
                Console.WriteLine("7: Isci uzerinde deyisiklik etmek ");
                Console.WriteLine("8: Departamentden isci silinmesi ");//SILMIR
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
                        //Console.Clear();
                        EditDepartments(ref humanResourceManager);
                        break;
                    case 4:
                        Console.Clear();
                        GetEmployees(ref humanResourceManager);
                        break;
                    case 5:
                        //Console.Clear();
                        GetEmployeesByDepartments(ref humanResourceManager);
                        break;
                    case 6:
                        Console.Clear();
                        AddEmployee(ref humanResourceManager);
                        break;
                    case 7:
                        //Console.Clear();
                        EditEmployee(ref humanResourceManager);

                        break;
                    case 8:
                        Console.Clear();
                        RemoveEmployee(ref humanResourceManager);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun Daxil Edin");
                        break;
                }

            } while (true);
        }

        

        static void GetEmployees(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.employees.Length <= 0)
            {
                Console.WriteLine("Once Ishci Daxil Edin");
            }
            else
            {
                foreach (Employee item in humanResourceManager.employees)
                {
                    Console.WriteLine($"{item}");
                }
            }
        }
        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("Once Department Daxil Edin:  ");
                return;
            }
            Console.Write("Elave Etmek Istediyiniz Ishcinin Adini Daxil Edin:");
        start:
            string FullName = Console.ReadLine();
            string[] vs = FullName.Split(' ');
            if (String.IsNullOrWhiteSpace(FullName) || vs.Length < 2 || vs[0].Length < 2 || vs[1].Length < 3)
            {
                Console.WriteLine("Ad ve Soyadi Duzgun Daxil Edin:");
                goto start;
            }
            Console.WriteLine("Ishcinin Vezifesini Daxil Edin: ");
        checkP:
            string PositionName = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(PositionName) || PositionName.Length < 2)
            {
                Console.WriteLine(" Vezife Adini Duzgun Daxil Edin:");
                goto checkP;
            }
            Console.WriteLine("Ishcinin Maashini Daxil Edin:");
        checkSL:
            string Salary = Console.ReadLine();
            double SalaryNum = 0;
            while (!double.TryParse(Salary, out SalaryNum) || SalaryNum < 250)
            {
                Console.WriteLine("Ishcinin Maashini Duzgun daxil edin: ");
                goto checkSL;
            }
            Console.Write("Ishcini Elave Etmek Istediyiniz Departmentin Adini Qeyd Edin: ");
        checkDN:
            string DepartmentName = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(DepartmentName))
            {
                Console.WriteLine("Departmentin Adini Duzgun Daxil Edin: ");
                goto checkDN;
            }

            foreach (Department item in humanResourceManager.Departments)
            {
                if (item.Name.ToLower() == DepartmentName.ToLower())
                {
                    Console.WriteLine("DeyishikliK Qeyd Edildi: ");
                    break;
                }
            }

            humanResourceManager.AddEmployee(FullName, PositionName, SalaryNum, DepartmentName);
        }
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
                Console.WriteLine("Departament movcud deyil. Ilk once departament yaradin: \n\n");
            }

        }
        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
        checkN:
            Console.WriteLine("Departament Adini Daxil Edin: ");
            string Name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Departament Adini Duzgun Daxil Edin:");
                goto checkN;
            }

            Console.WriteLine("Isci sayini daxil edin:");
        checkWN:
            string WorkerLimit = Console.ReadLine();
            int WorkerLimitNum = 0;
            while (!int.TryParse(WorkerLimit, out WorkerLimitNum) || WorkerLimitNum < 1)
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

            humanResourceManager.AddDeparment(Name, WorkerLimitNum, SalaryLimitNum);
        }
        static void EditDepartments(ref HumanResourceManager humanResourceManager)
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
                        string Newname = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(name))
                        {

                            item.Name = Newname;
                        }
                    }
                }
            }
        }
        static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length<=0)
            {
                Console.WriteLine("Once Department Yaradin: ");
                return;
            }
            foreach (Department item in humanResourceManager.Departments)
            {
                Console.WriteLine($"{item}");
                Console.WriteLine("_________________");
            }
            Console.WriteLine("Departmentin adini Daxil Edin:");
            string departmentname = Console.ReadLine();
            bool checkdepname = true;
            int count = 0;
            while (checkdepname)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower()== departmentname.ToLower())
                    {
                        count++;
                    }
                }
                if (count <= 0)
                {
                    Console.WriteLine("Daxil Etdiyiniz Adda Department Movcud Deyil");
                    Console.Write("Duzgun Department Adi Daxil Edin: ");
                    departmentname = Console.ReadLine();
                }
                else
                {
                    checkdepname = false;
                }
                count = 0;
            }
            if (humanResourceManager.employees.Length <= 0)
            {
                Console.WriteLine("Silmek Uchun Hech Bir Ishci Tapilmadi");
                return;
            }

            foreach (Employee item in humanResourceManager.employees)
            {
                Console.WriteLine($"{item}");
                Console.WriteLine("________________");
            }

            Console.Write("Silmek Istediyiniz Ishchinin Nomresini Daxil Edin:");
            string empNo = Console.ReadLine();
            bool checkempNo = true;
            int count1 = 0;

            while (checkempNo)
            {
                foreach (Employee item in humanResourceManager.employees)
                {
                    if (item.No.ToLower() == empNo.ToLower())
                    {
                        count1++;
                    }
                }

                if (count1 <= 0)
                {
                    Console.WriteLine("Daxil Etdiyniz Nomrede Ishchi Movcud Deyil");
                    Console.Write("Duzgun Ishci Nomresi Daxil Edin: ");
                    empNo = Console.ReadLine();
                }
                else
                {
                    checkempNo = false;
                }
                count1 = 0;
            }
            humanResourceManager.RemoveEmployee(empNo, departmentname);
        }
        static void GetEmployeesByDepartments(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("Once Department Yaradin: ");
                return;
            }
            if (humanResourceManager.employees.Length <= 0)
            {
                Console.WriteLine("Elde Etmek Uchun Hech Bir Ishci Yoxdur: ");
                return;
            }
            Console.WriteLine("Departmentin adini Daxil Edin:");
            start:
            string departmentname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(departmentname))
            {
                Console.WriteLine("Duzgun Daxil Edin: ");
                goto start;
            }
            humanResourceManager.GetEmployeesByDepartments(departmentname);
        }            
        static void EditEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.employees.Length <= 0)
            {
                Console.WriteLine("Once Ishci Elave Edin: ");
                return;
            }
            foreach (Employee item in humanResourceManager.employees)
            {
                Console.WriteLine($"{item}");
                Console.WriteLine("___________________");
            }
            Console.WriteLine("Deyisiklik Etmek Istediyiniz Ishcinin Nomresini Daxil Edin: ");
        start:
            string no = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(no))
            {
                Console.WriteLine("Ishcinin Nomresini Duzgun Daxil Edin: ");
                goto start;
            }
            foreach (Employee item in humanResourceManager.employees)
            {
                if (item.No.ToLower() == no.ToLower())
                {
                    Console.WriteLine("1: Maashda Deyishiklik Uchun Sechin ");
                    Console.WriteLine("2: Vezifede Deyishiklik Uchun Sechin ");

                checkSLR:
                    string editemp = Console.ReadLine();
                    int empno = 0;
                    if (!int.TryParse(editemp, out empno))
                    {
                        Console.WriteLine("Duzgun Daxil Edin: ");
                        goto checkSLR;
                    }
                    switch (empno)
                    {
                        case 1:
                            Console.WriteLine("Ishcinin Yeni Maashini Qeyd Edin: ");

                        checkSLRNEW:
                            string salarynew = Console.ReadLine();
                            int SalarynewNum = 0;
                            if(!int.TryParse(salarynew,out SalarynewNum))
                            {
                                Console.WriteLine("Duzgun Daxil Edin:");
                                goto checkSLRNEW;
                            }

                            item.Salary = SalarynewNum;
                            Console.WriteLine("Deyishiklik Elave Edildi: ");
                            break;
                            
                        case 2:
                            Console.WriteLine("Ishchinin yeni Vezifesini Qeyd Edin: ");
                            
                        checkPositionnew:
                            string PositionNew = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(PositionNew))
                            {
                                Console.WriteLine("Duzgun Daxil Edin:");
                                goto checkPositionnew;
                            }

                            item.Position = PositionNew;
                            Console.WriteLine("Ishchinin Yeni Vezifesi Qeyd Olundu:");
                            break;  
                    }                    
                }
                else
                {
                    Console.WriteLine("Bu Nomrede Ishc Tapilmadi: ");
                    return;
                }
            }
        }
    }
}







