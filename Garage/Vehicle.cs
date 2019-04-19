using System;
using System.Collections.Generic;
using System.Text;

namespace GarageProject
{
    class Vehicle
    {
        private string license; // Must be unique
        public string License { get => license; set => license = value; }

        private string color;
        public string Color
        {
            get => color; 
            set => color = value; 
        }

        private int wheels;
        public int Wheels { get => wheels; set => wheels = value; }

        public Vehicle (string lic, string col, int whee)
        {
            license = lic;
            color = col;
            wheels = whee; 
        }
    }

    class Car : Vehicle 
    {
        int seats;
        public int Seats { get => seats; set => seats = value; }

        public Car(string lic, string col, int whee, int sea) : base(lic, col, whee)
        {
            seats = sea; 
        }
    }

    class Airplane : Vehicle
    {
        private bool isJet;
        public bool IsJet { get => isJet; set => isJet = value; }

        public Airplane(string lic, string col, int whee, bool jet) : base(lic, col, whee)
        {
            isJet = jet;
        }
    }

    class Motorcycle : Vehicle
    {
        private bool sideCar;
        public bool SideCar { get => sideCar; set => sideCar = value; }

        public Motorcycle(string lic, string col, int whee, bool sideC) : base(lic, col, whee)
        {
            sideCar = sideC;
        }
    }

    class Bus : Vehicle
    {
        private bool bend;
        public bool Bend { get => bend; set => bend = value; }

        public Bus(string lic, string col, int whee, bool hasBend) : base(lic, col, whee)
        {
            bend = hasBend;
        }
    }

    class Boat : Vehicle
    {
        private bool sail;
        public bool Sail { get => sail; set => sail = value; }

        public Boat(string lic, string col, int whee, bool hasSail) : base(lic, col, whee)
        {
            sail = hasSail;
        }
    }
}
