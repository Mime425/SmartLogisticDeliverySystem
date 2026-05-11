using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogisticsDelieverySystem
{
    public abstract class Entity
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
        //cannot be empty
        public int GetId()
        {
            return id;
        }
            
        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidDataException("Name cannot be empty");
            }
            this.name = name;
        }

        public void SetId(int id)
        {
            this.id = id;
        }
        public void SetCreateDate(DateTime createdDate)
        {
            this.createdDate = createdDate;
        }


        public virtual bool Validate()
        {
            return id > 0 && !string.IsNullOrEmpty(name);
        }

        public abstract void DisplayInfo();

    }
}