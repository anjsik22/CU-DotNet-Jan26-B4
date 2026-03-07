namespace OOPSLearning
{
    internal class OrderProcessing
    {
        static void Main(string[] args)
        {
            Order order1= new Order(101,"Rahul");
            order1.AddItem(500);
            order1.AddItem(300);
            order1.ApplyDiscount(10);

            Console.WriteLine(order1.GetOrderSummary());
            Console.WriteLine();

            Order order2 = new Order();
            order2.CustomerName = "Anjali";
            order2.AddItem(1000);
            order2.ApplyDiscount(5);

            Console.WriteLine(order2.GetOrderSummary());


        }
    }
    class Order
    {
        private int _orderId;
        private string _customerName;
        private decimal _totalAmount = 0;
        private string status;
        private DateTime orderDate;
        private bool discountApplied=false;

        //Default Constructor
        public Order()
        {
            orderDate = DateTime.Now;
            status = "New";
        }

        //Parameterized Constructor
        public Order(int orderId, string customerName)
        {
            _orderId = orderId;
            _customerName = customerName;
            orderDate = DateTime.Now;
            status = "New";
        }

        //Properties

        public int OrderId
        {
            get { return _orderId; }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _customerName = value;
                }              
            }
        }

        public decimal TotalAmount
        {
            get { return _totalAmount; }
        }
        //Instance Methods
        public void AddItem(decimal price)
        {
            if (price > 0)
            {
                _totalAmount += price;
            }
        }

        public void ApplyDiscount(decimal percentage)
        {
            if (discountApplied)
                return;
            if(percentage>1 && percentage < 30)
            {
                decimal discount = _totalAmount * percentage / 100;
                _totalAmount -= discount;
                discountApplied = true;
            }
        }
        

        public string GetOrderSummary()
        {
            return
            $"Order Id: {_orderId}\n" +
            $"Customer: {_customerName}\n" +
            $"Total Amount: {_totalAmount}\n" +
            $"Status: {status}";
        }

    }
}
