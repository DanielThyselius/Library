using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.ViewModels
{
    public class LoanCreateVM
    {
        public IEnumerable<SelectListItem> Books { get; set; }
        [Display(Name = "Bok")]
        public int BookID { get; set; }
        public IEnumerable<SelectListItem> Members { get; internal set; }
        [Display(Name ="Medlem")]
        public int MemberID { get; set; }

    }
}
