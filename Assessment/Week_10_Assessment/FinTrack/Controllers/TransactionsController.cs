using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinTrack.Data;
using FinTrack.Models;
using Microsoft.Identity.Client;

namespace FinTrack.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly FinTrackContext _context;

        public TransactionsController(FinTrackContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var finTrackContext = _context.Transaction.Include(t => t.Account);
            return View(await finTrackContext.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountNo");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Amount,Category,Date,AccountId")] Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                             .SelectMany(v => v.Errors)
                             .Select(e => e.ErrorMessage);

                return Content(string.Join("\n", errors));
            }

            // Ensure Amount sign matches Category: Debit => negative, Credit => positive
            if (!string.IsNullOrWhiteSpace(transaction.Category) && transaction.Category.Equals("Debit", StringComparison.OrdinalIgnoreCase))
            {
                transaction.Amount = -Math.Abs(transaction.Amount);
            }
            else
            {
                transaction.Amount = Math.Abs(transaction.Amount);
            }

            _context.Add(transaction);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Accounts");
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountNo", transaction.AccountId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Amount,Category,Date,AccountId")] Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Ensure Amount sign matches Category before saving
                    if (!string.IsNullOrWhiteSpace(transaction.Category) && transaction.Category.Equals("Debit", StringComparison.OrdinalIgnoreCase))
                    {
                        transaction.Amount = -Math.Abs(transaction.Amount);
                    }
                    else
                    {
                        transaction.Amount = Math.Abs(transaction.Amount);
                    }

                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountNo", transaction.AccountId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction != null)
            {
                _context.Transaction.Remove(transaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.Id == id);
        }
    }
}
