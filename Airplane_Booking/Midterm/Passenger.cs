using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Midterm
{
    class Passenger
    {
        public static List<Passenger> plist = new List<Passenger>();
        private int id;
        private int customerId;
        private int flightId;

        public Passenger(int id,int customerId,int flightId)
        {
            Id = id;
            CustomerId = customerId;
            FlightId = flightId;
        }
        public Passenger()
        {

        }
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public int CustomerId {
            get { return this.customerId; }
            set { this.customerId = value; }
        }
        public int FlightId
        {
            get { return this.flightId; }
            set { this.flightId = value; }
        }
        public override string ToString()
        {
            return $"Id:{Id}\tCustomerId:{CustomerId}\tFlightId:{FlightId}";
        }

        public static void getpassengerlist()
        {
           
               plist.Add( new Passenger(1,1,1));
                plist.Add(new Passenger(2, 2, 2));
                plist.Add(new Passenger(3, 3, 3));
 
            
        }
    }
}
