using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class BookRepository : IRepository<Book, int>
    {
        private readonly LibraryContext _context;
        public BookRepository(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }
        public void Add(Book item)
        {
            _context.Books.Add(item);
            _context.SaveChanges();
        }

        public IEnumerable<Book> All()
        {
            return _context.Books;
        }

        public void Edit(Book book)
        {
                    _context.Update(book);
                    _context.SaveChanges();
        }

        public Book Find(int id)
        {
            return _context.Books.FirstOrDefault(x => x.ID == id);
        }

        public void Remove(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public bool BookExists(int id)
        {
            return _context.Books.Any(e => e.ID == id);
        }
    }
}
