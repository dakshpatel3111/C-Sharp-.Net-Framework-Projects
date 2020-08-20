using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
    class Airline
    {
        public static List<Airline> alist = new List<Airline>();
        private int id;
        private string name;
        private string airplane;
        private int seats;
        private string meals;

        public Airline(int id, string name,string airplane,int seats,string meals)
        {
            Id = id;
            Name = name;
            Airplane = airplane;
            Seats = seats;
            Meals = meals;
        }
        public Airline()
        {

        }
        public int Id {

            get { return this.id; }
            set { this.id = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Airplane
        {
            get { return this.airplane; }
            set { this.airplane = value; }
        }
        public int Seats
        {
            get { return this.seats; }
            set { this.seats = value; }
        }
        public string Meals
        {
            get { return this.meals; }
            set { this.meals = value; }
        }

        public override string ToString()
        {
            return $"Id:{Id}\tName:{Name}\tAirplane:{Airplane}\tSeatsAvailable:{Seats}\tMealsAvailable:{Meals}";
        }

        public static void getairlines()
        {
           

              alist.Add(new Airline(1,"AirCanada","Boeing-777",2,"Vegeterian"));
            alist.Add(new Airline(2, "AirIndia", "Boeing-777", 10, "Vegeterian"));

            alist.Add(new Airline(3, "Dutchlines", "AirBus320", 2, "Non-Vegeterian"));

            

           
        }
    }
}
