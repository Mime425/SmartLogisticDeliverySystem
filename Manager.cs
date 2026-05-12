using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartLogisticsDelieverySystem
{
     public class Manager : Worker
    {
        private int teamSize;

        public Manager(int teamSize, string name, int id, int experienceYears, int taskCompleted, bool isAvailable) : base(name, id, experienceYears, taskCompleted, isAvailable)
        {
            this.teamSize = teamSize;
        }

        public int getTeamSize()
        {
            return teamSize;    
        }

        public override void PerformTask()
        {
            Console.WriteLine($"{GetName} is assigning tasks to their team of {teamSize} members");
            AddTask();
        }

        public Worker FindBestWorker(List<Worker> workers)
        {
            Worker bestWorker = workers[0];

            foreach (Worker worker in workers)
            {
                if (worker.CalculatePerformance() > bestWorker.CalculatePerformance())
                {
                    bestWorker = worker;
                }
            }
            return bestWorker;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Name : {GetName()}, Manager Id: {GetId()}," +
                $"Experience years: {GetExperienceYears()}," +
                $" Tasks completed : {GetTasksCompleted()} + IsAvailable:  {GetIsAvailable}," + "Performance:" +
                 CalculatePerformance());
        }

    }

}
