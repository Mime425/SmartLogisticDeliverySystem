namespace SmartLogisticsDelieverySystem
{
    using SmartLogisticsDelieverySystem;
    using System.ComponentModel.Design;

    class Program
    {
        static DeliverySystem deliverySystem = new DeliverySystem();
        static Stack<string> undoStack = new Stack<string>();
        static void Main(string[] args)
        {
            int choice;
            do
            {
                {
                    Console.WriteLine("\n =====DELIVERY SYSTEM MENU=====");
                    Console.WriteLine("1. Add entities");
                    Console.WriteLine("2. Assign Deliveries");
                    Console.WriteLine("3. Sort Packages");
                    Console.WriteLine("4. Search Package");
                    Console.WriteLine("5. Run simulation");
                    Console.WriteLine("6. Undo");
                    Console.WriteLine("7. Save");
                    Console.WriteLine("8. Load");
                    Console.WriteLine("0. Exit");

                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddEntities();
                            break;

                        case 2:
                            deliverySystem.ProcessDeliveries();
                            undoStack.Push("Assigned deliveries");
                            break;
                        case 3:
                            SortPackages();   
                            undoStack.Push("Sorted packages");
                            break;
                        case 4:
                            SearchPackage();
                            break;
                        case 5:
                            deliverySystem.RunSimulation();
                            undoStack.Push("Ran simulation");
                            break;
                        case 6:
                            Undo();

                            break;
                        case 7:
                            Save();
                            break;
                        case 8:
                            Load();
                            break;

                    }

                }
            } while (choice != 0);
        }

        //making a method for seperate menu
        static void AddEntities()
        {
            int choice;

            Console.WriteLine("--- Add Entities --- ");
            Console.WriteLine("1. Add Package");
            Console.WriteLine("2. Add Worker");
            Console.WriteLine("3. Add Vehicle");
            Console.WriteLine("4. Back to menu");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddPackage();
                    break;
                case 2:
                    AddWorker();
                    break;
                case 3:
                    AddVehicle();
                    break;

                case 4:
                    Console.WriteLine("Going back to menu");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;

            }

        }

        static void AddWorker()
        {
            int workerChoice;

            Console.WriteLine("---Add Worker---");
            Console.WriteLine("1. Driver");
            Console.WriteLine("2. Manager");
            Console.WriteLine("3. Loader");
            workerChoice = int.Parse(Console.ReadLine());

            if (workerChoice == 1)  //Driver
            {
                Console.WriteLine("Enter worker name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter worker id: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Experience Years: ");
                int experienceYears = int.Parse(Console.ReadLine());

                Console.WriteLine("Tasks completed (input a number) : ");
                int taskCompleted = int.Parse(Console.ReadLine());

                bool isAvailable = ValidateBool("Is available? :");

                Console.WriteLine("Licence type: ");
                string licenceType = Console.ReadLine();

                Driver d = new Driver(name, id, experienceYears, taskCompleted, isAvailable, licenceType);
                deliverySystem.AddWorker(d);
                Console.WriteLine("Driver has been added");
            }

            else if (workerChoice == 2)  //Manager
            {
                Console.WriteLine("Enter worker name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter worker id: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Experience Years: ");
                int experienceYears = int.Parse(Console.ReadLine());

                Console.WriteLine("Task completed (number): ");
                int taskCompleted = int.Parse(Console.ReadLine());

                bool isAvailable = ValidateBool("Is available ? :");

                Console.WriteLine("Team size (number): ");
                int teamSize = int.Parse(Console.ReadLine());

                Manager m = new Manager(teamSize, name, id, experienceYears, taskCompleted, isAvailable);
                deliverySystem.AddWorker(m);
                Console.WriteLine("Manager has been added");

            }
            else if (workerChoice == 3) //Loader
            {
                Console.WriteLine("Enter worker name");
                string name = Console.ReadLine();

                Console.WriteLine("Enter worker id");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Experience Years:");
                int experienceYears = int.Parse(Console.ReadLine());

                Console.WriteLine("Task completed (number):");
                int taskCompleted = int.Parse(Console.ReadLine());

                bool isAvailable = ValidateBool("Is available?");

                Console.WriteLine("Max Lifting weight: ");
                double maxLiftWeight = double.Parse(Console.ReadLine());

                Loader l = new Loader(maxLiftWeight, name, id, experienceYears, taskCompleted, isAvailable);
                deliverySystem.AddWorker(l);
                Console.WriteLine("Loader has been added");

            }

        }

        static void AddPackage()
        {
            Console.WriteLine("Enter package ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter package weight(kg): ");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter priority level (1-5): ");
            int priority = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter destination: ");
            string destination = Console.ReadLine();

            Console.WriteLine("Enter status: ");
            string status = Console.ReadLine();

            Package package = new Package(id, weight, priority, destination, status);
            deliverySystem.AddPackage(package);
            undoStack.Push($"Added package {id}");
        }
        //static void AddWorker()
        //{
        //    Console.WriteLine("Enter worker Name ");
        //    string name = Console.ReadLine();

        //    //Worker worker = new Worker(name);
        //    //deliverySystem.AddWorker(worker);
        //    //undoStack.Push($"Added worker {name}");
        //}
        static void AddVehicle()
        {
            int vehicleChoice;

            Console.WriteLine("---Add Vehicle---");
            Console.WriteLine("1. Truck");
            Console.WriteLine("2. Van");
            Console.WriteLine("3. Drone");
            vehicleChoice = int.Parse(Console.ReadLine());

            if (vehicleChoice == 1)  //truck
            {

                Console.WriteLine("Vehicle id: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Vehicle name: ");
                string name = Console.ReadLine();

                Console.WriteLine("CurrentLoad (number): ");
                double currentLoad = double.Parse(Console.ReadLine());

                Console.WriteLine("Current speed (number): ");
                double speed = double.Parse(Console.ReadLine());

                Console.WriteLine("Max capacity (number): ");
                double maxCapacity = double.Parse(Console.ReadLine());

                bool isAvailable = ValidateBool("Is available?: ");

                Console.WriteLine("Fuel consumption (number): ");
                double fuelConsumption = double.Parse(Console.ReadLine());

                Truck t = new Truck(id, name, currentLoad, speed, maxCapacity, isAvailable, fuelConsumption);
                deliverySystem.AddVehicle(t);
                Console.WriteLine("Truck has been added");
            }
            else if (vehicleChoice == 2) //Van
            {
                Console.WriteLine("Vehicle id: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Vehicle name: ");
                string name = Console.ReadLine();

                Console.WriteLine("CurrentLoad (number): ");
                double currentLoad = double.Parse(Console.ReadLine());

                Console.WriteLine("Current speed: ");
                double speed = double.Parse(Console.ReadLine());

                Console.WriteLine("Max capacity (number): ");
                double maxCapacity = double.Parse(Console.ReadLine());

                bool isAvailable = ValidateBool("Is available?: ");

                bool isElectric = ValidateBool("Is electric (yes/no): ");

                Van v = new Van(id, name, currentLoad, speed, maxCapacity, isAvailable, isElectric);
                deliverySystem.AddVehicle(v);
                Console.WriteLine("Van has been added");

            }
            else if (vehicleChoice == 3) //Drone
            {
                Console.WriteLine("Vehicle id: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Vehicle name: ");
                string name = Console.ReadLine();

                Console.WriteLine("CurrentLoad (number): ");
                double currentLoad = double.Parse(Console.ReadLine());

                Console.WriteLine("Current speed (number): ");
                double speed = double.Parse(Console.ReadLine());

                Console.WriteLine("Max capacity (number): ");
                double maxCapacity = double.Parse(Console.ReadLine());

                bool isAvailable = ValidateBool("Is Available ?: ");

                Console.WriteLine("Small packages (number): ");
                int smallPackages = int.Parse(Console.ReadLine());

                Console.WriteLine("Max distance (number): ");
                double maxDistance = double.Parse(Console.ReadLine());

                Drone d = new Drone(id, name, currentLoad, speed, maxCapacity, isAvailable, smallPackages, maxDistance);
                deliverySystem.AddVehicle(d);
                Console.WriteLine("Drone has been added");

            }


            //Vehicle vehicle = new Vehicle(capacity);
            //deliverySystem.AddVehicle(vehicle);
            //undoStack.Push($"Added vehicle with capacity {capacity}");
        }
        static void SearchPackage()
        {
            Console.WriteLine("Enter package ID : ");
            int id = int.Parse(Console.ReadLine());

            Package package = deliverySystem.SearchPackageById(id);
            if (package != null)
            {
                Console.WriteLine($"Package found: ID {package.id}");
            }
            else
            {
                Console.WriteLine("Package not found.");
            }
        }

        //Case 3, method to sort packages comes from Delievery System
        static void SortPackages()
        {
            deliverySystem.SortPackage();
            
            foreach (Package p in deliverySystem.Packages)
            {
                Console.WriteLine($"{p}");
              
            }
        }


        //Undo keeps track of actions that happen 
        static void Undo()
        {
            if (undoStack.Count > 0)
            {
                string action = undoStack.Pop();  //action from what the user did
                Console.WriteLine("Undo: " + action);
                if (action == "package")    //if we add pkg
                {
                    deliverySystem.UndoPackage();  //here we remove it

                }
            }
            else
            {
                Console.WriteLine("Nothing to undo.");
            }
        }

        static void Save()
        {
            try
            {
                StreamWriter sw = new StreamWriter("deliverySystem.txt");
                sw.WriteLine("Packages");
                foreach (Package p in deliverySystem.Packages) // from delivery system
                {
                    sw.WriteLine($"{p.id}|{p.weight}|{p.priorityLevel}|{p.destination}|{p.status}");
                }
                sw.Close();
                Console.WriteLine("Delivery system saved.");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
        static void Load()
        {
            if (!File.Exists("deliverySystem.txt")) //checks if it exits
            {
                Console.WriteLine("No save file was found.");
                return;
            }
            try
            {
                StreamReader sr = new StreamReader("deliverySystem.txt"); //acutally use it 
                deliverySystem = new DeliverySystem();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != "Packages")
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length != 5)
                        {
                            continue;                          //go to next line
                        }                
                        int id = int.Parse(parts[0]);
                        double weight = double.Parse(parts[1]);
                        int priorityLevel = int.Parse(parts[2]);
                        string destination = parts[3];
                        string status = parts[4];
                        Package p = new Package(id, weight, priorityLevel, destination, status);
                        deliverySystem.AddPackage(p);
                    }
                }
                sr.Close();
                Console.WriteLine("Delivery system loaded.");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

        //Methods to validate Int, String, Double, Bool
        //Bool
        static bool ValidateBool(string prompt)
        {
            string input;

            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if (input == "yes")  //user can only type yes
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
        //not implemented int, string , double
        

    }

}      