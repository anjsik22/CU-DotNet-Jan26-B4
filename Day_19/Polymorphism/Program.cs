namespace OOPSLearning
{
    abstract class Vehicle
    {
        public string ModelName { get; set; }

        public Vehicle(string modelName)
        {
            ModelName = modelName;
        }
        public abstract void Move();
 
        public virtual string GetFuelStatus()
        {
            return $"Fuel level is stable.";
        }

    }

    class ElectricCar : Vehicle
    {
        public ElectricCar(string modelName) : base(modelName) { }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is gliding silently on battery power.");
        }
        public override string GetFuelStatus()
        {
            return $"{ModelName} battery is at 80%";
        }
    }

    class HeavyTruck : Vehicle
    {
        public HeavyTruck(string modelName) : base(modelName)
        {
        }

        public override void Move()
        {
            Console.WriteLine($"{ModelName} is hauling cargo with high-torque diesel power.");
        }
    }

    class CargoPlane: Vehicle
    {
        public CargoPlane(string modelName) : base(modelName)
        {
        }

        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet.");
        }
        public override string GetFuelStatus()
        {
            return base.GetFuelStatus() + " Checking jet fuel reserves...";
        }
    }

     internal class Polymorphism
     {
        static void Main(string[] args)
        {
            Vehicle[] fleet = new Vehicle[3];
            fleet[0] = new ElectricCar("Tesla");
            fleet[1] = new HeavyTruck("Volvo");
            fleet[2] = new CargoPlane("Boeing");
            

            for(int i=0;i<fleet.Length;i++)
            {
                fleet[i].Move();
                Console.WriteLine(fleet[i].GetFuelStatus());
                Console.WriteLine();
            }
        }
    }
}


