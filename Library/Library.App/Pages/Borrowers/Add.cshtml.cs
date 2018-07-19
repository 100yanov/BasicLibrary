using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.App.Pages.Borrowers
{
    public class AddModel : PageModel
    {
		private readonly LibraryDbContext contex;

		public AddModel( LibraryDbContext contex )
		{
			this.contex = contex;
		}

		[Required]
		[BindProperty]
		public string Name { get; set; }

		public void OnGet()
        {

        }
		public IActionResult OnPost()
		{
			if (this.ModelState.IsValid)
			{
				Borrower borrower = new Borrower(this.Name);
				this.contex.Borrowers.Add(borrower);
				this.contex.SaveChanges();
			}
			return RedirectToPage("/");
			
		}
	}
}