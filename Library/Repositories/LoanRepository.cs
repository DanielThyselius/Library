using System;
using Library.Data;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class LoanRepository : IRepository<Loan, int>
    {
        private readonly LibraryContext context;

        public LoanRepository(LibraryContext context)
        {
            this.context = context;
        }

        public void Add(Loan item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Loan> All()
        {
            throw new NotImplementedException();
        }

        public void Edit(Loan item)
        {
            throw new NotImplementedException();
        }

        public Loan Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Loan item)
        {
            throw new NotImplementedException();
        }
    }
}
