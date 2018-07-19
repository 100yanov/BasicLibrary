using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.App.Models;
using Library.Data;
using Library.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Library.App.Pages.Authors
{
    public class DetailsModel : PageModel
    {
		private readonly LibraryDbContext context;
		public DetailsModel( LibraryDbContext context )
		{
			this.context = context;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public List<BookViewModel> Books { get; set; }

		public IActionResult OnGet(int id)
        {
			var author = context.Authors.Include(a => a.Books).Select(a => new
			{
				Id = a.Id,
				Name = a.Name,
				Books = new List<BookViewModel>(a.Books.Select(b => new BookViewModel(b) ))
			})
			.FirstOrDefault(a=>a.Id==id);
			if (author==null)
			{
				return NotFound();
			}
			this.Name = author.Name;
			this.Books = author.Books;
			this.Id = author.Id;


			return Page();
        }
    }
}