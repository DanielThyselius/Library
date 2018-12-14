using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class BookRepository : IRepository<Book, int>
    {
        LibraryContext _context;
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

        public void Edit(Book item)
        {
            throw new NotImplementedException();
        }

        public Book Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Book item)
        {
            throw new NotImplementedException();
        }
    }
}
