namespace SmartLogisticsDelieverySystem
{
    using SmartLogisticsDelieverySystem;
    using System.Text.Json;

    class Program
    {

        static DeliverySystem deliverySystem = new DeliverySystem();
        static Stack<string> undoStack = new Stack<string>();
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("\n =====DELIVERY SYSTEM MENU=====");
                Console.WriteLine("1. Add Package");
                Console.WriteLine("2. Add Worker");
                Console.WriteLine("3. Add Vehicle");
                Console.WriteLine("4. Assign Deliveries");
                Console.WriteLine("5. Sort Packages");
                Console.WriteLine("6. Search Package");
                Console.WriteLine("7. Run simulation");
                Console.WriteLine("8. Undo");
                Console.WriteLine("9. Save");
                Console.WriteLine("10. Load");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice: ");

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
                        deliverySystem.ProcessDeliveries();
                        undoStack.Push("Assigned deliveries");
                        break;
                    case 5:
                        deliverySystem.SortPackage();
                        undoStack.Push("Sorted packages");
                        break;
                    case 6:
                        deliverySystem.SearchPackageId();
                        break;
                    case 7:
                        deliverySystem.RunSimulation();
                        undoStack.Push("Ran simulation");
                        break;
                    case 8:
                        Undo();
                        break;
                    case 9:
                        Save();
                        break;
                    case 10:
                        Load();
                        break;
                }
                
            } while (choice != 0);
        }

        private static void Load()
        {
            throw new NotImplementedException();
        }

        private static void Save()
        {
            throw new NotImplementedException();
        }

        private static void Undo()
        {
            throw new NotImplementedException();
        }

        static void AddPackage()
        {
            Console.WriteLine("Enter package ID ");
            int id = int.Parse(Console.ReadLine());

            Package package = new Package(id);
            deliverySystem.AddPackage(package);
            undoStack.Push($"Added package {id}");
        }
        static void AddWorker()
        {
            Console.WriteLine("Enter worker Name ");
            string name = Console.ReadLine();

            //Worker worker = new Worker(name);
            //deliverySystem.AddWorker(worker);
            //undoStack.Push($"Added worker {name}");
        }
        static void AddVehicle()
        {
            Console.WriteLine("Enter vehicle Capacity ");
            int capacity = int.Parse(Console.ReadLine());

            //Vehicle vehicle = new Vehicle(capacity);
            //deliverySystem.AddVehicle(vehicle);
            //undoStack.Push($"Added vehicle with capacity {capacity}");
        }
        static void SearchPackage()
        {
            Console.WriteLine("Enter package ID : ");
            int id = int.Parse(Console.ReadLine());

            Package package = deliverySystem.SearchPackageId(id);
            if (package != null)
            {
                Console.WriteLine($"Package found: ID {package.id}");
            }
            else
            {
                Console.WriteLine("Package not found.");
            }
            static void Undo()
            {
                if (undoStack.Count > 0)
                    Console.WriteLine($"Undo: {undoStack.Pop()}");
                else
                    Console.WriteLine("Nothing to undo.");
            }
            static void Save()
            {
                string json = System.Text.Json.JsonSerializer.Serialize(deliverySystem);
                File.WriteAllText("deliverySystem.json", json);
                Console.WriteLine("Delivery system saved.");
            }
            static void Load()
            {
                if (File.Exists("deliverySystem.json"))
                {
                    string json = File.ReadAllText("deliverySystem.json");
                    deliverySystem = JsonSerializer.Deserialize<DeliverySystem>(json);
                    Console.WriteLine("Delivery system loaded.");
                }
            }
        }
    }
}