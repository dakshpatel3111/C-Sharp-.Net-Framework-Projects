using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Payroll
    // Declaration of new CLass Payroll with Following data Membes
    {
        private int id;
        private int employeeid;
        private int hours;
        private double hourlyrate;
        private string date;


        public Payroll(int id,int employeid,int hours,double hourlyrate,string date)
        {

            Id = id;
            Employeeid = employeeid;
            Hours = hours;
            Hourlyrate = hourlyrate;
            Date = date;

        }
        public Payroll()
        {

        }


        public int Id {

            get { return this.id; }
            set { this.id = value; }
        }
        public int Employeeid {

            get { return this.employeeid; }
            set { this.employeeid = value; }
        }

        public int Hours {

            get { return this.hours; }
            set { this.hours = value; }
        }

        public double Hourlyrate {

            get { return this.hourlyrate; }
            set { this.hourlyrate = value; }
        
        }
        public string Date {

            get { return this.date; }
            set { this.date = value; }
        }
    }

   
}
