
using System.Text;


namespace week9
{
    public class Program
    {
        class CollageManagement
        {
            Dictionary<string, Dictionary<string, int>> studentRecords = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, LinkedList<KeyValuePair<string, int>>> studentSubjectsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();


            Dictionary<string, Dictionary<string, int>> subjectsRecords = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, LinkedList<KeyValuePair<string, int>>> subjectsStudentsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();

            public int AddStudent(string studentId, string subject, int marks)
            {
                if (!studentRecords.ContainsKey(studentId))
                {
                    studentRecords[studentId] = new Dictionary<string, int>();
                    studentSubjectsOrder[studentId] = new LinkedList<KeyValuePair<string, int>>();
                }

                if (!subjectsRecords.ContainsKey(subject))
                {
                    subjectsRecords[subject] = new Dictionary<string, int>();
                    subjectsStudentsOrder[subject] = new LinkedList<KeyValuePair<string, int>>();
                }

                if (!studentRecords[studentId].ContainsKey(subject))
                {
                    studentRecords[studentId][subject] = marks;
                    subjectsRecords[subject][studentId] = marks;

                    subjectsStudentsOrder[subject].AddLast(new KeyValuePair<string, int>(studentId, marks));
                }
                else if (marks > studentRecords[studentId][subject])
                {
                    studentRecords[studentId][subject] = marks;
                    subjectsRecords[subject][studentId] = marks;

                    var node = subjectsStudentsOrder[subject].First;
                    while (node != null)
                    {
                        if (node.Value.Key == studentId)
                        {
                            node.Value = new KeyValuePair<string, int>(studentId, marks);
                            break;
                        }
                        node = node.Next;
                    }
                }

                return 1;
            }

            public int RemoveStudent(string studentId)
            {
                if (!studentRecords.ContainsKey(studentId))
                    return 0;

                foreach (var subject in studentRecords[studentId])
                {
                    subjectsRecords[subject.Key].Remove(studentId);

                    var node = subjectsStudentsOrder[subject.Key].First;
                    while (node != null)
                    {
                        if (node.Value.Key == studentId)
                        {
                            subjectsStudentsOrder[subject.Key].Remove(node);
                            break;
                        }
                        node = node.Next;
                    }
                }

                studentRecords.Remove(studentId);
                return 1;
            }

            public string TopStudent(string subject)
            {
                if (!subjectsStudentsOrder.ContainsKey(subject))
                    return "";

                int max = int.MinValue;

                foreach (var s in subjectsStudentsOrder[subject])
                    max = Math.Max(max, s.Value);

                StringBuilder result = new StringBuilder();

                foreach (var s in subjectsStudentsOrder[subject])
                {
                    if (s.Value == max)
                        result.AppendLine($"{s.Key} {s.Value}");
                }

                return result.ToString();
            }

            public string Result()
            {
                StringBuilder result = new StringBuilder();

                foreach (var student in studentRecords)
                {
                    double sum = 0;

                    foreach (var subject in student.Value)
                        sum += subject.Value;

                    double avg = sum / student.Value.Count;

                    result.AppendLine($"{student.Key} {avg:F2}");
                }

                return result.ToString();
            }
        }
        public static void Main()
        {
            CollageManagement cm = new CollageManagement();

            cm.AddStudent("S1", "Math", 80);
            cm.AddStudent("S2", "Math", 90);
            cm.AddStudent("S3", "Math", 90);
            cm.AddStudent("S1", "Phy", 90);

            Console.Write(cm.TopStudent("Math"));
            Console.Write(cm.Result());
            Console.WriteLine();
            cm.RemoveStudent("S1");
            Console.WriteLine("After removing S1:");
            Console.WriteLine(cm.Result());   
        }
    }
}

