using SmartLogisticsDelieverySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject
{
  public  abstract class Vehicle : Entity
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

        public virtual double CalculateEfficiency()
        {
            return speed / maxCapacity;
        }

        public  void Deliver(List<Package> packages)
        {

        }
    }
}