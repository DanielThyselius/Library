using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Member
    {
        [Key]
        public int SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
