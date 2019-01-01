using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Loan
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime LoanTime { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        [Required]
        public virtual BookCopy BookCopy { get; set; }
        [Required]
        public virtual Member Member { get; set; }
    }
}
