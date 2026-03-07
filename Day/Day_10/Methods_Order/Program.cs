using System;

class Program
{
    static void Main(string[] args)
    {
       decimal[] weeklySales=new decimal[7];
       string[] categories=new string[7];

       //Read weekly sales
       ReadWeeklySales(weeklySales);

       //Calculate Total and Average
       decimal total=CalculateTotal(weeklySales);
       decimal average=CalculateAverage(total, weeklySales.Length);

       //Find highest & lowest sales
       int highestDay, lowestDay;
       decimal highestSales=FindHighestSales(weeklySales, out highestDay);
       decimal lowestSales=FindLowestSales(weeklySales, out lowestDay);

       // Discount Calculation
       bool isFestivalWeek=true;
       decimal discount=CalculateDiscount(total, isFestivalWeek);

       //Tax Calculation
       decimal tax=CalculateTax(total-discount);

       //Final Amount 
       decimal finalAmount=CalculateFinalAmount(total,discount,tax);

       //Generate Sales Categories
       GenerateSalesCategory(weeklySales,categories);

       //Display Results
       Console.WriteLine("\nWeekly Sales Summary");
        Console.WriteLine("--------------------");
        Console.WriteLine($"Total Sales        : {total:F2}");
        Console.WriteLine($"Average Daily Sale : {average:F2}\n");

        Console.WriteLine($"Highest Sale       : {highestSales:F2} (Day {highestDay})");
        Console.WriteLine($"Lowest Sale        : {lowestSales:F2}  (Day {lowestDay})\n");

        Console.WriteLine($"Discount Applied   : {discount:F2}");
        Console.WriteLine($"Tax Amount         : {tax:F2}");
        Console.WriteLine($"Final Payable      : {finalAmount:F2}\n");

        Console.WriteLine("Day-wise Category:");
        for (int i = 0; i < categories.Length; i++)
        {
            Console.WriteLine($"Day {i + 1} : {categories[i]}");
        }
    }
    
    //--------Sales Data Input--------
    static void ReadWeeklySales(decimal[] sales)
    {
        for(int i = 0; i < sales.Length; i++)
        {
            while (true)
            {
                Console.Write($"Enter sales for Day {i+1}: ");
                decimal value=decimal.Parse(Console.ReadLine());

                if (value >= 0)
                {
                    sales[i]=value;
                    break;
                }
                else
                {
                    Console.WriteLine("Sales cannot be negative. Try again");
                }
                
            }
        }
    }
    

    //-------Total Calculation-------
    static decimal CalculateTotal(decimal[] sales)
    {
        decimal total=0;
        for(int i = 0; i < sales.Length; i++)
        {
            total+=sales[i];
        }
        return total;
    } 

    //------Average Calculation------
    static decimal CalculateAverage(decimal total, int days)
    {
        return total/days;
    }

    //-------Highest Sales Day-------
    static decimal FindHighestSales(decimal[] sales, out int day)
    {
        decimal highest=sales[0];
        day=1;
        for(int i = 0; i < sales.Length; i++)
        {
            if (sales[i] > highest)
            {
                highest=sales[i];
                day=i+1;
            }
        }
        return highest;
    }

    //--------Lowest Sales Day-------
    static decimal FindLowestSales(decimal[] sales, out int day)
    {
        decimal lowest=sales[0];
        day=1;
        for(int i = 0; i < sales.Length; i++)
        {
            if (sales[i] < lowest)
            {
                lowest=sales[i];
                day=i+1;
            }
        }
        return lowest;
    }

    //-------Discount Calculation-------
    static decimal CalculateDiscount(decimal total)
    {
        return total>=50000 ? total* 0.10m :total*0.05m;
    }

    //--------Festival Discount Calculation--------
    static decimal CalculateDiscount(decimal total, bool isFestivalWeek)
    {
        decimal discount= CalculateDiscount(total);
        if(isFestivalWeek)
        {
            discount+=total*0.05m;
        }
        return discount;
    }

    //--------Tax Calculation--------
    static decimal CalculateTax(decimal amount)
    {
        return amount*0.18m;
    }

    //--------Final Amount Calculation--------
    static decimal CalculateFinalAmount(decimal total, decimal discount, decimal tax)
    {
        return total-discount+tax;
    }

    //--------Sales Category--------
    static void GenerateSalesCategory(decimal[] sales, string[] categories)
    {
        for(int i = 0; i < sales.Length; i++)
        {
            if (sales[i] < 5000)
            {
                categories[i]="Low";
            }
            else if (sales[i] <= 15000)
            {
                categories[i]="Medium";
            }
            else
            {
                categories[i]="High";
            }
        }
    }
    
}
