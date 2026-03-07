namespace OOPSLearning
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }

        public override string ToString()
        {
            return $"Id - {Id} Name - {Name} Marks - {Marks}";
        }
    }
    class studentManager
    {
        Dictionary<int,Student> studentData=new Dictionary<int,Student>();
        public bool AddStudent(Student student)
        {
            int id=student.Id;
            if (!studentData.ContainsKey(id))
            {
                studentData.Add(student.Id,student);
                return true;
            }
            return false;
        }

        public Student SearchStudent(int id)
        {
            studentData.TryGetValue(id, out Student student);
            return student;
        }

        public bool UpdateStudent(int id, int marks)
        {
            Student foundStudent = SearchStudent(id);
            if (foundStudent != null)
            {
                foundStudent.Marks = marks;
                return true;
            }
            return false;
        }
        public bool DeleteStudent(int id)
        {
            return studentData.Remove(id);
        }

        public void DisplayStudentData()
        {
            foreach (var student in studentData)
            {
                Console.WriteLine(student.Value);
            }
        }
    }
    internal class StudentData
    {
        static void Main(string[] args)
        {
            studentManager studentManager = new studentManager();
            int choice;
            do
            {
                Console.WriteLine("----STUDENT MANAGEMENT MENU-----");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Update Student Marks");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Display All Student Data");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter id: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Marks: ");
                        int marks = int.Parse(Console.ReadLine());

                        bool added = studentManager.AddStudent(new Student
                        {
                            Id = id,
                            Name = name,
                            Marks = marks
                        });

                        Console.WriteLine(added ? "Student added successfully" : "Student already exists");
                        break;

                    case 2:
                        Console.Write("Enter Id to search: ");
                        int searchId = int.Parse(Console.ReadLine());

                        Student found = studentManager.SearchStudent(searchId);
                        Console.WriteLine(found == null ? "Student not found" : found.ToString());
                        break;

                    case 3:
                        Console.Write("Enter Id: ");
                        int updateId = int.Parse(Console.ReadLine());

                        Console.Write("Enter new Marks: ");
                        int newMarks = int.Parse(Console.ReadLine());

                        Console.WriteLine(studentManager.UpdateStudent(updateId, newMarks) ? "Marks updated successfully"
                            : "Student not found"
                        );
                        break;

                    case 4:
                        Console.Write("Enter Id to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());

                        Console.WriteLine(studentManager.DeleteStudent(deleteId) ? "Student deleted successfully"
                            : "Student not found"
                        );
                        break;

                    case 5:
                        studentManager.DisplayStudentData();
                        break;

                    case 6:
                        Console.WriteLine("Exiting Application");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 6);
        }
    }
}

