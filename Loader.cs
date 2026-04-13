using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartLogisticsDelieverySystem
{
     abstract class Loader : Worker
    {
        private double maxLiftWeight;

        protected Loader(double maxLiftWeight, string name, int id, int experienceYears, int taskCompleted, bool isAvailable) : base(name, id, experienceYears, taskCompleted, isAvailable)
        {
            this.maxLiftWeight = maxLiftWeight;
        }

        public override void PerformTask()
        {
            Console.WriteLine($"{GetName} is loading packages up to {maxLiftWeight} kg");
            AddTask();
        }
    }

}

