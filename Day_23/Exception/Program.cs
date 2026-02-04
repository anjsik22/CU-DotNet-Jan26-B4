using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSLearning
{

    class InValidStudentAgeException : Exception
    {
        public InValidStudentAgeException(string message) : base(message)
        {

        }

    }
    class InValidStudentNameException : Exception
    {
        public InValidStudentNameException(string message) : base(message)
        {

        }

    }
    internal class StudentException
    {
        //----------Custom Exception--------------   
        public static void ValidateStudent()
        {
            Console.WriteLine("Enter Student Name:");
            string name = Console.ReadLine();

            if (name.Any(char.IsDigit))
            {
                throw new InValidStudentNameException(
                    "Student name should not contain numbers.");
            }

            int age;

            while (true)
            {
                Console.WriteLine("Enter Student Age:");
                try
                {
                    age = int.Parse(Console.ReadLine());

                    if (age < 18 || age > 60)
                    {
                        throw new InValidStudentAgeException(
                            "Student age must be between 18 and 60.");
                    }

                    // valid age → exit loop
                    break;
                }
                catch (InValidStudentAgeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void Main(string[] args)
        {
            //-----------Built-IN exceptions------------
            //divide two numbers
            try
            {
                Console.WriteLine("Enter First Number: ");
                int a = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Second Number: ");
                int b = int.Parse(Console.ReadLine());

                int result = a / b;
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero");
            }
            finally
            {
                Console.WriteLine("Operation Completed");
            }

            //Convert user input
            try
            {
                Console.Write("Enter an integer: ");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine("You entered: " + num);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format");
            }
            finally
            {
                Console.WriteLine("Operation Completed");
            }

            //access array
            try
            {
                int[] array = { 10, 20, 30 };
                Console.WriteLine("Enter array index");
                int idx = int.Parse(Console.ReadLine());
                Console.WriteLine($"Value : {array[idx]}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index out of Range");
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter Valid array ");
            }
            finally
            {
                Console.WriteLine("Operation Completed");
            }
            try
            {

                // call method
                ValidateStudent();

                Console.WriteLine("Student data is valid");
            }
            catch (Exception ex)
            {
                // 🔹 wrap custom exception as InnerException
                Exception wrapped =
                    new Exception("Student validation failed", ex);

                Console.WriteLine("Message: " + wrapped.Message);

                if (wrapped.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " +
                        wrapped.InnerException.Message);
                }

                Console.WriteLine("\nStackTrace:");
                Console.WriteLine(wrapped.StackTrace);
            }
            finally
            {
                Console.WriteLine("\nOperation Completed");
            }
        }

    }
}

    


