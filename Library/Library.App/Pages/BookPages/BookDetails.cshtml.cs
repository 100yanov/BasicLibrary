using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public string Author { get; set; }

		public IActionResult OnGet( int id )
        {
			var book =  context.Books.Include(b => b.Author).FirstOrDefault(b=>b.Id==id);
			if (book==null)
			{
				return RedirectToPage("/");
			}
			this.Name = book.Title;
			this.Description = book.Description;
			this.Author = book.Author.Name;
			this.ImageUrl = book.CoverImage;

			return Page();
        }
    }
}