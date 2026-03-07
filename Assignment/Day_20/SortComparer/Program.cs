using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSLearning
{
    class Flight:IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DepartureTime { get; set; }

        public int CompareTo(Flight? other)
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other!.Price);
        }

        public override string ToString()
        {
            
            return $"Flight Number: {FlightNumber} Price: {Price} Duration: {Duration} Departure: {DepartureTime}";
        }
    }
    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x.Duration.CompareTo(y.Duration);
        }
    }

    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x.DepartureTime.CompareTo(y.DepartureTime);
        }
    }

    internal class SortComparer
    {
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>()
            {
                new Flight()
                {
                    FlightNumber="1A",
                    Price=12000,
                    Duration=new TimeSpan(2,20,0),
                    DepartureTime=new DateTime(2026,01,20,13,15,0)
                },
                new Flight()
                {
                    FlightNumber="11A",
                    Price=10000,
                    Duration=new TimeSpan(3,0,0),
                    DepartureTime=new DateTime(2026,01,20,16,30,24)
                },
                new Flight()
                {
                    FlightNumber="1B",
                    Price=15000,
                    Duration=new TimeSpan(2,10,0),
                    DepartureTime=new DateTime(2026,01,20,22,10,0)
                }
            };

            flights.Sort();
            Console.WriteLine("Economy View (Sort by Price)");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }
            Console.WriteLine();
            
            IComparer<Flight> shortFlight = new DurationComparer();
            flights.Sort(shortFlight);
            Console.WriteLine("Business Runner View (Sort by Duration)");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }
            Console.WriteLine();

            IComparer<Flight> earlyFlight = new DepartureComparer();
            flights.Sort(earlyFlight);
            Console.WriteLine("Early Bird View (Sort by Departure Time)");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }

        }
    }
}
