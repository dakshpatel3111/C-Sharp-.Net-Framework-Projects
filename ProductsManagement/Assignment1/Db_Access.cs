using System;
using System.Collections.Generic;
using System.Linq;


namespace Assignment1
{
    class Db_Access
        // Class to hole the Methods used in the Application
    {
        public void PrintEmployeeList(List<Employee> list)
        {
            var l = from x in list
                    select x;

            foreach(var y in l)
            {
                Console.WriteLine($"----------------------" +
                    $"\nId :{y.Id}\nName :{y.Name}\nAddress:{y.Address}" +
                    $"\nEmail:{y.Email}\nPhone:{y.Phone}\nRole:{y.Role}\n");
                
            }
            Console.WriteLine("---\t----\t-List of All Employees---\t-----\t");
            Console.WriteLine("\n");
        }
        public void PrintMainMenu()
        {
            Console.WriteLine("*----------Main-Menu-----------*");
            Console.WriteLine("Press 1 to Modify Employees:");
            Console.WriteLine("Press 2 to add Payroll");
            Console.WriteLine("Press 3 to View Vacation Days");
            Console.WriteLine("Press 4 to exit ");
            Console.WriteLine("---\t----\t----\t-----\t");
          
        }
        public void PrintEmployeeMenu()
        {
            Console.WriteLine("*----------Employee-Menu-----------*");
            Console.WriteLine("Press 1 to list all Employees:");
            Console.WriteLine("Press 2 to add new Employee");
            Console.WriteLine("Press 3 to update Employee");
            Console.WriteLine("Press 4 to Delete Employee ");
            Console.WriteLine("Press 5 to exit");
            Console.WriteLine("---\t----\t----\t-----\t");
            
        }

        public Employee AddEmployee()
        {
            Employee e = new Employee();
            Console.WriteLine("Enter a Unique Id:");
            e.Id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter a Name :");
            e.Name = Console.ReadLine();
            Console.WriteLine("Enter a Address:");
            e.Address = Console.ReadLine();
            Console.WriteLine("Enter a Email:");
            e.Email = Console.ReadLine();
            Console.WriteLine("Enter Phone Number:");
            e.Phone = Console.ReadLine();
            Console.WriteLine("Enter the Role of Employee:");
            e.Role = Console.ReadLine();
            

            return e;
        }
        public void UpdateEmployee(List<Employee> list,string id)
        {
            var employ = from l in list
                         where l.Id == int.Parse(id)
                         select l;
            int index = list.FindIndex(e => e.Id == int.Parse(id));
            list.RemoveAt(index);
            Employee e3 = AddEmployee();
            list.Insert(index, e3);
            PrintEmployeeList(list);

        }

        public void PrintPayrollMenu()
        {
            Console.WriteLine("*----------Payroll-Menu-----------*");
            Console.WriteLine("Press 1 to Insert Payroll:");
            Console.WriteLine("Press 2 to View Payroll History");
            Console.WriteLine("Press 3 to Return to Main Menu ");
            Console.WriteLine("---\t----\t----\t-----\t");
            


        }

        public Payroll NewPayroll()
        {
            Payroll p = new Payroll();
            Console.WriteLine("Enter the Id :");
            p.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Employee Id:");
            p.Employeeid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Number of Hours:");
            p.Hours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the  Hourly Rate:");
            p.Hourlyrate = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Date for Payroll:");
            p.Date = Console.ReadLine();

            return p;
        }
        public void printpr(List<Payroll> pr)
        {
            var P= from x in pr
                    select x;

            foreach (var y in P)
            {
                Console.WriteLine($"----------------------" +
                    $"\nId :{y.Id}\nEmployeeId :{y.Employeeid}\nHours:{y.Hours}" +
                    $"\nHourlyRate:{y.Hourlyrate}\nDate:{y.Date}\n");
            }
            Console.WriteLine("---\t----\t-List of All Payrolls---\t-----\t");
        }
        public void seachPayroll(List<Payroll> pr , List<Employee>elist , int ans)
        {
            var search = from e1 in elist
                         join p1 in pr
                             on e1.Id equals ans
                         where p1.Id == ans
                            
                         select new
                         {
                             Emp_Name = e1.Name,
                             Emp_Hours = p1.Hours,
                             Emp_HourlyRate = p1.Hourlyrate
                         };
            foreach(var x in search)
            {
                Console.WriteLine("----------Payroll Search----");
                Console.WriteLine($"Name of Employee:{x.Emp_Name}" +
                    $"\nHours of Employee:{x.Emp_Hours}\nHourlyRate :{x.Emp_HourlyRate} ");
            }
            
            Console.WriteLine("\n");
        }
        public void PrintVacationMenu()
        {
            Console.WriteLine("-------Vacation Days Menu--------");
            Console.WriteLine("Press 1 to View Vacation Days of All Employee");
            Console.WriteLine("Press 2 to Search for Vacation Days of an Employee");
            Console.WriteLine("Press 3 to return to Main Menu");
            Console.WriteLine("---\t----\t----\t-----\t");
            
        }
        
        public Boolean CheckEmployeeId(List<Employee>list, int id)
        {
            Boolean t = true;
            var P = from x in list
                    where x.Id == id
                    select x;
            foreach(var y in P)
            {
               
                return t = false;
                Console.WriteLine("Employee with this ID already Exist");
            }
            
            return t;
        }
        public void PrintVacationDays(List<Vacation> list)
        {
            var l = from x in list
                    select x;

            foreach (var y in l)
            {
                Console.WriteLine($"----------------------" +
                    $"\nId :{y.Id}\nEmployeeId :{y.Employeeid}\nNumberofDays:{y.Numberofdays}");
            }
            Console.WriteLine("---\t----\t-List of All Vacation Days---\t-----\t");
            Console.WriteLine("\n");

        }

        
        public void seachVacation(List<Vacation> vr, List<Employee> elist, int ans)
        {
            var search = from e1 in elist
                         join p1 in vr
                             on e1.Id equals ans
                         where p1.Employeeid == ans

                         select new
                         {
                             Emp_Name = e1.Name,
                             Emp_Vacation =  p1.Numberofdays,
                             
                         };
            foreach (var x in search)
            {
                Console.WriteLine("----------Vacation Search----");
                Console.WriteLine($"Name of Employee:{x.Emp_Name}" +
                    $"\nNumber of Vacation Days available:{x.Emp_Vacation}");

            }
          
            Console.WriteLine("\n");
        }
        public void addvacationdays(List<Employee> elist, int id,int vid,List<Vacation> vlist) {

            var vaca = from e1 in elist
                       where e1.Id== id
                       select new
                       {
                           Vcdays = 14,
                           Employ_id = id,
                           vid = vid

        };
            foreach(var y in vaca)
                {

                vlist.Add(new Vacation(y.vid, y.Employ_id, y.Vcdays));
                }


        }
        
        public void UpdateVacation(List<Vacation> vlist, int id)
        {
            var emp = from l in vlist
                         where l.Employeeid == id
                         select l;
            
            foreach (var u in emp) {

                u.Numberofdays += 1;
          
            }
            
           
        }


    }
}
