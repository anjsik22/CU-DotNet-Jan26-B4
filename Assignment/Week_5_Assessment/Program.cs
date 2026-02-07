using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace OOPSLearning
{
    class RestrictedDestinationException : Exception
    {
        public RestrictedDestinationException(string destination)
        : base("Restricted destination: " + destination)
        {
        }
    }
    class InsecurePackagingException : Exception
    {
        public InsecurePackagingException(string message) : base(message)
        {

        }
    }
    interface ILoggable
    {
        void SaveLog(string message);
    }



    abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }

        public abstract void ProcessShipment();
    }
    class ExpressShipment : Shipment
    {
        public bool Fragile;
        public bool Reinforced;

        public override void ProcessShipment()
        {
            if (Weight <= 0)
            {
                throw new ArgumentOutOfRangeException("Weight must be greater than zero");
            }
            if (Destination == "North Pole" || Destination == "Unknown Island")
            {
                throw new RestrictedDestinationException(Destination);
            }
            if (Fragile && !Reinforced)
            {
                throw new InsecurePackagingException("Fragile shipment requires reinforced packaging");
            }
            Console.WriteLine("Express Shipment processed successfully: " + TrackingId);
        }
    }
    class HeavyFreight : Shipment
    {
        public bool HeavyLiftPermit;
        public override void ProcessShipment()
        {
            if (Weight <= 0)
            {
                throw new ArgumentOutOfRangeException("Weight must be greater than zero");
            }
            if (Destination == "North Pole" || Destination == "Unknown Island")
            {
                throw new RestrictedDestinationException(Destination);
            }
            if (Weight > 1000 && !HeavyLiftPermit)
            {
                throw new Exception("Heavy Lift permit required for shipment");
            }
            Console.WriteLine("Heavy freight processed successfully: " + TrackingId);
        }
    }


    class LogManager : ILoggable
    {
        public void SaveLog(string message)
        {
            string fileName = @"..\..\..\shipment_audit.log";
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(message);
            }
        }

    }
    internal class SwiftRoute
    {
        static void Main(string[] args)
        {
            LogManager logger = new LogManager();
            List<Shipment> shipments = new List<Shipment>
            {
                new ExpressShipment
                {
                    TrackingId="EXP001",
                    Weight=20,
                    Destination="Delhi",
                    Fragile=true,
                    Reinforced=false
                },
                new HeavyFreight
                {
                    TrackingId="HF001",
                    Weight=1500,
                    Destination="Mumbai",
                    HeavyLiftPermit=false,
                },
                new ExpressShipment
                {
                    TrackingId="EXP002",
                    Weight=-10,
                    Destination="Chennai",
                    Fragile=false,
                    Reinforced=false
                },
                new HeavyFreight
                {
                    TrackingId="HF002",
                    Weight=800,
                    Destination="North Pole",
                    HeavyLiftPermit=true
                },
                new ExpressShipment
                {
                    TrackingId = "EXP100",
                    Weight = 50,
                    Destination = "Delhi",
                    Fragile = false,
                    Reinforced = false
                }

            };
            foreach (Shipment shipment in shipments)
            {
                try
                {
                    shipment.ProcessShipment();
                    logger.SaveLog("SUCCESS: Shipment " + shipment.TrackingId);
                }
                catch (RestrictedDestinationException ex)
                {
                    logger.SaveLog("SECURITY ALERT: " + ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    logger.SaveLog("DATA ENTRY ERROR: " + ex.Message);
                }
                catch (InsecurePackagingException ex)
                {
                    logger.SaveLog("PACKAGING ERROR: " + ex.Message);
                }
                catch (Exception ex)
                {
                    logger.SaveLog("ERROR: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Processing attempt finished for ID: " + shipment.TrackingId);
                }
            }
        }
    }
}

