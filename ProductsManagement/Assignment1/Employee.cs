using System;
using System.Collections.Generic;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Assignment1
{
    class Employee
        // Declaration of new CLass Empoyee with Following data Membes
    {
        private int id;
        private string name;
        private string address;
        private string email;
        private string phone;
        private string role;

        
        public Employee(int id,string name,string address,string email,string phone,string role)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
            Role = role;

        }
        public Employee()
        {

        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Address {

            get { return this.address; }
            set { this.address = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string Phone {

            get { return this.phone; }
            set { this.phone = value; }
        
        
}
        public string Role {

            get { return this.role; }
            set { this.role = value; }
        }

    }
}