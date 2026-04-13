using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartLogisticsDelieverySystem
{
    public abstract class Driver : Worker
    {
        private string licenseType;

        public Driver(string name, int id, int experienceYears, int taskCompleted, bool isAvailable, string licenseType) : base(name, id, experienceYears, taskCompleted, isAvailable)
        {
            this.licenseType = licenseType;
        }

        public override void PerformTask()
        {
            Console.WriteLine($"{name} is delivering deliveries with a {licenseType} license");
            AddTask();
        }
    }

}
