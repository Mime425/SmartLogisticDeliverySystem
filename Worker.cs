using SmartLogisticsDelieverySystem;

namespace SmartLogisticsDelieverySystem
{
    public abstract class Worker : Entity
    {
        private int experienceYears;
        private int taskCompleted;
        private bool isAvailable;

        public Worker(string name, int id, int experienceYears, int taskCompleted, bool isAvailable ) : base(id, name)
        {
            this.experienceYears = experienceYears;
            this.taskCompleted = taskCompleted;
            this.isAvailable = isAvailable;
        }

        public int GetExperienceYears()
        {
            return experienceYears;
        }

        public int GetTasksCompleted()
        {
            return taskCompleted;
        }

        public bool GetIsAvailable()
        {
            return isAvailable;
        }    

        public void AddTask()
        {
            taskCompleted++;
        }

        public virtual double CalculatePerformance()
        {
            return (experienceYears*2.0) + taskCompleted;  
        }

        public abstract void PerformTask();
    }
}