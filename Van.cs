using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogisticsDelieverySystem
{
     public class Van : Vehicle
    {
        //attributes 
        private bool isElectric;

        // constructor
        public Van(int id, string name, double currentLoad, double speed, double maxCapacity, bool isAvailable, bool isEletric) : base(id, name, currentLoad, speed, maxCapacity, isAvailable)
        {
            this.isElectric = isElectric;

        }

        public bool GetIsElectric() 
        {
            return isElectric;
        }

        //Medium package delieveries 
        public override void Deliver(List<Package> packages)
        {
            Console.WriteLine(GetName() + "handling medium packages");
            foreach (Package package in packages)
            {
                if (package.isHeavy() && package.status == "pending")
                {
                    package.UpdateStatus("package has been delievered.");
                    Console.WriteLine("Van has delivered medium package: " + package.id + "to" + package.destination);
                }
            }
        }

        public override string ToString()
        {
            return $"Van ID: {GetId()}, Name: {GetName()}," +
                $" SpeedL {GetSpeed()} km/h, Max Capacity: {GetMaxCapacity()} kg," +
                $" Electric Type: {GetIsElectric()}";
        }
    }

}
