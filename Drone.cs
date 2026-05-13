using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartLogisticsDelieverySystem
{
    public class Drone : Vehicle
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
        public double GetMaxDistance() 
        {
            return maxDistance; 
        }

        public void SetMaxDistance(double maxDistance)
            { this.maxDistance = maxDistance; }

        //Methods

        //Deliver packages using drone, and its only small delievry 
        public override void Deliver(List<Package> packages)
        {

            Console.WriteLine(GetName() + "The drone is delivering packages");

            foreach (Package package in packages)
            {
                if (package.weight <=5 && package.status == "pending")
                {
                    package.UpdateStatus("package has been delievered.");
                    Console.WriteLine("Drone has delivered small package: " + package.id + "to" + package.destination);
                }
            }


        }

        //Calculate efficiency method
        public virtual double CalculateEfficiency() 
        {
            return GetSpeed() + maxDistance;

        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Drone id:" + GetId() + "Name: " + GetName() + "Speed" + GetSpeed() + 
                              "Max capacity" + GetMaxCapacity() + "Current load: " + GetCurrentLoad() +
                                  "Max distance: " + GetMaxDistance());
        }
    }
}
