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

        public void AddWarehouse(Warehouse w)
        {
            warehouses.Add(w);
        }

        public void AddPackage(Package p)
        {
            packages.Add(p);
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
