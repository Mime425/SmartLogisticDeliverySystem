using SmartLogisticsDelieverySystem;

namespace SmartLogisticsDelieverySystem
{
    abstract class Worker : Entity
    {
        private int experienceYears;
        private int taskCompleted;
        private bool isAvaiable;

        public Worker(string name, int id, int experienceYears, int taskCompleted, bool isAvaiable) : base(id, name)
        {
            this.experienceYears = experienceYears;
            this.taskCompleted = taskCompleted;
            this.isAvaiable = isAvaiable;
        }

        public void AddTask()
        {
            taskCompleted++;
        }

        public virtual double CalculatePerformance()
        {
            return experienceYears + taskCompleted;
        }

        public abstract void PerformTask();
    }
}