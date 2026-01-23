namespace OOPSLearning
{
    class ApplicationConfig
    {
        public static string ApplicationName { get; set; }
        public static string Environment { get; set; }
        public static int AccessCount { get; set; }
        public static bool IsInitialized { get; set; }

        static ApplicationConfig()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;
            Console.WriteLine("Static Constructor Executed");
        }
        public static void Initialize(string appName,string environment)
        {
            ApplicationName = appName;
            IsInitialized = true;
            AccessCount++;
        }
        public static string GetConfigurationSummary()
        {
            AccessCount++;
            return $"Application Name - {ApplicationName}\nEnvironment - {Environment}\n" +
                $"Access Count - {AccessCount}\nInitialization Status - {IsInitialized}\n";
        }

        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;
            AccessCount++;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ApplicationConfig.ApplicationName); //trigger static constructor
            Console.WriteLine();
            ApplicationConfig.Initialize("ConfigTracker", "Production");
            string summary=ApplicationConfig.GetConfigurationSummary();
            Console.WriteLine("Summary");
            Console.WriteLine(summary);
            ApplicationConfig.Initialize("QA TRacker","QA");
            string summary1=ApplicationConfig.GetConfigurationSummary();
            Console.WriteLine(summary1);
            ApplicationConfig.ResetConfiguration();
            Console.WriteLine("Reset Configuration");
            string resetsummary = ApplicationConfig.GetConfigurationSummary();
            Console.WriteLine(resetsummary);

        }
    }
}