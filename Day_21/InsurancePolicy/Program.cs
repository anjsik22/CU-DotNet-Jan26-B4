using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSLearning
{
    class Policy
    {
        public string HolderName { get; set; }
        public decimal Premium { get; set; }
        public int RiskScore { get; set; }
        public DateTime RenewalDate { get; set; }

        public override string ToString()
        {
            return $"Name - {HolderName} Premium - {Premium} " +
                $"RiskScore - {RiskScore} RenewalDate - {RenewalDate}";
        }
    }
    class InsurancePolicy
    {
        Dictionary<string, Policy> policies = new Dictionary<string, Policy>();
        public bool AddPolicy(string policyId, Policy policy)
        {
            if (policies.ContainsKey(policyId))
                return false;

            policies.Add(policyId, policy);
            return true;
        }

        public void BulkAdjustment()
        {
            foreach (Policy policy in policies.Values)
            {
                if (policy.RiskScore > 75)
                {
                    policy.Premium += policy.Premium * 0.05m;
                }
            }
        }

        public void CleanUp()
        {
            List<string> keysToRemove = new List<string>();

            foreach (var item in policies)
            {
                if (item.Value.RenewalDate < DateTime.Now.AddYears(-3))
                {
                    keysToRemove.Add(item.Key);
                }
            }

            foreach (string key in keysToRemove)
            {
                policies.Remove(key);
            }
        }

        public string SecurityCheck(string policyId)
        {
            if (policies.TryGetValue(policyId, out Policy policy))
            {
                return policy.ToString();
            }

            return "Policy Not Found";
        }

        public void DisplayAllPolicies()
        {
            foreach (var policy in policies.Values)
            {
                Console.WriteLine(policy);
            }
        }
    }

    internal class PolicyTracker
    {
        static void Main(string[] args)
        {
            InsurancePolicy tracker = new InsurancePolicy();

            tracker.AddPolicy("P101", new Policy
            {
                HolderName = "Anjali",
                Premium = 12000m,
                RiskScore = 80,
                RenewalDate = DateTime.Now.AddYears(-1)
            });

            tracker.AddPolicy("P102", new Policy
            {
                HolderName = "Rahul",
                Premium = 10000m,
                RiskScore = 65,
                RenewalDate = DateTime.Now.AddYears(-4)
            });

            tracker.AddPolicy("P103", new Policy
            {
                HolderName = "Dhrupad",
                Premium = 15000m,
                RiskScore = 90,
                RenewalDate = DateTime.Now
            });

            tracker.BulkAdjustment();
            tracker.CleanUp();

            Console.WriteLine(tracker.SecurityCheck("P101"));
            Console.WriteLine(tracker.SecurityCheck("P999"));
        }
    }

}
