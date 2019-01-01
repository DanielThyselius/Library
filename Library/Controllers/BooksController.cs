using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;
using Library.Services;
using Library.Models.ViewModels;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Books
        public IActionResult Index()
        {
            var vm = new BookIndexVM();
            vm.Books = _context.Books
                .Include("Author")
                .Include(x => x.BookCopeis)
                .ToList();

            vm.Authors = _context.Authors.ToList().OrderBy(x => x.FirstName).Select(x =>
               new SelectListItem
               {
                   Text = $"{x.FirstName}  {x.LastName}",
                   Value = x.ID.ToString()
               });

            return View(vm);
        }


        // GET: Availible Books
        public IActionResult Available()
        {
            var vm = new BookIndexVM();
            vm.Books = _context.Books
                .Include("Author")
                .Include(x => x.BookCopeis)
                .ToList()
                .Where(x => IsAvailable(x));
            vm.Authors = _context.Authors.ToList().OrderBy(x => x.FirstName).Select(x =>
              new SelectListItem
              {
                  Text = $"{x.FirstName}  {x.LastName}",
                  Value = x.ID.ToString()
              });
            return View("Index", vm);
        }

        // POST: Filter on Author
        public IActionResult FilterOnAuthor(BookIndexVM vm)
        {
            vm.Books = _context.Books
                .Where(x => x.Author == vm.Author)
                .Include("Author")
                .Include(x => x.BookCopeis)
                .ToList();
            vm.Authors = _context.Authors.ToList().OrderBy(x => x.FirstName).Select(x =>
              new SelectListItem
              {
                  Text = $"{x.FirstName}  {x.LastName}",
                  Value = x.ID.ToString()
              });
            return View("Index", vm);
        }



        // GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _context.Books
                .FirstOrDefault(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewBag.Authors = _context.Authors.ToList().OrderBy(x => x.FirstName).Select(x =>
                new SelectListItem
                {
                    Text = $"{x.FirstName}  {x.LastName}",
                    Value = x.ID.ToString(),
                });
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,ISBN,Title,Description,Author")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Author = _context.Authors.Find(book.Author.ID);
                _context.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int id)
        {

            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,ISBN,Title,Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (BookExists(book.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _context.Books
                .FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.ID == id);
        }

        private bool IsAvailable(Book book)
        {
            if (book.BookCopeis == null)
            {
                return false;
            }
            foreach (BookCopy copy in book.BookCopeis)
            {
                if (!_context.Loans.Where(x => x.BookCopy == copy && x.ReturnDate == null).Any())
                {
                    return true;
                }
            }
            return false;
        }

    }
}
