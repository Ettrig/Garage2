using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GarageProject
{
    //Garage contains only Vehicle, so the generic type is pointless
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private int capacity;
        public int Capacity { get => capacity; set => capacity = value; }
        private int count;
        public int Count { get => count; set => count = value; }
        protected Vehicle[] vehicles;

        public Garage(int cap)
        {
            capacity = cap;
            vehicles = new Vehicle[capacity];
        }

        class GarageEnumerator<Vehicle> : IEnumerator<Vehicle>
        {
            Vehicle[] vehicls;
            int currentIndex = -1; 

            public GarageEnumerator(Vehicle[] vehicles)
            {
                vehicls = vehicles; 
            }

            public Vehicle Current
            {
                get
                {
                    if (currentIndex == -1) throw new InvalidOperationException();
                    else return vehicls[currentIndex];
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                return;
            }

            public bool MoveNext()
            {
                if (currentIndex == vehicls.Length) return false;
                currentIndex = currentIndex+1;
                while (currentIndex < vehicls.Length && vehicls[currentIndex] == null)
                {
                    currentIndex = currentIndex + 1;
                }
                if (currentIndex == vehicls.Length) return false;
                else return true; 
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }

        // It is stated that T is Vehicle in this class
        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>) new GarageEnumerator<Vehicle>(vehicles);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool AddVehicle(Vehicle theVehicle)
        {
            int i=0; 
            // GarageHandler 
            while (i<capacity && vehicles[i] != null) i++;
            if (i >= capacity) return false;
            else
            {
                vehicles[i] = theVehicle;
                count = count + 1;
                return true;
            } 
        }

        private int FindVehicleIndex(string license)
        {
            int i = 0;
            while (i < capacity && (vehicles[i] == null || vehicles[i].License != license)) i++;
            if (i >= capacity) return -17;
            return i; 
        }

        public bool RemoveVehicle( string license)
        {
            var indx = FindVehicleIndex(license);
            if (indx<0) return false;
            vehicles[indx] = null;
            return true; 
        }

        public Vehicle FindVehicle( string license)
        {
            int i = FindVehicleIndex(license);
            if (i < 0) return null;
            return vehicles[i]; 
        }
    }
}
