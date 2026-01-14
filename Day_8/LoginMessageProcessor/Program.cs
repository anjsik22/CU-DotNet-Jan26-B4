using System;
class Program
{
    static void Main(string[] args)
    { 
        //Read Entire input in one line
        string input=Console.ReadLine();

        //Split input
        string[] parts=input.Split('|');

        string userName = parts[0];
        string loginMessage = parts[1];

        //----String Operation (Clean Message)----
        string trimmedMessage = loginMessage.Trim();  //trim spaces

        string cleanedMessage=trimmedMessage.ToLower(); //convert to lower case

        // Standard message
        string standardMessage = "login successful";

        // Determine status
        string status;

        if (!cleanedMessage.Contains("successful")) // string search
        {
            status = "LOGIN FAILED";
        }

        else if (cleanedMessage.Equals(standardMessage)) // string comparison
        {
            status = "LOGIN SUCCESS";
        }
        else
        {
            status = "LOGIN SUCCESS (CUSTOM MESSAGE)";
        }

        //output
        Console.WriteLine($"{ "User",-9 }: {userName}");
        Console.WriteLine($"{ "Message",-9 }: {cleanedMessage}");
        Console.WriteLine($"{ "Status",-9 }: {status}");


    }
}
