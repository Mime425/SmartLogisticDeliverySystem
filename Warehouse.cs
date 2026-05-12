using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogisticsDelieverySystem
{
    public class Warehouse
    {
        private string name;
        private List<Vehicle> vehicles = new List<Vehicle>();
        private List<Package> packages = new List<Package>();
        private List<Worker> workers = new List<Worker>();

        public Warehouse(string name)
        {
            this.name = name;
            this.packages = new List<Package>();

        }

        public void AddPackage(Package p)
        {
            packages.Add(p);
        }

        

        public void RemovePackage(Package p)
        {
            packages.Remove(p);
        }

        public Vehicle FindBestVehicle(Package p)
        {
            Vehicle bestVehicle = null;
            double bestEfficiency = double.MaxValue;

            foreach (var vehicle in vehicles)
            {
                if (vehicle.GetRemainingCapacity() >= p.weight)
                {
                    double efficiency = vehicle.CalculateFuelEfficiency();
                    if (efficiency < bestEfficiency)
                    {
                        bestEfficiency = efficiency;
                        bestVehicle = vehicle;
                    }
                }
            }
            return bestVehicle;
        }

        public Worker AssignWorker()
        {
            if (workers == null || workers.Count == 0)
            {
                throw new InvalidOperationException("No workers available");
            }

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

        public List<Package> GetPendingPackages()
        {    //array list
            List<Package> pendingPackages = new List<Package>();
            for (int i = 0; i < packages.Count; i++) // we initialize, then go until last pkg, then go to nxt pkg
            {
                if (packages[i].status == "pending")
                {
                    pendingPackages.Add(packages[i]); // the current pkg
                }
                
            }
            return pendingPackages;

        }

    }

}
