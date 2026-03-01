using ClassLibrary1;
namespace TestEmployee
{
    public class Tests
    {
        private Class1 emp;
        [SetUp]
        public void Setup()
        {
            emp = new Class1();
        }

        [Test]
        public void NormalHighPerformer_Test()
        {
            emp.BaseSalary = 500000m;
            emp.PerformanceRating = 5;
            emp.YearsOfExperience = 6;
            emp.DepartmentMultiplier = 1.1m;
            emp.AttendancePercentage = 95;

            Assert.AreEqual(123200.00m, emp.NetAnnualBonus);
        }
        [Test]
        public void AttendancePenalty_Test()
        {
            emp.BaseSalary = 400000m;
            emp.PerformanceRating = 4;
            emp.YearsOfExperience = 8;
            emp.DepartmentMultiplier = 1.0m;
            emp.AttendancePercentage = 80;

            Assert.AreEqual(60480.00m, emp.NetAnnualBonus);
        }
        [Test]
        public void CapTriggered_Test()
        {
            emp.BaseSalary = 1000000m;
            emp.PerformanceRating = 5;
            emp.YearsOfExperience = 15;
            emp.DepartmentMultiplier = 1.5m;
            emp.AttendancePercentage = 95;

            Assert.AreEqual(280000.00m, emp.NetAnnualBonus);
        }
        [Test]
        public void ZeroSalary_Test()
        {
            emp.BaseSalary = 0;

            Assert.AreEqual(0.00m, emp.NetAnnualBonus);
        }
        [Test]
        public void LowPerformer_Test()
        {
            emp.BaseSalary = 300000m;
            emp.PerformanceRating = 2;
            emp.YearsOfExperience = 3;
            emp.DepartmentMultiplier = 1.0m;
            emp.AttendancePercentage = 90;

            Assert.AreEqual(13500.00m, emp.NetAnnualBonus);
        }
        [Test]
        public void ExactBoundary_Test()
        {
            emp.BaseSalary = 600000m;
            emp.PerformanceRating = 3;
            emp.YearsOfExperience = 0;
            emp.DepartmentMultiplier = 1.0m;
            emp.AttendancePercentage = 100;

            Assert.AreEqual(64800.00m, emp.NetAnnualBonus);
        }
        [Test]
        public void HighTaxSlab_Test()
        {
            emp.BaseSalary = 900000m;
            emp.PerformanceRating = 5;
            emp.YearsOfExperience = 11;
            emp.DepartmentMultiplier = 1.2m;
            emp.AttendancePercentage = 100;

            Assert.AreEqual(226800.00m, emp.NetAnnualBonus);
        }
        [Test]
        public void RoundingPrecision_Test()
        {
            emp.BaseSalary = 555555m;
            emp.PerformanceRating = 4;
            emp.YearsOfExperience = 6;
            emp.DepartmentMultiplier = 1.13m;
            emp.AttendancePercentage = 92;

            Assert.AreEqual(118649.88m, emp.NetAnnualBonus);
        }
    }
}