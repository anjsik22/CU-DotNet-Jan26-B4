using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    internal class Employee
    {
        static void Main(string[] args)
        {
            Hashtable employeeTable = new Hashtable();
            employeeTable.Add(101, "Alice");
            employeeTable.Add(102, "Bob");
            employeeTable.Add(103, "Charlie");
            employeeTable.Add(104, "Diana");

            //unique key check
            
             if (employeeTable[105]==null)
             {
                employeeTable.Add(105, "Edward");
                Console.WriteLine("Done");
             }
             else
             {
                    
                Console.WriteLine("ID Already exits");
             }
            // Data Retrieval and Boxing
            string name = (string)employeeTable[102];
            Console.WriteLine(name);

            //Iteration
            foreach (DictionaryEntry item in employeeTable)
            {
                Console.WriteLine($"Id- {item.Key}, Name - {item.Value}");
            }
            //Deletion
            Console.WriteLine($"Total Number of remaining employee - {employeeTable.Count}");
            employeeTable.Remove(103);
            Console.WriteLine($"Total Number of remaining employee - {employeeTable.Count}");
            

        }
    }
}

