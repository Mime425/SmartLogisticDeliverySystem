using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogisticsDelieverySystem
{
    public class DeliverySystem
    {
        private List<Warehouse> warehouses = new List<Warehouse>();
        private List<Package> packages = new List<Package>();
        //for package waiting system 
        private CustomQueue<Package> waitingPackages = new CustomQueue<Package>(20);
       

        public void AddWarehouse(Warehouse w)
        {
            warehouses.Add(w);
        }

        //methods for package waiting system from the customQueue<T>
        //for pkg waiting syt
        public void AddPackage(Package p)
        {
            packages.Add(p);
            waitingPackages.Enqueue(p); //add pkg enqueue
        }

        public Package NextPackage()
        {
            return waitingPackages.Dequeue(); //gets next package
        }

        public Package PeekNextPackage()
            { return waitingPackages.Peek(); } //peek sees pkg

        public bool EmptyPackages()
        { 
            return waitingPackages.IsEmpty(); //validates if its empty 
        }

        public Package SearchPackageById(int id)
        {
            foreach (Package package in packages)
            {
                if (package.id == id) ;
                return package;
            }
            return null;
        }

        public void SortPackage()
        {
            for (int i = 0; i < packages.Count - 1; i++)
            {
                for (int j = 0; j < packages.Count - 1; j++)
                {
                    if (packages[j].CalculatePriorityScore() < packages[j + 1].CalculatePriorityScore())
                    {
                        Package temp = packages[j];
                        packages[j] = packages[j + 1];
                        packages[j + 1] = temp;
                    }

                }
            }
        }

        public void ProcessDeliveries()
        {
            foreach (Package p in packages)
            {

            }
        }


    }
}
