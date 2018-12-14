using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookService 
    {
        private readonly BookRepository bookRepository;

        public BookService(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void Add(Book book)
        {
            try
            {
                bookRepository.Add(book);
            }
            catch (Exception)
            {

                //UI
            }
            
        }

        internal IEnumerable<Book> All()
        {
            return bookRepository.All();
        }
    }
}
