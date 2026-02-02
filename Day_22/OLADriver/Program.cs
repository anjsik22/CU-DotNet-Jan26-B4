namespace OOPSLearning
{
    class OLADriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleNO { get; set; }
        public List<Ride> Rides { get; set; } =new List<Ride>();
        public decimal GetFare()
        {
            int total = 0;
            foreach (var ride in Rides)
            {
                total += ride.Fare;
            }
            return total;
        }
    }


    class Ride
    {
        public int RideId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Fare { get; set; }

        public override string ToString()
        {
            return $"Ride Id - {RideId} From - {From} To - {To} Fare - {Fare}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<OLADriver> drivers = new List<OLADriver>();
            OLADriver d1 = new OLADriver
            {
                Id = 101,
                Name="Anjali",
                VehicleNO="UP81705CS"
            };
            d1.Rides.Add(new Ride { RideId = 1, From = "Agra", To = "Delhi", Fare = 1200 });
            d1.Rides.Add(new Ride { RideId = 2, From = "Delhi", To = "Chandigarh", Fare = 1500 });
            d1.Rides.Add(new Ride { RideId = 3, From = "Noida", To = "Gwalior", Fare = 2500 });

            OLADriver d2 = new OLADriver
            {
                Id = 102,
                Name="Ram",
                VehicleNO="KA64328JE"
            };
            d2.Rides.Add(new Ride { RideId = 11, From = "Bangalore", To = "Mysore", Fare = 3000 });
            d2.Rides.Add(new Ride { RideId = 12, From = "Chennai", To = "Bangalore", Fare = 7000 });
            d2.Rides.Add(new Ride { RideId = 13, From = "Mumbai", To = "Pune", Fare = 4500 });

            drivers.Add(d1);
            
            drivers.Add(d2);

            foreach (var driver in drivers)
            {
                Console.WriteLine($"Driver_Id = {driver.Id}");
                Console.WriteLine($"Driver_Name = {driver.Name}");
                Console.WriteLine($"Vehicle Number = {driver.VehicleNO}");
                Console.WriteLine("Rides");
                foreach (var ride in driver.Rides)
                {
                    Console.WriteLine(""+ride);
                }
                Console.WriteLine($"Total Fare : {driver.GetFare()}");
                Console.WriteLine();

            }
        }
    }
}

