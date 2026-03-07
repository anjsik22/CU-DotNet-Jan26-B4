
namespace week9
{
    class CreatorStats
    {
        public string CreatorName { get; set; }
        public double[] WeeklyLikes { get; set; }

       
    }
    internal class StreamBuzz
    {
        public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
        public void RegisterCreator(CreatorStats record)
        {
            EngagementBoard.Add(record);
        }
        public Dictionary<string,int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var creator in records)
            {
                int count = 0;
                foreach(var like in creator.WeeklyLikes)
                {
                    if (like >= likeThreshold)
                        count++;
                }
                if (count > 0)
                {
                    result.Add(creator.CreatorName, count);
                }
            }
            return result;
        }
        public double CalculateAverageLikes()
        {
            double total = 0;
            int count = 0;
            foreach(var creator in EngagementBoard)
            {
                foreach(var like in creator.WeeklyLikes)
                {
                    total += like;
                    count++;
                }
            }
            return total / count;
        }
        static void Main(string[] args)
        {
            StreamBuzz sb= new StreamBuzz();
            while (true)
            {
                Console.WriteLine("1. Register Creator");
                Console.WriteLine("2. Show Top Posts");
                Console.WriteLine("3. Calculate Average Likes");
                Console.WriteLine("4. Exit");

                Console.WriteLine("Enter your choice:");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    CreatorStats cs=new CreatorStats();
                    Console.WriteLine("Enter Creator Name:");
                    cs.CreatorName= Console.ReadLine();
                    Console.WriteLine("Enter weekly likes(Week 1 to 4)");
                    cs.WeeklyLikes = new double[4]; 
                    for(int i = 0; i < 4; i++)
                    {
                        cs.WeeklyLikes[i]=double.Parse(Console.ReadLine());
                    }
                    sb.RegisterCreator(cs);
                    Console.WriteLine("Creator registered successfully");


                }
                else if (choice == 2)
                { 
                    Console.WriteLine("Enter like threshold:");
                    double threshold = double.Parse(Console.ReadLine());
                    var result = sb.GetTopPostCounts(EngagementBoard, threshold);
                    if (result.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var i in result)
                        {
                            Console.WriteLine($"{i.Key} - {i.Value}" );
                        }
                    }
                }
                else if (choice == 3)
                {
                    double avg = sb.CalculateAverageLikes();
                    Console.WriteLine("Overall average weekly likes: "+avg);
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    break;
                }


            }
        }
    }
}

