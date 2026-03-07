using System.Text;
namespace Week7
{
    internal class Program
    {
        public static string VowelConsonantShift(string input)
        {
            StringBuilder sb = new StringBuilder();
            string vowels = "aeiou";
            foreach(char c in input)
            {
                char replaced = c;
                if (c == 'a') replaced = 'e';
                else if (c == 'e') replaced = 'i';
                else if (c == 'i') replaced = 'o';
                else if (c == 'o') replaced = 'u';
                else if (c == 'u') replaced = 'a';
                else { 
                    char next = (char)(c + 1);
                    if (next > 'z') next = 'a';

                    if (vowels.Contains(next))
                    {
                        next = (char)(next + 1);
                        if (next > 'z') next = 'a';
                    }

                     replaced = next;
                }

                 sb.Append(replaced);

             }
            return sb.ToString();
            

        }
        static void Main(string[] args)
        {
            string input = "crypt";
            string result = VowelConsonantShift(input);
            Console.WriteLine(result);
            
        }
    }
}

