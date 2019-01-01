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
        [Display(Name = "Titel")]
        public string  Title { get; set; }
        [Display(Name = "Författare")]
        [Required]
        public virtual Author Author { get; set; } = new Author();
        [Display(Name="Beskrivning")]
        public string Description { get; set; }
        [Display(Name ="Kopior")]
        public virtual ICollection<BookCopy> BookCopeis { get; set; }
    }
}
