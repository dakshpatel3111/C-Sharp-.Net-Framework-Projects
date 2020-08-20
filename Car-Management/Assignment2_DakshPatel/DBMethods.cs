using Microsoft.Extensions.Configuration;
using System;

using System.Data.SqlClient;
using System.IO;


namespace Assignment2_DakshPatel
{
    class DBMethods
    {
        // Creating the CLass objects globally to access the methods across the programs
        Vehicle v = new Vehicle();
        Inventory i = new Inventory();
        Repair r = new Repair();
        // Method to get the connection string
        static string GetConnectionString(string connectionStringName)
        {
            //linking the json file available in directory
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("config.json");
            IConfiguration config = configurationBuilder.Build();
            return config["ConnectionStrings:" + connectionStringName];


        }
        
        public  void printVehicle()
        {
            //SQL query to get all data from Vehicle   
            string query = "Select id,make,model,year,type from Vehicle";
            // Get connection string mehod to get the data from json 
            string cs = GetConnectionString("NorthwindMDF");
            //Creating the connection 
            using (SqlConnection conn = new SqlConnection(cs))
            {

                try
                {
                    // Creating sql command object with query and connection parameters
                    SqlCommand cmd = new SqlCommand(query, conn);
                    // Opening the connection 
                    conn.Open();
                    //Creating reader object to read  the data from query result
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine($"|ID|\t|Make|\t|Year|\t|Type|");
                    // Loop which loops will the end of last row
                    while (reader.Read())
                    {
                        // Storing the data into variables from row
                        int id = reader.GetInt32(0);
                        string make = reader.GetString(1);
                        string model = reader.GetString(2);
                        int year = reader.GetInt32(3);
                        string type = reader.GetString(4);
                        // Displaying the variables
                        Console.WriteLine($"{id}\t{make}\t{model}\t{year}\t{type}");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Item not found or Invalid Input");
                    Console.WriteLine(ex.Message);
                }

            }
        }
        // Function to print the main menu 
        public void mainmenu()
        {
            //Console print statements
            Console.WriteLine("Welcome,Choose from the Following:");
            Console.WriteLine("Press 1. To Modify Vehicles");
            Console.WriteLine("Press 2. To Modify Inventory");
            Console.WriteLine("Press 3. To Modify Repairs");
            Console.WriteLine("Press 4. To Exit Program");
        }
        // Method to add the vehicle to the database
       public void addvtodb()
        {
            // Creating a vehicle object 
            Vehicle vb = new Vehicle();
            // Executing the add vehicle method to get user data
             vb = v.addvehicle();   
            // Creating a insert query with parameters
            string cmdString = "INSERT INTO Vehicle (id, make ,model ,year , type) VALUES (@vid, @make, @model, @year, @type)";
            // get connection string  from json
            string connString = GetConnectionString("NorthwindMDF");
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    // Creating object of commad and connection 
                    cmd.Connection = con;
                    cmd.CommandText = cmdString;
                    // Adding the parameters to the query  from user
                    cmd.Parameters.AddWithValue("@vid", vb.Vid);
                    cmd.Parameters.AddWithValue("@make", vb.Make);
                    cmd.Parameters.AddWithValue("@model", vb.Model);
                    cmd.Parameters.AddWithValue("@year", vb.Year);
                    cmd.Parameters.AddWithValue("@type", vb.Type);
                    try
                    {
                        // Opening the COnnection and Executing the query
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("----------------------Row has Been Insterd into Vehicle");
                    }
                    catch (SqlException ex)
                    {
                        // Exception handling 
                        Console.WriteLine("Invalid Data");
                        Console.WriteLine(ex.Message);
                    }


                }
            }
        }
        // Method to edit vehicle
        public void editvehicle()
        {
            //Taking the id from user to edit it and storing it into var
            Console.WriteLine("Enter the Id You want to Update:");
            int oldid = Int32.Parse(Console.ReadLine());
            // Creating the vehicle object 
            Vehicle vb = new Vehicle();
            // Taking all the new vehicle information to replace it with old details
            vb = v.Updatevehicle();
            // declaring the string with parameters of update
            string cmdString = "Update Vehicle Set  id = @vid,make =  @make, model = @model, year = @year, type= @type  where id = @oldid";
            string connString = GetConnectionString("NorthwindMDF");
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    // Getting the connection and command object to execute the query
                    cmd.Connection = con;
                    cmd.CommandText = cmdString;
                    // adding the new values as parameter
                    cmd.Parameters.AddWithValue("@vid", vb.Vid);
                    cmd.Parameters.AddWithValue("@make", vb.Make);
                    cmd.Parameters.AddWithValue("@model", vb.Model);
                    cmd.Parameters.AddWithValue("@year", vb.Year);
                    cmd.Parameters.AddWithValue("@type", vb.Type);
                    // Adding the id of the row of vehicle which user wants to edit
                    cmd.Parameters.AddWithValue("@oldid", oldid);
                    try
                    {
                        // Opening the connection 
                        con.Open();
                        // Executing the query
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("----------------------Row has been Updated in Vehicle ...!!");
                    }
                    catch(SqlException ex)
                    {
                        //Exception handling not found 
                        Console.WriteLine("Item not Found");
                    }


                }
            }
        }
        //  Delete the Vehicle Method from the Database
        public void deletevehicle()
        {
            // Taking the id of the row to delete the Data 
            Console.WriteLine("Enter the Id You want to Delete:");
            int oldid = Int32.Parse(Console.ReadLine());
            // query to delete the vehicle row with the id
            string cmdString = "Delete from  Vehicle where id = @oldid";
            string connString = GetConnectionString("NorthwindMDF");
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    // Creating the connection object
                    cmd.Connection = con;
                    cmd.CommandText = cmdString;
                   //Adding the id taken from user to the  query with parameter
                    cmd.Parameters.AddWithValue("@oldid", oldid);
                    try
                    {
                        // Opening the query and executing it 
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("----------------------Row has been Deleted in Vehicle !!");
                    }
                    catch (SqlException ex)
                    {
                        // Exception handling for SQL
                        Console.WriteLine("Item not Found");
                    }


                }
            }
        }
        // Database methods for Inventory

        // Print all the data from inventory with the Vehicle information 
        public void printInventory()
        {
            string query = "Select I.iid,vid,V.make,V.model,V.year,numberonhand,price,cost from Inventory I Inner Join Vehicle V On V.id = I.vid ";
            string cs = GetConnectionString("NorthwindMDF");

            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    // Reader to display the Data 
                    Console.WriteLine($"|ID|\t|VehicleID|\t|Make|\t|Model|\t|Year|\t|NumberonHand\t|Price|\t|Cost|");
                    while (reader.Read())
                    {
                        // Storing the reader data into variable then displaying them 
                        int id = reader.GetInt32(0);
                        int vid = reader.GetInt32(1);
                        string make = reader.GetString(2);
                        string model = reader.GetString(3);
                        int year = reader.GetInt32(4);
                        int numberonhand = reader.GetInt32(5);
                        int price = reader.GetInt32(6);
                        int cost = reader.GetInt32(7);
                        Console.WriteLine($"{id}\t{vid}\t\t{make}\t{model}\t{year}\t\t{numberonhand}\t{price}\t{cost}");
                    }
                }
                catch (SqlException ex)
                {
                    // Exception handling
                    Console.WriteLine("Entered Data is invalid "); 
                    Console.WriteLine(ex.Message);
                }

            }
        }

      
        // Printing the Inventory of specific vehicle entered by the user
        public void printinvenotrywithvid()
        {
           // Taking the id to search 
            Console.WriteLine("Enter the Id You want to Search:");
            int svid = Int32.Parse(Console.ReadLine());
            // Search query to search data from table
            string cmdString = "Select I.iid,vid,V.make,V.model,V.year,numberonhand,price,cost from Inventory I Inner Join Vehicle V On V.id = I.vid where V.id = @id";
            string connString = GetConnectionString("NorthwindMDF");
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = cmdString;
                    // adding the parameters to the sql command
                    cmd.Parameters.AddWithValue("@id", svid);
                    try
                    {
                        // getting the connection open 
                        con.Open();
                        // Executing the query 
                        cmd.ExecuteNonQuery();
                        //Creater Reader varible after execution
                        SqlDataReader reader = cmd.ExecuteReader();
                        Console.WriteLine($"|ID|\t|VehicleID|\t|Make|\t|Model|\t|Year|\t|NumberonHand\t|Price|\t|Cost|");
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            int vid = reader.GetInt32(1);
                            string make = reader.GetString(2);
                            string model = reader.GetString(3);
                            int year = reader.GetInt32(4);
                            int numberonhand = reader.GetInt32(5);
                            int price = reader.GetInt32(6);
                            int cost = reader.GetInt32(7);
                            Console.WriteLine($"{id}\t{vid}\t\t{make}\t{model}\t{year}\t\t{numberonhand}\t{price}\t{cost}");
                        }
                       
                    }
                    catch (SqlException ex)
                    {
                        // Exception handling 
                        Console.WriteLine("Item not Found");
                    }


                }
            }
        }
        // Method to add the inventory to the database
        public void addinventory()
        {
            // Creating the inventory object to get the data from user 
            Inventory im = new Inventory();
            im = i.addInventory();
            string cmdString = "INSERT INTO Inventory (iid,vid,numberonhand,price,cost) VALUES (@iid, @vid, @numberonhand,@price,@cost)";
            string connString = GetConnectionString("NorthwindMDF");
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = cmdString;
                    com.Parameters.AddWithValue("@iid", im.Iid);
                    com.Parameters.AddWithValue("@vid", im.Vid);
                    com.Parameters.AddWithValue("@numberonhand", im.Numberonhand);
                    com.Parameters.AddWithValue("@price", im.Price);
                    com.Parameters.AddWithValue("@cost", im.Cost);
                    try
                    {
                        con.Open();
                        com.ExecuteNonQuery();
                        Console.WriteLine("-------------------------Row has been Inserted in Inventory Table !!");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                }
            }
        }
        public void editinventory()
        {
            Console.WriteLine("Enter the Id You want to Update:");
            int oldid = Int32.Parse(Console.ReadLine());
            Inventory ib = new Inventory();
            ib = i.editInventory();
            string cmdString = "Update Inventory Set  iid = @iid , vid =  @vid, numberonhand = @numberonhand, price = @price, cost= @cost  where iid = @oldid";
            string connString = GetConnectionString("NorthwindMDF");
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = cmdString;
                    cmd.Parameters.AddWithValue("@iid", ib.Iid);
                    cmd.Parameters.AddWithValue("@vid", ib.Vid);
                    cmd.Parameters.AddWithValue("@numberonhand", ib.Numberonhand);
                    cmd.Parameters.AddWithValue("@price", ib.Price);
                    cmd.Parameters.AddWithValue("@cost", ib.Cost);
                    cmd.Parameters.AddWithValue("@oldid", oldid);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("-------------------------Row has been Updated in Inventory !!");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                }
            }
        }
        public void deleteInventory()
        {
            Console.WriteLine("Enter the Id You want to Delete:");
            int oldid = Int32.Parse(Console.ReadLine());

            string cmdString = "Delete from  Inventory where iid = @oldid";
            string connString = GetConnectionString("NorthwindMDF");
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = cmdString;

                    cmd.Parameters.AddWithValue("@oldid", oldid);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("-------------------------Row has been Deleted in Inventory !!");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Item not Found");
                    }


                }
            }
        }
        // Database Methods for Repair Table
        public void printRepair()
        {
            string query = "Select I.iid,vid,V.make,V.model,V.year,numberonhand,price,cost,R.rid,R.whattorepair from Inventory I Inner Join Vehicle V On V.id = I.vid Inner Join Repair R On R.iid = I.iid ";
            string cs = GetConnectionString("NorthwindMDF");

            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine($"|RepairID|\t|Vehicleid|\t|Make|\t|Model|\t|Year|\t|NumberonHand\t|Price|\t|Cost|\t|Inventoryid|\t|WhattoRepair|");
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        int vid = reader.GetInt32(1);
                        string make = reader.GetString(2);
                        string model = reader.GetString(3);
                        int year = reader.GetInt32(4);
                        int numberonhand = reader.GetInt32(5);
                        int price = reader.GetInt32(6);
                        int cost = reader.GetInt32(7);
                        int rid = reader.GetInt32(8);
                        string whattorepair = reader.GetString(9);
                        Console.WriteLine($"{rid}\t\t{vid}\t\t{make}\t{model}\t{year}\t\t{numberonhand}\t{price}\t{cost}\t{id}\t\t{whattorepair}");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        // Edit the Repair Table Row 
        public void editRepair()
        {
            // to take the id from user 
            Console.WriteLine("Enter the Id  of Repair You want to Update:");
            int oldid = Int32.Parse(Console.ReadLine());
            //Taking all the inputs from repair class method
            Repair rb = new Repair();
            rb = r.editRepair(); 
            // query to Update the repair with parameters 
            string cmdString = "Update Repair Set  rid = @rid , iid =  @iid, whattorepair = @whattorepair  where rid = @oldid";
            // taking the connection string from json file with name northwindmd
            string connString = GetConnectionString("NorthwindMDF");
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    // Declaring the Connection object with command variable
                    cmd.Connection = con;
                    cmd.CommandText = cmdString;
                    // Adding the parameter values to the query taken from user in rb class object
                    cmd.Parameters.AddWithValue("@rid", rb.Rid);
                    cmd.Parameters.AddWithValue("@iid", rb.Iid);
                    cmd.Parameters.AddWithValue("@whattorepair", rb.Whattorepair);
                    cmd.Parameters.AddWithValue("@oldid", oldid);
                    try
                    {
                        // Opening the connection and Executing the query
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("-------------------------Row has been Updated in Repair Table!!");
                    }
                    catch (SqlException ex)
                    {
                        // Exception handling 
                        Console.WriteLine(ex.Message);
                    }


                }
            }
        }
        // Adding the new repair row to the database 
        public void addrtodb()
        {
            // Declaring Repair object 
            Repair rb = new Repair();
            //storing the user obtained from addrepair method to rb object
            rb = r.addrepair();
            // Sql query to insert the data into the repair table
            string cmdString = "INSERT INTO Repair (rid,iid,whattorepair) VALUES (@rid, @iid, @whattorepair)";
            string connString = GetConnectionString("NorthwindMDF");
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //Declaring the SQLCommand  object with Connection object
                    cmd.Connection = con;
                    cmd.CommandText = cmdString;
                    // Adding the parameter values for the query
                    cmd.Parameters.AddWithValue("@rid", rb.Rid);
                    cmd.Parameters.AddWithValue("@Iid", rb.Iid);
                    cmd.Parameters.AddWithValue("@whattorepair", rb.Whattorepair);
                    
                    try
                    {
                        // Opening the connection
                        con.Open();
                        //Executing the Query 
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("-------------------------Row has been Added in Repair Table!!");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                }
            }
        }
        //to Delelte the Repair row from Repair table with unique id of row
        public void deleterepair()
        {
            // taking input of id which user wants to delete
            Console.WriteLine("Enter the Id You want to Delete for Repair:");
            int oldid = Int32.Parse(Console.ReadLine());
            // Creating the query for delete 
            string cmdString = "Delete from  Repair where rid = @oldid";
            string connString = GetConnectionString("NorthwindMDF");
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                  
                    cmd.Connection = con;
                    cmd.CommandText = cmdString;
                    cmd.Parameters.AddWithValue("@oldid", oldid);
                    try
                    {
                        // Opeing the conection 
                        con.Open();
                        // Executing the Non query
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("-------------------------Row has been Deleted  in Repair Table!!");
                    }
                    catch (SqlException ex)
                    {
                        // Exception Handling if id is not available
                        Console.WriteLine("Item not Found");
                    }


                }
            }
        }





    }
}
