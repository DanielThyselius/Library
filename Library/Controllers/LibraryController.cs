using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models.ViewModels;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        private readonly LibraryContext _context;

        public LibraryController(LibraryContext context)
        {
            _context = context;
        }

        

        public IActionResult Index()
        {
            var vm = new LibraryIndexVM();
            vm.Books = _context.Books;
            vm.Authors = _context.Authors.ToList().OrderBy(x => x.FirstName).Select(x =>
                new SelectListItem
                {
                    Text = $"{x.FirstName}  {x.LastName}",
                    Value = x.ID.ToString()
                });
            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(LibraryIndexVM vm)
        {
            _context.Add(vm.newBook);
           // AuthorService.Add(vm.newAuthor);
            return View(vm);
        }

        public IActionResult BookInfo()
        {
            return View();
        }


        public IActionResult AddAuthor(LibraryIndexVM vm)
        {
            
            _context.Add(vm.newAuthor);

            return RedirectToAction("Index");
        }

    }
}