
namespace week6Learning
{
    interface ITimer
    {
        void SetTimer(int minutes);
    }

    interface IWifiEnabled
    {
        void ConnectWifi(string network);
    }

    abstract class KitchenAppliance
    {
        public string ModelName { get; set; }
        public int PowerWatts { get; set; }
      
        public abstract void Cook();

        public virtual void Preheat()
        {
            Console.WriteLine($"{ModelName}: No preheating required.");
        }
    }

    class Microwave : KitchenAppliance, ITimer
    {
        public void SetTimer(int minutes)
        {
            Console.WriteLine($"{ModelName}: Timer set for {minutes} minutes.");
        }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: Microwaving food...");
        }
    }

    class ElectricOven : KitchenAppliance, ITimer, IWifiEnabled
    {
        public void SetTimer(int minutes)
        {
            Console.WriteLine($"{ModelName}: Oven timer set for {minutes} minutes.");
        }

        public void ConnectWifi(string network)
        {
            Console.WriteLine($"{ModelName}: Connected to WiFi - {network}");
        }

        public override void Preheat()
        {
            Console.WriteLine($"{ModelName}: Preheating oven...");
        }

        public override void Cook()
        {
            Preheat();
            Console.WriteLine($"{ModelName}: Baking in oven...");
        }
    }

    class AirFryer : KitchenAppliance
    {
        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: Air frying quickly...");
        }
    }

    internal class SmartKitchen
    {
        static void Main(string[] args)
        {
            var devices = new List<KitchenAppliance>
        {
            new Microwave { ModelName = "MW-101", PowerWatts = 1200 },
            new ElectricOven { ModelName = "OV-500", PowerWatts = 2000 },
            new AirFryer { ModelName = "AF-50", PowerWatts = 1500 }
        };

            Console.WriteLine("=== Cooking Test ===");

            foreach (var device in devices)
            {
                device.Cook();
                Console.WriteLine();
            }

            Console.WriteLine("=== WiFi Test ===");

            foreach (var device in devices)
            {
                if (device is IWifiEnabled wifiDevice)
                {
                    wifiDevice.ConnectWifi("HomeWiFi");
                }
                else
                {
                    Console.WriteLine($"{device.ModelName}: No WiFi support.");
                }
            }
        }
    }
}

