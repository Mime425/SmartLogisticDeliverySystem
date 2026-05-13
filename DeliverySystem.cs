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
        //20 is max amount that waiting and undo packages can store

        private List<Worker> workers = new List<Worker>();
        private List<Vehicle> vehicles = new List<Vehicle>();

        //We need to access delivery system
        // we use public here to access it in Save()
        public List<Package> Packages 
        {
            get
            {
                return packages; 
            }
        }

        //this adds warehouse to the system
        public void AddWarehouse(Warehouse w)
        {
            warehouses.Add(w);  //this adds warehouse to list
        }
        
        //methods for package waiting system from the customQueue<T> 
        //and custom stack
        //for package waiting syytem
        public void AddPackage(Package p)
        {
            packages.Add(p); // this adds package to the list of all packages in system
            waitingPackages.Enqueue(p); //add pkg enqueue
            undoPackages.Push(p); // this saves for undo in custom stack
        }

        //putting packages that are pending back in the queue
        //updating them with current list
        public void UpdatingQueues()
        {
            waitingPackages.Clear();
            undoPackages = new CustomStack<Package>(20);
            foreach (Package p in packages)
            {
                if (p.status == "Pending")
                {
                    waitingPackages.Enqueue((Package)p);
                }
                undoPackages.Push(p);
            }
        }



        //next package to deliever
        public Package NextPackage()
        {
            return waitingPackages.Dequeue(); //gets next package
           
        }

        //sees the next package without removing it 
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
            //package has been removed, now updating the waiting queue with remaining pkgs
            waitingPackages.Clear();
            {
                foreach (Package pkg in packages)
                {
                    if (pkg.status == "Pending")
                    {
                        waitingPackages.Enqueue(pkg);
                    }
                }
                Console.WriteLine("We undid the package");
            }

        }

        public Package? SearchPackageById(int id)   // could be a package or not
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
            //after sorting packages, we have to update waiting packages in queue
            waitingPackages.Clear();
            foreach (Package p in packages)
            {
                if (p.status == "Pending")
                {
                    waitingPackages.Enqueue(p);
                }
            }
        }

        //method that processes all packes
        // that are in waiting queue
        public void ProcessDeliveries()
        {
            while (!waitingPackages.IsEmpty())
            {
               Package p = waitingPackages.Dequeue();  // this takes the next package in the queue
                p.UpdateStatus("Delievered");
                Console.WriteLine($"Delievered package {p.id}");

            }
            Console.WriteLine("Processing delivery packages");
        }

        //this method runs the full delievery simulation
        public void RunSimulation()
        {
            Console.WriteLine("Running delivery simulation");
            SortPackage();                  //sorts package
            ProcessDeliveries();               //processes deliveries 
            Console.WriteLine("Simulation completed.");

        }
        //methods created while trying to run our main

        internal void AddWorker(Worker worker)
        {
            workers.Add(worker);
        }

        internal void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }
    }
}
