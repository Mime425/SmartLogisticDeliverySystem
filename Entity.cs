using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogisticsDelieverySystem
{
    abstract class Entity
    {
        private int id;
        private string name;
        private DateTime createdDate;

        public Entity(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.createdDate = DateTime.Now;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return name;
        }
        public virtual bool Validate()
        {
            return !string.IsNullOrEmpty(name);
        }

        public abstract void DisplayInfo();

    }
}