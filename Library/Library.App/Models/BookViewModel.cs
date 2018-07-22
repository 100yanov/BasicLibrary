using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.App.Models
{
    public class BookViewModel
    {
		public BookViewModel(Book book)
		{
			this.Id = book.Id;
			this.Title = book.Title;
			this.Taken = book.IsBorrowed ? "Borowed" : "At Home";
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public string Taken { get; set; }

	}
}
