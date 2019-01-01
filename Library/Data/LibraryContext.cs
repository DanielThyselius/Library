using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = Library; Integrated Security = True");
        }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
        

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Member> Members { get; set; }
       
    }
}
