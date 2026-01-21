class Employee
{
    public int id;
    public string Name { get; set; }

    private string department;

    public string Department
    {
        get { return department; }
        set
        {
            if (value == "Sales" || value == "Account" || value == "IT")
            {
                department = value;
            }
        }
    }
    private int salary;

    public int Salary
    {
        get { return salary; }
        set { salary = value; }
    }


    public void Display()
    {
        Console.WriteLine($"Employee id: {id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Salary: {Salary}");
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Employee emp1=new Employee();
        emp1.id = 101;
        emp1.Name = "Anjali";
        emp1.Department = "Sales";
        emp1.Salary = 50000;
        emp1.Display();

        
    }
}
