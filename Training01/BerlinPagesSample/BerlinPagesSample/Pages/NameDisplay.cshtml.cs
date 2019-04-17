using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BerlinPagesSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BerlinPagesSample.Pages
{
    public class NameDisplayModel : PageModel
    {
        [BindProperty]
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [BindProperty]
        [Required]
        [DisplayName("LastName")]
        public string LastName { get; set; }

        public EnteredNameModel EnteredNames { get; set; }


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            EnteredNames = new EnteredNameModel
            {
                FirstName = this.FirstName,
                LastName = this.LastName
            };
            return Page();
        }
    }
}