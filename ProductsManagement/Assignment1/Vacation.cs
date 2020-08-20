using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Vacation
    // Declaration of new CLass Vacation with Following data Membes
    {
        private int id;
        private int employeeid;
        private int numberofdays;

        public Vacation()
        {

        }
        public Vacation(int id,int employeeid,int numberofdays)
        {
            Id = id;
            Employeeid = employeeid;
            Numberofdays = numberofdays;
        }
       public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public int Employeeid
        {
            get { return this.employeeid; }
            set { this.employeeid = value; }
        }

        public int Numberofdays {

            get { return this.numberofdays; }
            set { this.numberofdays = value; }
        }

        public override string ToString()
        {
            return Id+", "+Numberofdays+", "+Employeeid;
        }
    }
}
