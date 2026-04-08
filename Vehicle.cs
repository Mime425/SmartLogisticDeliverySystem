using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogisticsDelieverySystem
{
    abstract class Vehicle : Entity
    {

        private double speed;
        private double maxCapacity;
        private double currentLoad;
        private bool isAvailable;

        public Vehicle(int id, string name, double currentLoad, double speed, double maxCapacity, bool isAvailable) : base(id, name)
        {
            this.speed = speed;
            this.maxCapacity = maxCapacity;
            this.currentLoad = currentLoad;
            this.isAvailable = true;
        }

        public void SetCapacity(double capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than zero.");
            }
            this.maxCapacity = capacity;
        }

        public double GetRemainingCapacity()
        {
            return maxCapacity - currentLoad;
        }

        public virtual double CalculateFuelEfficiency()
        {
            return speed / maxCapacity;
        }

        //Function for delivering packages\
        public abstract void Deliver(List<Package> packages);
        
        //{
        //    //Console.WriteLine("The trucks is delivering packages.");

        //    //for (int i = 0; i < packages.Count;
        //    //    i++)
        //    //{

        //    //    int num = i;
        //    //    Console.WriteLine("Package" + num + "is being delivered" );
        //    //}

        //    //Console.WriteLine("The package has been delivered");

        //}

        


    }
}
