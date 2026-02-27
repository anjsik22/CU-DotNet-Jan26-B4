
namespace OOPSLearning
{
    internal class LineMethod
    {
        public static void DisplayLine()
        {
            Console.WriteLine(new string('-', 40));
        }

        public static void DisplayLine(char ch)
        {
            Console.WriteLine(new string(ch, 40));
        }

        public static void DisplayLine(char ch, int count)
        {
            Console.WriteLine(new string(ch, count));
        }
        static void Main(string[] args)
        {
            DisplayLine();
            DisplayLine('+');
            DisplayLine('$', 60);
        }
    }
    
}

