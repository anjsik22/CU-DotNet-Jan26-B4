namespace week6Learning
{
    internal class expense
    {
        static List<string> ExpenseSplit(Dictionary<string, double> money)
        {
            List<string> settlement = new List<string>();
            Queue<KeyValuePair<string, double>> reciever = new Queue<KeyValuePair<string, double>>();
            Queue<KeyValuePair<string, double>> payer = new Queue<KeyValuePair<string, double>>();


            var totalExpense = money.Values.Sum();
            var persons = money.Count;

            var share = totalExpense / persons;

            foreach (var person in money)
            {
                if (person.Value > share)
                {
                    reciever.Enqueue(
                        new KeyValuePair<string, double>(person.Key,
                        Math.Abs(person.Value - share))
                    );
                }
                else if (person.Value < share)
                {
                    payer.Enqueue(
                        new KeyValuePair<string, double>(person.Key,
                        Math.Abs(person.Value - share))
                    );

                }

            }
            while (payer.Count > 0 && reciever.Count > 0)
            {
                var payers = payer.Dequeue();
                var recievers = reciever.Dequeue();
                var payment = Math.Min(payers.Value, recievers.Value);

                settlement.Add($"{payers.Key},{recievers.Key},{payment}");

                
                if (payers.Value > payment)
                {
                    payer.Enqueue(
                        new KeyValuePair<string, double>(payers.Key,
                        Math.Abs(payment - payers.Value))
                    );
                }

                if (recievers.Value > payment)
                {
                    reciever.Enqueue(
                        new KeyValuePair<string, double>(recievers.Key,
                        Math.Abs(payment - recievers.Value))
                    );
                }

            }
            return settlement;
        }
        static void Main(string[] args)
        {
            Dictionary<string, double> money = new Dictionary<string, double>()
            {
                {"Anjali", 2000},
                {"Dhrupad", 900  },
                {"Raj", 2000},
                {"Aastha",700 }
            };
            List<string> settlement = ExpenseSplit(money);
            foreach (var item in settlement)
            {
                Console.WriteLine(item);
            }
            //for two person
            //Console.WriteLine("Enter first person money");
            //int money1 = int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter second person money");
            //int money2= int.Parse(Console.ReadLine());

            //int avg = (money1 + money2) / 2;
            //if (money1 > avg)
            //{
            //    money2 += (money1 - avg);
            //    Console.WriteLine($"Person 1 give {money1-avg} money to Person2");
            //}
            //else
            //{
            //    money1 += (money2 - avg);
            //    Console.WriteLine($"Person 2 give {money2 - avg} money to Person1");
            //}

            //Dictionary<string,int> money= new Dictionary<string, int>();
            //int sum = 0;
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.Write($"Enter name of person{i+1}: ");
            //    string name = Console.ReadLine();
            //    Console.Write($"Enter money given by person{i+1}: ");
            //    int value=int.Parse(Console.ReadLine());
            //    money.Add(name, value);
            //}
            //foreach (var item in money)
            //{
            //    sum += item.Value;
            //}
            //int avg = sum / 3;

            //while (true)
            //{
            //    string payer = null;
            //    string receiver = null;

            //    // find one payer and one receiver
            //    foreach (var p in money)
            //    {
            //        if (p.Value < avg && payer == null)
            //            payer = p.Key;

            //        else if (p.Value > avg && receiver == null)
            //            receiver = p.Key;
            //    }

            //    // no more settlement needed
            //    if (payer == null || receiver == null)
            //        break;

            //    int payNeed = avg - money[payer];
            //    int receiveNeed = money[receiver] - avg;

            //    int transfer = Math.Min(payNeed, receiveNeed);

            //    // ACTUAL update
            //    money[payer] += transfer;
            //    money[receiver] -= transfer;

            //    Console.WriteLine($"{payer} pays {receiver} {transfer}");
            //}
            
            
        }
    }
}

