using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Library.App.Models;
using Library.Data;
using Library.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace Library.App.Pages.Books
{
    public class BorrowModel : PageModel
    {
		private readonly LibraryDbContext context;
		public BorrowModel( LibraryDbContext context )
		{
			this.context = context;
			this.Borrowers = new Dictionary<int, string>();
		}

		[BindProperty]
		public BookDisplayViewModel Book { get; set; }
		[BindProperty]
		public int Id { get; set; }
		public Dictionary<int, string> Borrowers { get; set; }

		[Required]
		[BindProperty]
		public int	Borrower { get; set; }


		public IActionResult OnGet( int id )
		{
			var book = context.Books.Include(b => b.Author).FirstOrDefault(b => b.Id == id);
			if (book == null)
			{
				return RedirectToPage("/");
			}
			this.Id = id;
			var borrowers = context.Borrowers.Select(b => new { id= b.Id, name=b.Name});
			foreach (var b in borrowers)
			{
				this.Borrowers[b.id] = b.name;
			}
			this.Book = new BookDisplayViewModel(book);

			return Page();
        }
		public IActionResult OnPost(  )
		{
			if (ModelState.IsValid)
			{
				var borrowedBook = new BorrowersBooks()
				{
					BookId = Id,
					BorrowerId = Borrower
				};

				context.BorrowedBooks.Add(borrowedBook);
				this.context.SaveChanges();
			}
			return RedirectToPage("/");
		}
		} 
}