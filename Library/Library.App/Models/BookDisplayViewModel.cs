using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.App.Models
{
    public class BookDisplayViewModel
    {
		public BookDisplayViewModel(Book book)
		{
			this.Id = book.Id;
			this.Title = book.Title;
			this.Author = book.Author.Name;
			this.Taken = book.BorrowerId != null ? "Borowed" : "At Home";
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public int AuthorId { get; set; }
		public string Taken { get; set; }
	}
}
