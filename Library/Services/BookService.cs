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
        public Book Get(int id)
        {
            return bookRepository.Find(id);
        }
        public void Loan()
        {

        }

        internal IEnumerable<Book> All()
        {
            return bookRepository.All();
        }

        internal void Edit(Book book)
        {
            bookRepository.Edit(book);
        }

        public bool BookExists(int id)
        {
            return bookRepository.BookExists(id);
        }

        internal void Delete(int id)
        {
            var book = Get(id);
            bookRepository.Remove(book);
        }
    }
}
