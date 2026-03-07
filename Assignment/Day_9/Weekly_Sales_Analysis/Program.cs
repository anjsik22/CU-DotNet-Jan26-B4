using System;

class Program
{
    static void Main(string[] args)
    {
        decimal[] sales= new decimal[7];

        //-------User Input--------
        for (int i = 0; i < sales.Length; i++)
        {
            while (true)
            {
                Console.Write($"Enter sales for Day {i + 1}: ");
                decimal value = decimal.Parse(Console.ReadLine());
                
                if (value >= 0)
                {
                    sales[i]=value;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input! Sales must be >= 0. Please re-enter.");
                }
            }
        }

        //------Weekly Sales Analysis------

        // Total Sales
        decimal totalSales = 0;
        for (int i = 0; i < sales.Length; i++)
        {
            totalSales += sales[i];
        }

        // Average Sales
        decimal averageSales = totalSales / sales.Length;

        // Highest and Lowest Sales
        decimal highestSales=sales[0];
        decimal lowestSales=sales[0];
        int highestDay=1;
        int lowestDay=1;

        for(int i=0; i < sales.Length; i++)
        {
            if (sales[i] > highestSales)   //Finding Highest Sales Day
            {
                highestSales=sales[i];
                highestDay=i+1;
            }
            if (sales[i] < lowestSales)   //Finding Lowest Sales Day
            {
                lowestSales=sales[i];
                lowestDay=i+1;
            }

        }

        // Days Above Average
        int daysAboveAverage = 0;
        for (int i = 0; i < sales.Length; i++)
        {
            if (sales[i] > averageSales)
            {
                daysAboveAverage++;
            }
        }

        //------Sales Categorization------
        string[] category=new string[7];

        for(int i = 0; i < sales.Length; i++)
        {
            if (sales[i] < 5000)
            {
                category[i]="LOW";
            }
            else if(sales[i]>5000 && sales[i] <= 10000)
            {
                category[i]="MEDIUM";
            }
            else
            {
                category[i]="HIGH";
            }
        }

        //------Output------
       Console.WriteLine("\nWeekly Sales Report");
       Console.WriteLine("-------------------");

       Console.WriteLine($"Total Sales        : {totalSales:F2}");
       Console.WriteLine($"Average Daily Sale : {averageSales:F2}\n");
       
       Console.WriteLine($"Highest Sale       : {highestSales:F2} (Day {highestDay})");
       Console.WriteLine($"Lowest Sale        : {lowestSales:F2}  (Day {lowestDay})\n");
       
       Console.WriteLine($"Days Above Average : {daysAboveAverage}\n");
       
       Console.WriteLine("Day-Wise Sales Category:\n");
       for (int i = 0; i < category.Length; i++)
       {
        Console.WriteLine($"Day {i + 1} : {category[i]}");
       }

    }
 }

    

