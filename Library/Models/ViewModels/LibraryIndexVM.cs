using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.ViewModels
{
    public class LibraryIndexVM
    {
        public LibraryIndexVM()
        {

        }
        public IEnumerable<Book> Books { get; set; } 
        public Book newBook { get; set; }
    }
}
