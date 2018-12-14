using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models.ViewModels;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        private readonly AuthorService AuthorService;
        private readonly BookService bookService;

        public LibraryController(AuthorService authorService,BookService bookService)
        {
            AuthorService = authorService;
            this.bookService = bookService;
        }

        

        public IActionResult Index()
        {
            var vm = new LibraryIndexVM();
            vm.Books = bookService.All();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(LibraryIndexVM vm)
        {

            bookService.Add(vm.newBook);
            
            return View(vm);
        }
    }
}