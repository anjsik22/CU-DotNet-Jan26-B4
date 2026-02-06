using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    internal class DailyReflection
    {
        static void Main(string[] args)
        {
            string directory = @"..\..\..\";
            if (!Directory.Exists(directory))
            {
                Console.WriteLine("Directory doesn't exits");
                return;
            }
            string file = directory + @"journal.txt";
            using StreamWriter sw= new StreamWriter(file,true);
           
            Console.WriteLine("Enter Daily Reflection");
            string data = Console.ReadLine();
            sw.WriteLine(data);

        }
    }
}

