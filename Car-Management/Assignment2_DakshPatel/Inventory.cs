using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Assignment2_DakshPatel
{
    class Inventory
    {
        // Variables to Access the Inventory Class
        private int iid;
        private int vid;
        private int numberonhand;
        private int price;
        private int cost;

        public Inventory()
        {

        }
        public Inventory(int iid,int vid,int numberonhand,int price, int cost) {
            Iid = iid;
            Vid = vid;
            Numberonhand = numberonhand;
            Price = price;
            Cost = cost;
        }

        public int Vid
        {
            get { return this.vid; }
            set { this.vid = value; }
        }
        public int Iid
        {
            get { return this.iid; }
            set { this.iid = value; }
        }
        public int Numberonhand
        {
            get { return this.numberonhand; }
            set { this.numberonhand = value; }
        }
        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public int Cost
        {
            get { return this.cost; }
            set { this.cost = value; }
        }

        // Inventory Menu 
        public void Inventorymenu()
        {
            Console.WriteLine("Welcome,Choose from the Following:");
            Console.WriteLine("Press 1. Insert into  Inventory ");
            Console.WriteLine("Press 2. View Inventory for a Vehicle");
            Console.WriteLine("Press 3. Edit Inventory ");
            Console.WriteLine("Press 4. Delete Inventory ");
            Console.WriteLine("Press 5. Exit to Main menu ");

        }
        // Inventory to Add 
        public Inventory addInventory()
        {
           
                Console.WriteLine("Add new Inventory");
                Console.WriteLine("Enter the Id of the Inventory Item (Should be unique):");
                int iid = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Id of the Vehicle:");
                int vid = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Number on Hand of the Inventory Item:");
                int numberonhand = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter Price of the Item:");
                int price = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter Cost of the Item:");
                int cost = Int32.Parse(Console.ReadLine());
            
           
            Inventory i = new Inventory(iid,vid, numberonhand, price, cost);
            return i;
        }
        // Edit inventory 
        public Inventory editInventory()
        {
            
                Console.WriteLine("Edit Old Inventory");
                Console.WriteLine("Enter the Id of the Inventory Item (Should be unique):");
                int iid = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Id of the Vehicle:");
                int vid = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Number on Hand of the Inventory Item:");
                int numberonhand = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter Price of the Item:");
                int price = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter Cost of the Item:");
                int cost = Int32.Parse(Console.ReadLine());
            
            Inventory i = new Inventory(iid, vid, numberonhand, price, cost);
            return i;
        }
    }
}
