using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class AuthorService
    {
        private readonly AuthorRepository authorRepository;

        public AuthorService(AuthorRepository authorRepository )
        {
            this.authorRepository = authorRepository;
        }
        public void Add(Author author)
        {
            authorRepository.Add(author);
        }
    }
}
