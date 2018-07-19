using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.App.Models;
using Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Library.App.Pages.BookPages
{
    public class BookDetailsModel : PageModel
    {
		private readonly LibraryDbContext context;

		public BookDetailsModel( LibraryDbContext context )
		{
			this.context = context;
		}
		public BookDisplayViewModel Book { get; set; }

		public IActionResult OnGet( int id )
        {
			var book =  context.Books.Include(b => b.Author).FirstOrDefault(b=>b.Id==id);
			if (book==null)
			{
				return RedirectToPage("/");
			}
			this.Book = new BookDisplayViewModel(book);

			return Page();
        }
    }
}