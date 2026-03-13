using Microsoft.AspNetCore.Mvc;
using MVCModel.Models;
using System.Diagnostics;

namespace MVCModel.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult DashBoard()
        {
            List<Employee> employees = new List<Employee>()
            {
            new Employee{EmployeeId=1,Name="Anjali", Position="Software Engineer",Salary=70000},
            new Employee{EmployeeId=2,Name="Dhrupad", Position="Full Stack Engineer",Salary=175000},
            new Employee{EmployeeId=3,Name="Aastha", Position="Backend Developer",Salary=50000},
            new Employee{EmployeeId=4,Name="Rishabh", Position="QA Engineer",Salary=30000}
            };
            ViewBag.Announcement = "Team meeting today at 7 PM in Conference Room.";

            ViewData["DepartmentName"] = "IT Department";
            ViewData["ServerStatus"] = true;
            return View(employees);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
