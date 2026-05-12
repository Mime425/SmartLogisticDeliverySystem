using SmartLogisticsDelieverySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject
{
  public class Truck : Vehicle
    {
        private double fuelConsumption;

        public Truck(int id, string name, double currentLoad, double speed, double maxCapacity, bool isAvailable, double fuelConsuption) : base(id, name, currentLoad, speed, maxCapacity, isAvailable)
        {
            this.fuelConsumption = fuelConsumption;
           
        }

        //get
        public double GetFuelConsumption()
        {
            return fuelConsumption;
        }

        public override void Deliver(List<Package> packages)
        {
            Console.WriteLine(GetName() + "handling heavy packages");
            foreach (Package package in packages)
            {
                if (package.isHeavy() && package.status == "pending") 
                {
                    package.UpdateStatus("package has been delievered.");
                    Console.WriteLine("Truck has delivered heavy package: " +  GetId() + "to" + package.destination);
                }
            }
        }

        public override double CalculateFuelEfficiency()
        {
            return base.CalculateFuelEfficiency() / fuelConsumption;
        }
    }
}