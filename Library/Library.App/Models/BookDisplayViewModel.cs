using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.App.Models
{
    public class BookDisplayViewModel
    {
		public BookDisplayViewModel()
		{

		}
		public BookDisplayViewModel(Book book)
			:this()
		{
			this.Id = book.Id;
			this.Title = book.Title;
			this.Author = book.Author.Name;
			this.AuthorId = book.Author.Id;
			this.Taken = book.IsBorrowed ? "Borrowed" : "At Home";
			this.Description = book.Description;
			this.ImageUrl = book.CoverImage;
			
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public int AuthorId { get; set; }
		public string Taken { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
	}
}
