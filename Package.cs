namespace SmartLogisticsDelieverySystem
{
    public class Package

    {


        public double weight { get; set; }
        public int id { get; set; }
        public int priorityLevel { get; set; }
        public string destination { get; set; }
        public string status { get; set; }

        public Package(double weight, int id, int priorityLevel, string destination, string status)
        {
            this.weight = weight;
            this.id = id;
            this.priorityLevel = Math.Clamp(priorityLevel, 1, 5);
            this.destination = destination;
            this.status = "Pending";
        }

        public Package(int id)
        {
            this.id = id;
        }

        public double CalculatePriorityScore()
        {
            return priorityLevel * weight;
        }

        public void UpdateStatus(string newStatus)
        {
            status = newStatus;
        }

        public bool isHeavy()
        {
            return weight > 80;
        }

        public override string ToString()
        {
            return $"Package ID: {id}, Weight: {weight}kg, Priority Level: {priorityLevel}, Destination: {destination}, Status: {status}";
        }
    }
}