using GreetingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your name");
            string name = Console.ReadLine();

            string greeting = GreetingHelper.GetGreeting(name);
            Console.WriteLine(greeting);
        }
    }
}
