using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.App.Pages.BookPages
{
    public class AddModel : PageModel
    {
		public BookAddViewModel Book { get; set; }

		public void OnGet()
        {
			
        }
    }
}