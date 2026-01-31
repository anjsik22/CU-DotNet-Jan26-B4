using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace OOPSLearning
{
    class Patient
    {
        public string Name { get; set; }
        public decimal BaseFee { get; set; }

        virtual public decimal CalculateFinalBill()
        {
            return BaseFee;
        }
    }
    class Inpatient:Patient
    {
        
        public int DaysStayed { get; set; }
        public decimal DailyRate { get; set; }

        public override decimal CalculateFinalBill()
        {
            decimal total = BaseFee + (DaysStayed*DailyRate);
            return total;
        }
    }
    class OutPatient : Patient
    {
        public decimal ProcedureFee { get; set; }

        public override decimal CalculateFinalBill()
        {
            decimal total = BaseFee + ProcedureFee;
            return total;
        }
    }
    class EmergencyPatient : Patient
    {
        public int SeverityLevel { get; set; }
        public override decimal CalculateFinalBill()
        {
            return BaseFee * SeverityLevel;
        }
    }
    class HospitalBilling
    {
        List<Patient> patients = new List<Patient>();
        public void AddPatient(Patient p)
        {
            patients.Add(p);
        }

        public void GenerateDailyReport()
        {
            foreach (Patient p in patients)
            {
                Console.WriteLine($"{p.Name} - {p.CalculateFinalBill().ToString("C2")}");
            }
        }
        public decimal CalculateTotalRevenue()
        {
            decimal total = 0;
            foreach (Patient p in patients)
            {
                total += p.CalculateFinalBill();
            }
            return total;
        }

        public int GetInPatient()
        {
            int count = 0;
            foreach (Patient p in patients)
            {
                if( p is Inpatient)
                {
                    count++;
                }

            }
            return count;
            
        }
    }
    internal class Hospital
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            HospitalBilling billing = new HospitalBilling();
            billing.AddPatient(new Inpatient
            {
                Name = "Anjali",
                BaseFee = 1500m,
                DaysStayed=3,
                DailyRate=1000m
            });
            billing.AddPatient(new OutPatient
            {
                Name="Rahul",
                BaseFee=1000m,
                ProcedureFee=2000m
            });
            billing.AddPatient(new EmergencyPatient
            {
                Name = "Dhrupad",
                BaseFee = 3000m,
                SeverityLevel=4
            });
            Console.WriteLine("Daily Report");
            billing.GenerateDailyReport();

            Console.WriteLine($"Total Revenue : {billing.CalculateTotalRevenue().ToString("C2")}");
            Console.WriteLine($"InPatient Count : {billing.GetInPatient()}");
        }
    }
}

