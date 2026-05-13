using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogisticsDelieverySystem
{
    public abstract class Vehicle : Entity
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

        //getter
        public double GetSpeed() 
        {
            return speed;
        }

        public double GetMaxCapacity()
        {
            return maxCapacity;
        }

        public double GetCurrentLoad()
        {
            return currentLoad; 
        }

        public bool GetIsAvailable()
        {
            return isAvailable;
        }

        public void SetSpeed(double speed)
        {
            this.speed = speed;
        }

        public void SetCapacity(double capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than zero.");
            }
            this.maxCapacity = capacity;
        }
        public void SetCurrentLoad(double currentLoad)
        {
            this.currentLoad = currentLoad;
        }

        public void SetIsAvailable(bool isAvailable) 
        {
            this.isAvailable = isAvailable;
        }

        public double GetRemainingCapacity()
        {
            return maxCapacity - currentLoad;
        }

        public virtual double CalculateFuelEfficiency()
        {
            if (speed == 0)
            {
                Console.WriteLine("Speed cannot be 0");
                return 0;
            }

            return speed / currentLoad;
        }

        //Function for delivering packages
        public abstract void Deliver(List<Package> packages);


        public override void DisplayInfo()
        {
            Console.WriteLine("Vehicle id: " + GetId() + " , Name: "
                + GetName() + " , Speed: " + GetSpeed() + "km/h" + " , Max Capcity :" +
                GetMaxCapacity() + "kg" + " , Current Load: " + GetCurrentLoad() + "kg");
        }


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
