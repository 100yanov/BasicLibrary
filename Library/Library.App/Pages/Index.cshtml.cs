using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Library.Data.Models;
using Library.App.Models;

namespace Library.App.Pages
{
	public class IndexModel : PageModel
    {
		

		private readonly LibraryDbContext context;

        public IndexModel(LibraryDbContext context)
        {
            this.context = context;
        }

        public string Name { get; set; }
        public ICollection<BookDisplayViewModel> Books { get; set; }

        public void OnGet()
        {
            this.Books = context.Books
				.Include(b => b.Author)
				//.Include(b=>b.Borrowers)
				.Select(b=>new BookDisplayViewModel(b))
                .ToList();
        }
    }
}
