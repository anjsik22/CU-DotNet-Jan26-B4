using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    internal class Dictionary
    {
        static void Main(string[] args)
        {
            //Initialize Sorted Collection
            SortedDictionary<double,string> leaderboard=new SortedDictionary<double,string>();

            //Populate data
            leaderboard.Add(55.42, "SwiftRacer");
            leaderboard.Add(52.10, "SpeedDemon");
            leaderboard.Add(58.91, "SteadyEddie");
            leaderboard.Add(51.05, "TurboTom");

            //Automatic Sorting Verification
            Console.WriteLine("Player Sorted Data");
            foreach (var item in leaderboard)
            {
                Console.WriteLine($"{item.Value} - {item.Key}");
            }
            Console.WriteLine();

            //Range Logic
            Console.WriteLine("Gold Medal Time");
            Console.WriteLine(leaderboard.First());

            //Update Record
            Console.WriteLine();
            double time=0;
            foreach (var item in leaderboard)
            {
                
                if(item.Value=="SteadyEddie")
                {
                    time = item.Key;
                }
                
            }
            leaderboard.Remove(time);
            leaderboard.Add(54.00, "SteadyEddie");
            Console.WriteLine("Record Updated");
        }
    }
}

