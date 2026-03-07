namespace week9
{
    class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Category { get; set; }

        public Item(string name,double weight, string category)
        {
            Name = name;
            Weight = weight;
            Category = category;
        }
    }
    class Container
    {
        public string ContainerID { get; set; }
        public List<Item> Items { get; set; }

        public Container(string id, List<Item> items)
        { 
            ContainerID = id;
            Items = items;
        }
    }
    internal class Program
    {
        public static List<string> FindHeavyContainers(List<List<Container>> cargoBay,double weightThreshold)
        {
            var result = new List<string>();
            if (cargoBay == null)
                return result;
            foreach(var row in cargoBay)
            {
                if (row == null)
                    continue;
                foreach(var container in row)
                {
                    if (container?.Items == null) continue;
                    double totalWeight = 0;
                    foreach(var item in container.Items)
                    {
                        if(item!=null)
                            totalWeight += item.Weight;
                    }
                    if(totalWeight > weightThreshold)
                        result.Add(container.ContainerID);
                }
            }
            return result;
        }

        public static Dictionary<string,int> GetItemCountsByCategory(List<List<Container>> cargoBay)
        {
            var result= new Dictionary<string,int>();
            if (cargoBay == null)
                return result;
            foreach (var row in cargoBay)
            {
                if (row == null)
                    continue;
                foreach (var container in row)
                {
                    if(container?.Items == null) continue;
                    foreach(var item in container.Items)
                    {
                        if (item == null) continue;
                        if (result.ContainsKey(item.Category))
                            result[item.Category]++;
                        else
                            result[item.Category] = 1;
                    }
                }
            }
            return result;
        }

        public static List<Item> FlattenAndSortShipment(List<List<Container>> cargoBay)
        {
            if (cargoBay == null)
                return new List<Item>();
            return cargoBay
                .Where(row => row != null)
                .SelectMany(row => row)
                .Where(container => container?.Items != null)
                .SelectMany(container => container.Items)
                .Where(item => item != null)
                .GroupBy(item => item.Name)
                .Select(group => group.First())
                .OrderBy(item => item.Category)
                .ThenByDescending(item => item.Weight)
                .ToList();

        } 
        static void Main(string[] args)
        {
            var cargoBay = new List<List<Container>>
        {
            new List<Container>
            {
                new Container("C001", new List<Item>
                {
                    new Item("Laptop", 2.5, "Tech"),
                    new Item("Monitor", 5.0, "Tech"),
                    new Item("Smartphone", 0.5, "Tech")
                }),
                new Container("C104", new List<Item>
                {
                    new Item("Server Rack", 45.0, "Tech"),
                    new Item("Cables", 1.2, "Tech")
                })
            },

            // ROW 1: Mixed Consumer Goods
            new List<Container>
            {
                new Container("C002", new List<Item>
                {
                    new Item("Apple", 0.2, "Food"),
                    new Item("Banana", 0.2, "Food"),
                    new Item("Milk", 1.0, "Food")
                }),
                new Container("C003", new List<Item>
                {
                    new Item("Table", 15.0, "Furniture"),
                    new Item("Chair", 7.5, "Furniture")
                })
            },
            // ROW 2: Fragile & Perishables (Includes an Empty Container)
            new List<Container>
            {
                new Container("C205", new List<Item>
                {
                    new Item("Vase", 3.0, "Decor"),
                    new Item("Mirror", 12.0, "Decor")
                }),
                new Container("C206", new List<Item>())
            },
            // ROW 3: EDGE CASE - Empty Row
            new List<Container>() // Empty row
        };

            Console.WriteLine("===== TASK A =====");
            var heavyContainers = FindHeavyContainers(cargoBay, 10);
            foreach (var id in heavyContainers)
                Console.WriteLine(id);

            Console.WriteLine("\n===== TASK B =====");
            var categoryCounts = GetItemCountsByCategory(cargoBay);
            foreach (var kvp in categoryCounts)
                Console.WriteLine($"{kvp.Key} : {kvp.Value}");

            Console.WriteLine("\n===== TASK C =====");
            var finalShipment = FlattenAndSortShipment(cargoBay);
            foreach (var item in finalShipment)
                Console.WriteLine($"{item.Category} - {item.Name} - {item.Weight}");
        }
    }
}


