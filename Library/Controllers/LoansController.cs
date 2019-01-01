using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;
using Library.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Library.Controllers
{
    public class LoansController : Controller
    {
        private readonly LibraryContext _context;

        public LoansController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Loans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Loans.ToListAsync());
        }

        // GET: Loans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // GET: Loans/Create
        public IActionResult Create()
        {
            var vm = new LoanCreateVM();
            vm.Books = _context.Books.ToList().OrderBy(x => x.Title).Select(x =>
              new SelectListItem
              {
                  Text = $"{x.Title}",
                  Value = x.ID.ToString()
              });
            vm.Members = _context.Members.ToList()
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x =>
              new SelectListItem
              {
                  Text = $"{x.FirstName} {x.LastName}",
                  Value = x.SSN.ToString()
              });

            return View(vm);
        }

        // POST: Loans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoanCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                var bookToLoan = await _context.Books.Include(x => x.BookCopeis).FirstOrDefaultAsync(x => x.ID == vm.BookID);
                var copyToLoan = GetAvailableCopy(bookToLoan);
                if (copyToLoan == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Det finns ingen kopia av denna bok tillgänglig");
                }
                
                var newLoan = new Loan();
                newLoan.BookCopy = copyToLoan;
                newLoan.Member = await _context.Members.FirstAsync(x => x.SSN == vm.MemberID);
                newLoan.LoanTime = DateTime.Now;
                newLoan.DueDate = newLoan.LoanTime.AddDays(15);

                // Kolla att det finns en kopia att låna
                // Tilldela lånet en kopia

                _context.Add(newLoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Loans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LoanTime,DueDate,ReturnDate")] Loan loan)
        {
            if (id != loan.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanExists(loan.ID))
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
            return View(loan);
        }

        // GET: Loans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanExists(int id)
        {
            return _context.Loans.Any(e => e.ID == id);
        }

        private BookCopy GetAvailableCopy(Book book)
        {
            if (book.BookCopeis == null)
            {
                return null;
            }
            foreach (BookCopy copy in book.BookCopeis)
            {
                if (!_context.Loans.Where(x => x.BookCopy == copy && x.ReturnDate == null).Any())
                {
                    return copy;
                }
            }
            return null;
        }

    }
}
