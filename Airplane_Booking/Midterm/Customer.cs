using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
    class Customer
    {
        private int id;
        private string name;
        private string email;
        private string address;
        private string phone;

        public static List<Customer> clist = new List<Customer>();

        public Customer(int id,string name,string email,string address,string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
        }
        public Customer() { }

        public int Id {
            get { return this.id; }
            set { this.id = value; }   
        }

        public string Name {
            get { return this.name; }
            set { this.name = value; }

        }

        public string Email {
            get { return this.email; }
            set { this.email = value; }
        }
        public string Address{
            get { return this.address; }
            set { this.address = value; }        
        }
        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

       
        public override string ToString()
        {
            return $"Id:{Id}\tName:{Name}\tEmail:{Email}\tAddress:{Address}\tPhone:{Phone}";
        }

        public static void AddDefaults()
        {
            clist.Add(new Customer(1, "Daksh", "iamdaksh@gmail.com", "24 credil St", "4568222990"));
            clist.Add(new Customer(2, "John", "iamjohn@gmail.com", "15 Steeles av", "1562201022"));
            clist.Add(new Customer(3, "Odi", "iamdaksh@gmail.com", "24 credil St", "656889990"));
            
        }
    }
}
