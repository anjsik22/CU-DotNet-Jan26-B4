using StudentManagament.Models;
using StudentManagament.Repository;
using StudentManagament.Services;

namespace StudentManagament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Storage:");
            Console.WriteLine("1. List");
            Console.WriteLine("2. JSON File");

            var choice = Console.ReadLine();

            IStudentRepository repo;

            // 🔥 Decision ONLY HERE (Correct Architecture)
            if (choice == "1")
                repo = new ListStudentRepository();
            else
                repo = new JsonStudentRepository();

            var service = new StudentService(repo);

            while (true)
            {
                Console.WriteLine("\n1.Add 2.View 3.Update 4.Delete 5.Exit");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Grade: ");
                        int grade = int.Parse(Console.ReadLine());

                        service.AddStudent(new Student { Id = id, Name = name, Grade = grade });
                        break;

                    case "2":
                        var students = service.GetAllStudents();
                        foreach (var s in students)
                            Console.WriteLine($"{s.Id} - {s.Name} - {s.Grade}");
                        break;

                    case "3":
                        Console.Write("Id: ");
                        int uid = int.Parse(Console.ReadLine());

                        Console.Write("New Name: ");
                        string uname = Console.ReadLine();

                        Console.Write("New Grade: ");
                        int ugrade = int.Parse(Console.ReadLine());

                        service.UpdateStudent(new Student { Id = uid, Name = uname, Grade = ugrade });
                        break;

                    case "4":
                        Console.Write("Id: ");
                        int did = int.Parse(Console.ReadLine());
                        service.DeleteStudent(did);
                        break;

                    case "5":
                        return;
                }
            }
        }
    }
}
