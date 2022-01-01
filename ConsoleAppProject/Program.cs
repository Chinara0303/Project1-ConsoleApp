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
                Console.WriteLine("4: Iscilerin siyahisini gostermek");
                Console.WriteLine("5: Departamentdeki iscilerin siyahisini gostermek ");
                Console.WriteLine("6: Isci elave etmek");
                Console.WriteLine("7: Isci uzerinde deyisiklik etmek ");
                Console.WriteLine("8: Departamentden isci silinmesi ");
                Console.WriteLine("9: Sistemden Chix ");
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
                        EditDepartments(ref humanResourceManager);
                        break;
                    case 4:
                        Console.Clear();
                        GetEmployees(ref humanResourceManager);
                        break;
                    case 5:
                        GetEmployeesByDepartments(ref humanResourceManager);
                        break;
                    case 6:
                        Console.Clear();
                        AddEmployee(ref humanResourceManager);
                        break;
                    case 7:
                        EditEmployee(ref humanResourceManager);
                        break;
                    case 8:
                        Console.Clear();
                        RemoveEmployee(ref humanResourceManager);
                        break;
                    case 9:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun Daxil Edin");
                        break;
                }

            } while (true);
        }
        static void GetEmployees(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length > 0)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item!=null && item.Employees.Length > 0)
                    {
                        Console.WriteLine("Ishchilerin Siyahisi:");

                        foreach (Employee item1 in item.Employees)
                        {
                            if (item1!=null)
                            {
                                Console.WriteLine($"{item1}");
                                Console.WriteLine("_____________________");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Departamentde Ishci Movcud Deyil:");
                    }
                }
            }
            else
            {
                Console.WriteLine("Gostermek Uchun Hech Bir Ishchi Yoxdur. Evvelce Ishchi Elave Edin: ");
                return;
            }
        }
        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("Once Department Daxil Edin:  ");
                return;
            }
            Console.Write("Ishcini Elave Etmek Istediyiniz Departmentin Adini Qeyd Edin: ");
        checkDN:
            string DepartmentName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(DepartmentName) || DepartmentName.Length < 2)
            {
                Console.WriteLine("Departmentin Adini Duzgun Daxil Edin: ");
                goto checkDN;
            }
            string fullname = " ";
            string positionname = " ";
            bool check = false;
            double SalaryNum = 0;

            foreach (Department item in humanResourceManager.Departments)
            {
                if (item.Name.ToLower() == DepartmentName.ToLower())
                {

                    check = true;
                    if (item.WorkerLimit <= item.Wcounter())
                    {
                        Console.WriteLine("Departamentde Olan Ishci Sayi Limitini Ashdiniz: ");
                        return;
                    }
                    Console.Write("Elave Etmek Istediyiniz Ishchinin Ad Ve Soyadini Daxil Edin:");
                start:
                    fullname = Console.ReadLine();
                    string[] vs = fullname.Split(' ');
                    if (String.IsNullOrWhiteSpace(fullname) || vs.Length < 2)
                    {
                        Console.WriteLine("Ad ve Soyadi Duzgun Daxil Edin: ");
                        goto start;
                    }
                    Console.WriteLine("Ishchinin Vezifesini Daxil Edin: ");
                checkP:
                    positionname = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(positionname) || positionname.Length < 2)
                    {
                        Console.WriteLine("Vezife Adini Duzgun Daxil Edin:");
                        goto checkP;
                    }
                    Console.WriteLine("Ishcinin Maashini Daxil Edin:");
                checkSL:
                    string Salary = Console.ReadLine();

                    if (!double.TryParse(Salary, out SalaryNum) || SalaryNum < 250)
                    {
                        Console.WriteLine("Ishcinin Maashini Duzgun daxil edin:");
                        goto checkSL;
                    }
                    foreach (Department item1 in humanResourceManager.Departments)
                    {
                        if (item1.Name.ToLower() == DepartmentName.ToLower())
                        {
                            while (item1.SalaryLimit < item1.Scounter() + SalaryNum)
                            {
                                Console.WriteLine("Daxil Etdiyiniz Mebleg Departament Uzre Maash Limitini Ashir.");
                                Console.WriteLine("Zehmet Olmasa Duzgun Mebleg Daxil Edin:");
                                goto checkSL;
                            }
                        }
                        break;
                    }
                    break;
                }
            }
            if (check)
            {
                Console.WriteLine("Ishci Ugurla Elave Edildi.");
            }
            if (check == false)
            {
                Console.WriteLine("Departament Movcud Deyil.");
                Console.WriteLine("Departamentin Adini Yeniden Daxil Edin:");
                goto checkDN;
            }
            humanResourceManager.AddEmployee(fullname, positionname, SalaryNum, DepartmentName);
        }


        static void GetDepartments(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length > 0)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    Console.WriteLine($"{item}Maas Ortalamasi:{ item.CalcSalaryAverage()}");
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
            Console.WriteLine("Departament Adini Daxil Edin:");

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
            string name = " ";
            string Newname = " ";
            foreach (Department item in humanResourceManager.Departments)
            {
                Console.WriteLine($"{item}");
                Console.WriteLine("________________________");
            }
            Console.WriteLine("Deyisiklik edeceyiniz departmenti daxil edin");
             name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == name.ToLower())
                    {
                        Console.WriteLine("Deyishikliyi Qeyd Edin");
                         Newname = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            item.Name = Newname;
                            Console.Clear();
                            Console.WriteLine("Deyishiklik Qeyd Edildi:");
                        }
                    }
                }
            }
            humanResourceManager.EditDepartments(name, Newname);
        }
        static void GetEmployeesByDepartments(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("Once Department Yaradin: ");
                return;
            }
            Console.Clear();
            Console.WriteLine("Departamentlerin Siyahisi");
            Console.WriteLine("___________________");
            foreach (Department item in humanResourceManager.Departments)
            {
                Console.WriteLine($"{item}");
                Console.WriteLine("___________________");
                if (item.Employees.Length <= 0)
                {
                    Console.WriteLine("Departamente Ishci Elave Olunmayib.Once Ishci Elave Edin:");
                    return;
                }
            }
            Console.WriteLine("Hansi Departmentde Olan Ishchilere Baxmaq Isteyirsinizse O Departamentin Adini Daxil Edin:");
        start:
            string departmentname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(departmentname) || departmentname.Length < 2)
            {
                Console.WriteLine("Duzgun Daxil Edin: ");
                goto start;
            }
            bool check = true;
            foreach (Department item in humanResourceManager.Departments)
            {
                if (item.Name.ToLower() == departmentname.ToLower())
                {
                    foreach (Employee item1 in item.Employees)
                    {
                        if (item1!= null )
                        {
                            Console.WriteLine($"{item1}Vezife:{item1.Position}\n");
                            Console.WriteLine("_________________");
                        }
                    }
                    check = false;
                    break;
                }
                if (check == false)
                {
                    Console.WriteLine("Bu Adda Departament Movcud Deyil.");
                    Console.WriteLine("Duzgun Daxil Edin:");
                    goto start;
                }
                break;
            }
        }
        static void EditEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("Hech Bir Department Movcud Deyil. Once Department Daxil Edin:");
            }
            foreach (Department item in humanResourceManager.Departments)
            {
                if (item.Employees.Length <= 0)
                {
                    Console.WriteLine("Once Ishchi Elave Edin:");
                    return;
                }
                foreach (Employee item1 in item.Employees)
                {
                    Console.WriteLine("Deyisiklik Etmek Istediyiniz Ishcinin Nomresini Daxil Edin:");
                start:
                    string no = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(no))
                    {
                        Console.WriteLine("Ishchinin Nomresini Duzgun Daxil Edin:");
                        goto start;
                    }
                    foreach (Department item2 in humanResourceManager.Departments)
                    {
                        string PositionNew = null;
                        string salarynew = null;
                        double SalarynewNum = 0;
                        foreach (Employee item3 in item.Employees)
                        {
                            if (item.Employees != null)
                            {
                                if (item3.No.ToLower() == no.ToLower())
                                {
                                    Console.Clear();
                                    Console.WriteLine($"{item3}Vezife:{item3.Position}");
                                checkcase:
                                    Console.WriteLine("1: Maashda Deyishiklik Uchun Sechin ");
                                    Console.WriteLine("2: Vezifede Deyishiklik Uchun Sechin ");
                                    Console.WriteLine("3: Esas Menyuya Qayitmaq Uchun Sechin ");

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
                                            Console.WriteLine("Ishchinin Yeni Maashini Qeyd Edin:");
                                        checkSLRNEW:
                                            salarynew = Console.ReadLine();
                                            if (!double.TryParse(salarynew, out SalarynewNum) || SalarynewNum < 250)
                                            {
                                                Console.WriteLine("Duzgun Daxil Edin:");
                                                goto checkSLRNEW;
                                            }
                                            while (item.SalaryLimit < item.Scounter() - item3.Salary + SalarynewNum)
                                            {
                                                Console.WriteLine("Daxil Etdiyiniz Mebleg Departament Uzre Maash Limitini Ashir.");
                                                Console.WriteLine("Zehmet Olmasa Duzgun Mebleg Daxil Edin:");
                                                goto checkSLRNEW;
                                            }
                                            item1.Salary = SalarynewNum;
                                            Console.WriteLine("Deyishiklik Elave Edildi: ");
                                            goto checkcase;

                                        case 2:
                                            Console.WriteLine("Ishchinin yeni Vezifesini Qeyd Edin:");
                                        checkPositionnew:
                                            PositionNew = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(PositionNew) || PositionNew.Length < 2)
                                            {
                                                Console.WriteLine("Duzgun Daxil Edin:");
                                                goto checkPositionnew;
                                            }

                                            item1.Position = PositionNew;
                                            Console.WriteLine("Ishchinin Yeni Vezifesi Qeyd Olundu:");
                                            goto checkcase;
                                        case 3:
                                            return;
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
        static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("Hech Bir Departament Movcud Deyil. Once Departament Daxil Edin:");
                return;
            }
            foreach (Department item in humanResourceManager.Departments)
            {
                if (item.Employees.Length <= 0)
                {
                    Console.WriteLine("Once Ishchi Elave Edin:");
                    return;
                }
            }
            Console.WriteLine("Departamentlerin Siyahisi:");
            Console.WriteLine("_____________________________");
            foreach (Department item in humanResourceManager.Departments)
            {
                Console.WriteLine($"{item}");
                Console.WriteLine("__________________________");
            }
            Console.Write("Silmek Istediyiniz Ishchinin  Departament Adini Daxil Edin:");
        checkdepname:
            string Departmentname = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(Departmentname) || Departmentname.Length < 2)
            {
                Console.WriteLine("Duzgun Daxil Edin:");
                goto checkdepname;
            }

            string Wdelete = " ";
            foreach (Department item in humanResourceManager.Departments)
            {
                if (item.Name.ToLower() == Departmentname.ToLower())
                {
                    int countworker = 0;
                    foreach (Employee item1 in item.Employees)
                    {
                        if (item1 != null)
                        {
                            countworker++;
                        }
                    }
                    if (countworker == 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Once Ishchi Daxil Edin:");
                        return;
                    }

                    Console.Clear();
                    Console.WriteLine($"Ishchilerin Siyahisi");
                    Console.WriteLine("__________________________");
                    foreach (Employee item2 in item.Employees)
                    {
                        if (item2 != null)
                        {
                            Console.WriteLine($"{item2}");
                            Console.WriteLine("___________________");
                        }
                    }

                    Console.WriteLine("Silmek Istediyiniz Ishchinin Nomresini Daxil Edin:");
                checkWdelnum:
                    Wdelete = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(Wdelete) || Wdelete.Length < 6)
                    {
                        Console.WriteLine("Duzgun Daxil Edin:");
                        goto checkWdelnum;
                    }

                    bool check = true;
                    for (int i = 0; i < item.Employees.Length; i++)
                    {
                        if (item.Employees[i] != null)
                        {
                            if (item.Employees[i].No.ToLower() == Wdelete.ToLower())
                            {
                                item.Employees[i] = null;
                                check = true;
                                break;
                            }
                        }
                    }
                    if (check)
                    {
                        Console.Clear();
                        Console.WriteLine("Isci Ugurla Silindi.");
                    }

                    if (check == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Daxil Etdiyiniz Nomrede Ishchi Movcud deyil.");
                        return;
                    }

                    break;
                }
            }
                humanResourceManager.RemoveEmployee(Wdelete, Departmentname);
        }
    }
}

