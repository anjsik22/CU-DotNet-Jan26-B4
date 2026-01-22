internal class Program1
{
    static void Main(string[] args)
    {
        Height person1=new Height(5,6.5);
        Height person2=new Height(67.5);

        Height total=person1.AddHeights(person2);

        Console.WriteLine(person1);
        Console.WriteLine(person2);
        Console.WriteLine(total);
    }
}
class Height
{
    public int Feet { get; set; }
    public double Inches { get; set; }

    //Default Constructor 
    public Height() 
    {
        Feet = 0;
        Inches = 0.0;
    }

    //Parameterized Constructor
    public Height(int feet, double inches)
    {
        Feet = feet;
        Inches = inches;
    }

    //constructor which take only single parameter
    public Height(double totalInches)
    {
        if (totalInches >= 12)
        {
            Feet = (int)totalInches / 12;
            Inches = totalInches % 12;
        }
        else
        {
            Feet = 0;
            Inches = totalInches;
        }
    }

    //Method
    public Height AddHeights(Height h2)
    {
        int totalFeet = this.Feet + h2.Feet;
        double totalInches=this.Inches + h2.Inches;

        if (totalInches >= 12)
        {
            totalFeet += (int)(totalInches / 12);
            totalInches = totalInches % 12;
        }
        return new Height(totalFeet, totalInches);
    }

    //Override
    public override string ToString()
    {
        return $"Height - {Feet} feet {Inches} inches";
    }
}

