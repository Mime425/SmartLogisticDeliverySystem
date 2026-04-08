using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartLogisticsDelieverySystem
{
    abstract class Drone : Vehicle
    {
        //attribute
        private double maxDistance;
        private int smallPackages;

        //constructor
        public Drone(int id, string name, double currentLoad, double speed, double maxCapacity, bool isAvailable, int smallPackages) : base(id, name, currentLoad, speed, maxCapacity, isAvailable)
        {
            this.maxDistance = maxDistance;
            this.smallPackages = smallPackages;
        }

        //Methods

        //Deliver method
        public override void Deliver(List<Package> packages)
        {

            Console.WriteLine("The drone is delivering packages");
            

            for (int i = 0; i < packages.Count;
              i++)
            {

                int num = i +  1;
                Console.WriteLine("Package" + num + "is being delivered");
            }
            Console.WriteLine("The drone delivered all the packages");

            //Condition
            if (smallPackages <= 5)
            {
                Console.WriteLine("Package is being delivered by the drone");


            }
            else
            {
                Console.WriteLine("Package cannot be livered by the drone");
            }


        }

        //Calculate efficiency method

        public virtual double CalculateEfficiency() 
        {
            //Console.WriteLine("Packages delivered based on distance");

            return maxDistance;

        }

        

    }
}
