namespace OOPSLearning
{
    abstract class UtilityBill
    {
        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public decimal UnitsConsumed { get; set; }
        public decimal RatePerUnit { get; set; }

        protected UtilityBill(int id, string name, decimal units, decimal rate)
        {
            ConsumerId = id;
            ConsumerName = name;
            UnitsConsumed = units;
            RatePerUnit = rate;
        }

        public abstract decimal CalculateBillAmount();

        public virtual decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.05m;
        }

        public void PrintBill()
        {
            decimal billAmount=CalculateBillAmount();
            decimal tax=CalculateTax(billAmount);
            decimal total = billAmount + tax;
            Console.WriteLine($"Consumer Id- {ConsumerId}\nConsumer Name - {ConsumerName}\n"+
                $"Total Units - {UnitsConsumed}\nTotal Amount - {total}");
        }
    }

    class ElectricityBill : UtilityBill
    {
        public ElectricityBill(int id, string name, decimal units, decimal rate): base(id,name,units,rate) { }
        public override decimal CalculateBillAmount() 
        {
            decimal amount = UnitsConsumed * RatePerUnit;
            if (UnitsConsumed > 300)
            {
                amount += amount * 0.1m;
            }
            return amount;
        }
    }

    class WaterBill: UtilityBill
    {
        public WaterBill(int id, string name, decimal units, decimal rate) : base(id, name, units, rate) { }
        public override decimal CalculateBillAmount()
        {
            return UnitsConsumed * RatePerUnit;
        }
        public override decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.02m;
        }

    }

    class GasBill : UtilityBill
    {
        public GasBill(int id, string name, decimal units, decimal rate) : base(id, name, units, rate) { }
        public override decimal CalculateBillAmount()
        {
            return (UnitsConsumed* RatePerUnit)+150;
        }
        public override decimal CalculateTax(decimal billAmount)
        {
            return 0;
        }
    }
    internal class AbstractOverride
    {
        static void Main(string[] args)
        {
            List<UtilityBill> bills = new List<UtilityBill>()
            {
                new ElectricityBill(101, "Anjali", 350, 6),
                new WaterBill(111, "Raj", 400, 7),
                new GasBill(211, "Dhrupad", 210, 5)
            };
            foreach (UtilityBill bill in bills)
            {
                bill.PrintBill();
                Console.WriteLine();
            }
            
        }
    }
}
