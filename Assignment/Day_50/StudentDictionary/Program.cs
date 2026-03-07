
namespace week9
{
    class Student
    {
        public int StudId { get; set; }
        public string SName { get; set; }

        public override bool Equals(object obj)
        {
            Student s = (Student)obj;
            return this.StudId == s.StudId && this.SName == s.SName;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(StudId, SName);
        }

        
    }
    internal class StudRecord
    {
        static Dictionary<Student, int> students = new Dictionary<Student, int>();
        public static void StudentAddOrUpdate(Student s,int marks)
        {
            if (!students.ContainsKey(s)){
                students.Add(s, marks);
            }
            else if (marks > students[s])
            {
                students[s] = marks;
            }
        }
        public static void Display()
        {
            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key.StudId}, {item.Key.SName}, {item.Value}");
            }
        }
        static void Main(string[] args)
        {
            Student s1 = new Student { StudId = 1, SName = "Anjali" };
            StudRecord.StudentAddOrUpdate(s1, 85);
            StudRecord.StudentAddOrUpdate(new Student { StudId = 2, SName = "Riya" }, 82);
            Student s3 = new Student { StudId = 3, SName = "Aman" };
            StudRecord.StudentAddOrUpdate(s3, 78);
            Student s4 = new Student { StudId = 3, SName = "Aman" };
            StudRecord.StudentAddOrUpdate(s4, 83);


            Display();

        }
    }
}

