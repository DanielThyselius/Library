using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookCopy
    {
        [Key]
        public int ID { get; set; }
        public virtual Book Book { get; set; }
    }
}