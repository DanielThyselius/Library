using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string  Title { get; set; }
        public virtual Author Author { get; set; }
        public string Description { get; set; }
        public ICollection<BookCopeis> BookCopeis { get; set; }


    }
}
