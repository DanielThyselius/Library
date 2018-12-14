using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class AuthorRepository : IRepository<Author, int>
    {
        private readonly LibraryContext _context;
        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }
        public void Add(Author item)
        {
            _context.Authors.Add(item);
        }

        public IEnumerable<Author> All()
        {
            return _context.Authors.ToList();
        }

        public void Edit(Author item)
        {
            throw new NotImplementedException();
        }

        public Author Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Author item)
        {
            throw new NotImplementedException();
        }
    }
}
