using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogisticsDelieverySystem
{
     abstract class Van : Vehicle
    {
        //attributes 
        private bool isElectric;

        // constructor
        public Van(int id, string name, double currentLoad, double speed, double maxCapacity, bool isAvailable) : base(id, name, currentLoad, speed, maxCapacity, isAvailable)
        {
            this.isElectric = isElectric;

        }

        //Deliever 
        public override void Deliver(List<Package> packages)
        {

            Console.WriteLine("The van is delivering packages");
            //WE HAVE TO check this function

                for (int i = 0; i < packages.Count;
                  i++)
               {

                int num = i;
               Console.WriteLine("Package" + num + "is being delivered" );
            }

            Console.WriteLine("The van delivered all the packages");


        }


    }
}
