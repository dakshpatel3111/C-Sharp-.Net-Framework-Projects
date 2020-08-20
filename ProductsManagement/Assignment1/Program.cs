using System;
using System.Collections.Generic;

using System.Linq;


namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating the Class object to get access to all methods from Db_access
            Db_Access db = new Db_Access();

            // Initializing a list with 4 new Employee Classes
            List<Employee> em = new List<Employee>
            {
                new Employee(1,"Daksh","258 Mill st","daksh@email.com","610101010","President"),
                new Employee(2,"Deep","258 Mill st","deep@email.com","612929222","Manager"),
                new Employee(3,"Snehal","Bharuch,Gujrat","Snehal@email.com","09292929","Manager"),
                new Employee(4,"Om","London,UK","OmBhadvo@email.com","999996999","Watchmen"),
                new Employee(5,"John","Hamilton,ON","iamjohn@gmail.com","429291190","Janitor")

            };
            
            // Initialzing  a list for Payrolls
            List<Payroll> prlist = new List<Payroll>
            {
                new Payroll(1,1,500,22.05,"2020-06-15"),
                new Payroll(2,2,200,50.05,"2020-08-20"),
                new Payroll(3,3,500,30.05,"2020-09-20"),
                new Payroll(4,4,500,20.05,"2020-09-10"),
                new Payroll(5,5,200,14.05,"2020-10-10")
            };

            // Initializing a list for Vacation Days
            List<Vacation> vclist = new List<Vacation>
            {
                
            };

            // Adding by default vacations for Employeers initialized in list
              db.addvacationdays(em,1,1,vclist);
              db.addvacationdays(em, 2, 2, vclist);
              db.addvacationdays(em, 3, 3, vclist);
              db.addvacationdays(em, 4, 4, vclist);

           // Adding Vacation for By default added payrolls 
            db.UpdateVacation(vclist, 1);
            db.UpdateVacation(vclist, 2);
            db.UpdateVacation(vclist, 3);
            db.UpdateVacation(vclist, 4);
            db.UpdateVacation(vclist, 5);





            // Loop for Main Menu 
            while (true)
            {
                // Printing Main Menu
                db.PrintMainMenu();
                string input = Console.ReadLine();
                // For Employee Modifications
                if (input.Equals("1"))
                {
                    db.PrintEmployeeMenu();
                    input = Console.ReadLine();
                    switch (input)
                    {
                        // To print all the Employee List
                        case "1":
                            db.PrintEmployeeList(em);
                            break;
                            // to Add new Employee in the list
                        case "2":
                            Employee e = db.AddEmployee();
                            em.Add(e);
                            // TO check if the Employee Id exist 
                            db.CheckEmployeeId(em, e.Id);
                            Console.WriteLine("---------Employee Updated-------");
                            db.PrintEmployeeList(em);
                            db.addvacationdays(em,e.Id,vclist.Count+1,vclist);
                            break;
                            // To Search and Modify employee Contents
                        case "3":
                            Console.WriteLine("Enter the Appropriate Id to Modify:");
                            string ans = Console.ReadLine();
                            db.UpdateEmployee(em, ans);
                            break;
                            // To remove the Employee from the List
                        case "4":
                            Console.WriteLine("Enter the Appropriate Id:");
                            int ss = int.Parse(Console.ReadLine());
                            var del = from x in em
                                      where x.Id == ss
                                      select x;
                            foreach (var y in del)
                            {
                                int index = em.FindIndex(y => y.Id == ss);
                                em.RemoveAt(index);
                            }
                            Console.WriteLine("--------- List Updated-----");
                            db.PrintEmployeeList(em);
                            break;
                            //to Get the Main Menu
                        case "5":
                            continue;
                            break;
                            // for Invalid Input
                        default:
                            Console.WriteLine("Invalid Input");
                            break;

                    }
                }
                // Menu to Change and Edit Payrolls
                else if (input.Equals("2"))
                {
                    // Main menu for Payroll 
                    db.PrintPayrollMenu();
                    input = Console.ReadLine();

                    switch (input)
                    {
                        // To add new Payroll
                        case "1":
                            Payroll p = db.NewPayroll();
                            prlist.Add(p);
                            // Update the vacation Days on payroll of an Employee
                            db.UpdateVacation(vclist, p.Employeeid);
                            db.printpr(prlist);
                            break;

                        // to Serch the Payrolls with EmployeeId
                        case "2":
                            Console.WriteLine("Enter the EmployeeId You need to Search");
                            int ans = int.Parse(Console.ReadLine());
                            db.seachPayroll(prlist, em, ans);
                            break;
                        // To Exit to Main Menu 
                        case "3":
                            continue;
                            break;
                        //When User enters invalid Input
                        default:
                            Console.WriteLine("Invaid Input ");
                            break;

                    }


                }
                //  selecting the vacation menu
                else if (input.Equals("3"))
                {
                    // Printing Vacation Menu
                    db.PrintVacationMenu();
                    input = Console.ReadLine();

                    switch (input)
                    {
                        //  To print all the vacation Days of all employees
                        case "1":
                            
                            //
                            db.PrintVacationDays(vclist);
                            break;
                            // To search for the Vacation days with employee Id
                        case "2":
                            Console.WriteLine("Enter a Id to Search Vacation Days");
                            int vans = int.Parse(Console.ReadLine());
                            if (db.CheckEmployeeId(em, vans))
                            {
                                Console.WriteLine("Employee Id does not exist");
                            }
                            db.seachVacation(vclist, em, vans);
                            break;
                            //to go back to Main menu 
                        case "3":
                            continue;
                            break;
                            // For invalid input and user gets Exited
                        default:
                            Console.WriteLine("Invalid Input");
                            continue;
                            break;
                    }
                }
                // if user opts to exit the Program 
                if (input.Equals("4"))
                {
                    Console.WriteLine("You have Been Exited");
                    break;

                }




            }
        }
       
    }
}
