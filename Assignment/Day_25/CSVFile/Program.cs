using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    class Player
    {
        public string Name { get; set; }
        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }
        public bool IsOut { get; set; }
        public double StrikeRate;
        public double Average;

        public void CalculateStrikeRate()
        {
            if (BallsFaced == 0)
                throw new DivideByZeroException("Balls Faced is zero.");

            StrikeRate = (double)RunsScored / BallsFaced * 100;
        }

        // Batting Average calculation
        public void CalculateAverage()
        {
            Average = RunsScored;
        }


    }
    internal class PerformanceTracker
    {
        static void Main(string[] args)
        {
            
              string file = @"..\..\..\stud1.csv";

              // -------- CREATE CSV FILE --------
              using (FileStream fs = new FileStream(file, FileMode.Create))
              using (StreamWriter sw = new StreamWriter(fs))
              {
                  string[] data =
                  {
                      "Steve Smith,84,90,True",
                      "Virat Kohli,29,35,False",
                      "Joe Root,110,120,True",
                      "Bad Player,50,0,True"      // to test DivideByZeroException
                  };

                  foreach (string line in data)
                  {
                      sw.WriteLine(line);
                  }
              }

              List<Player> players = new List<Player>();

              // -------- READ CSV FILE --------
              try
              {
                  using (FileStream fs = new FileStream(file, FileMode.Open))
                  using (StreamReader sr = new StreamReader(fs))
                  {
                      string line;
                      while ((line = sr.ReadLine()) != null)
                      {
                          try
                          {
                              string[] parts = line.Split(',');

                              Player p = new Player();
                              p.Name = parts[0].Trim();
                              p.RunsScored = int.Parse(parts[1].Trim());   // may throw FormatException
                              p.BallsFaced = int.Parse(parts[2].Trim());  // may throw FormatException
                              p.IsOut = bool.Parse(parts[3].Trim());

                              // Filter: fewer than 10 balls
                              if (p.BallsFaced < 10)
                                  continue;

                              // Calculations
                              p.CalculateStrikeRate();   // may throw DivideByZeroException
                              p.CalculateAverage();

                              players.Add(p);
                          }
                          catch (FormatException)
                          {
                              Console.WriteLine("Format error in line: " + line);
                          }
                          catch (DivideByZeroException ex)
                          {
                              Console.WriteLine("Calculation error: " + ex.Message);
                          }
                      }
                  }

                // -------- SORT BY STRIKE RATE DESC --------
                players = players.OrderByDescending(p => p.RunsScored).ToList();

                // -------- DISPLAY OUTPUT --------
                Console.WriteLine($"{"Name",-15}{"Runs",-8}{"SR",-10}{"Avg",-20}");
                Console.WriteLine("------------------------------------------");

                  foreach (Player p in players)
                  {
                        Console.WriteLine(
                            $"{p.Name,-15}{p.RunsScored,-8}{p.StrikeRate,-10:F2}{p.Average:F2}");
                  }
              }
              catch (FileNotFoundException)
              {
                    Console.WriteLine("CSV file not found. Please check the file path.");
              }
        }
    }

}


