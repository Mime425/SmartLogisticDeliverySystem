using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartLogisticsDelieverySystem
{
     public class Driver : Worker
    {
        private string licenseType;

        public Driver(string name, int id, int experienceYears, int taskCompleted, bool isAvailable, string licenseType) : base(name, id, experienceYears, taskCompleted, isAvailable)
        {
            this.licenseType = licenseType;
        }

        public string GetLicenseType()
        {
            return licenseType;
        }

        public void SetLicenseType(string licenceType)
        {
            this.licenseType = licenceType; 
        }

        public override void PerformTask()
        {
            Console.WriteLine($"{GetName} is delivering deliveries with a {licenseType} license");
            AddTask();
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Name : {GetName()}, Driver Id: {GetId()}," +
                $"Experience years: {GetExperienceYears()}," +
                $" Tasks completed : {GetTasksCompleted()} + IsAvailable:  {GetIsAvailable}," +
                $" Licence type: {licenseType}"); 
        }



    }

}
