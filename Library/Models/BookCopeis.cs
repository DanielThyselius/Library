using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookCopeis
    {
        [Key]
        public int ID { get; set; }
        public Book Book { get; set; }
    }
}