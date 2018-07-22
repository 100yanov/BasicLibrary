using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.App.Models;
using Library.Data;
using Library.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.App.Pages.Books
{
    public class AddModel : PageModel
    {
		private readonly LibraryDbContext context;
		public AddModel( LibraryDbContext context)
		{
			this.context = context;
		}
		[BindProperty]
		public BookAddViewModel Book { get; set; }

		public void OnGet()
        {
			
        }
		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			var author = context.Authors.FirstOrDefault(a=>a.Name==Book.Author);
			if (author==null)
			{
				author = new Author()
				{ Name = Book.Author };
				
				context.Authors.Add(author);
				context.SaveChanges();
			}
			var book = new Book()
			{
				Title = this.Book.Title,
				AuthorId = author.Id,
				Description = this.Book.Description ?? "",
				CoverImage = this.Book.ImageUrl ?? ""
			};
			
			context.Books.Add(book);
			context.SaveChanges();

			return RedirectToPage("BookDetails/",new { book.Id });
		}
    }
}