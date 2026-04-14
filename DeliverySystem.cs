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
        //package undo 
        private CustomStack<Package> undoPackages = new CustomStack<Package>(20);

        public void AddWarehouse(Warehouse w)
        {
            warehouses.Add(w);
        }
        
        //methods for package waiting system from the customQueue<T> 
        //and custom stack
        //for package waiting syytem
        public void AddPackage(Package p)
        {
            packages.Add(p);
            waitingPackages.Enqueue(p); //add pkg enqueue
            undoPackages.Push(p); // this saves for unto in custom stack
        }

        public Package NextPackage()
        {
            return waitingPackages.Dequeue(); //gets next package
           
        }

        public Package PeekNextPackage()
        {
            return waitingPackages.Peek(); // peek sees package
        }
  

        public bool EmptyPackages()
        { 
            return waitingPackages.IsEmpty(); //validates if its empty 
        }

        //undo system package
        public void UndoPackage()
        {
            if (undoPackages.IsEmpty())
            {
                Console.WriteLine("There is no packages  to undo");
                return;
            }
            Package p =  undoPackages.Pop(); //removes the added package from the cust stack
            packages.Remove(p);   //removes that package from list of pakages
            Console.WriteLine("We undid the package");

        }

        public Package SearchPackageId(int id)
        {
            foreach (Package package in packages)
            {
                if (package.id == id) 
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
            while (waitingPackages.IsEmpty())
            {
               Package p = waitingPackages.Dequeue(); 
                

            }
            Console.WriteLine("Processing delivery packages");
        }

        public void RunSimulation()
        {
            Console.WriteLine("Running delivery simulation");
            SortPackage();
            ProcessDeliveries();
            Console.WriteLine("Simulation completed.");


        }
        //
        internal void SearchPackageId()
        {
            throw new NotImplementedException();
        }

        internal void AddWorker(Worker worker)
        {
            throw new NotImplementedException();
        }

        internal void AddVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
