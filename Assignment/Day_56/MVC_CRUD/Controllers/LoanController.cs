using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class LoanController : Controller
    {
        private static List<Loan> loans=new List<Loan>();
        private static int nextId = 1;
        // GET: LoanController
        public ActionResult Index()
        {
            return View(loans);
        }

        // GET: LoanController/Details/5
        public ActionResult Details(int id)
        {
            var loan = loans.FirstOrDefault(x => x.LoanId == id);
            return View(loan);
        }

        // GET: LoanController/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: LoanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Loan loan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    loan.LoanId = nextId++;
                    loans.Add(loan);
                    return RedirectToAction(nameof(Index));
                }

                return View(loan);
            }
            catch
            {
                return View();
            }
        }

        // GET: LoanController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var loan = loans.FirstOrDefault(x => x.LoanId == id);
            return View(loan);
        }

        // POST: LoanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Loan loan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingLoan = loans.FirstOrDefault(x => x.LoanId == loan.LoanId);

                    if (existingLoan != null)
                    {
                        existingLoan.BorrowerName = loan.BorrowerName;
                        existingLoan.LenderName = loan.LenderName;
                        existingLoan.Amount = loan.Amount;
                        existingLoan.IsSettled = loan.IsSettled;
                    }

                    return RedirectToAction(nameof(Index));
                }

                return View(loan);
            }
            catch
            {
                return View(loan);
            }
        }

        

        // GET: LoanController/Delete/5
        public ActionResult Delete(int id)
        {
            var loan = loans.FirstOrDefault(x => x.LoanId == id);
            return View(loan);
        }

        // POST: LoanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Loan loan)
        {
            try
            {
                var existingLoan = loans.FirstOrDefault(x => x.LoanId == id);

                if (existingLoan != null)
                {
                    loans.Remove(existingLoan);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
