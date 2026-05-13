using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartLogisticsDelieverySystem
{
    public class Loader : Worker
    {
        private double maxLiftWeight;

        public Loader(double maxLiftWeight, string name, int id, int experienceYears, int taskCompleted, bool isAvailable) : base(name, id, experienceYears, taskCompleted, isAvailable)
        {
            this.maxLiftWeight = maxLiftWeight;
        }

        public double GetMaxLiftWeight()
        { 
            return this.maxLiftWeight;
        }

        public override void PerformTask()
        {
            Console.WriteLine($"{GetName} is loading packages up to {maxLiftWeight} kg");
            AddTask();
        }

        public override void DisplayInfo()
        {
                Console.WriteLine($"Max Lift Weight: {this.maxLiftWeight}, Name: {GetName()}," +
                    $" Loader id: {GetId}, Experience Years: {GetExperienceYears}," +
                    $" TaskCompleted: {GetTasksCompleted}, Is Available: {GetIsAvailable} ");
        }

    }

}

