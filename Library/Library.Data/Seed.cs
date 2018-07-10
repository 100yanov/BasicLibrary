using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Data
{
    public static class Seed
    {
		
	
		public static void SeedDataBase()
		{
			using (var context = new LibraryDbContext ())
			{
				SeedAuthors(context);
				SeedBooks(context);
				SeedBorrowers(context);
				
			}
			
		}
		private static void SeedAuthors( LibraryDbContext context )
		{
			if (!context.Authors.Any())
			{
				for (int i = 0; i < 5; i++)
				{
					var author = new Author()
					{
						Name = "Author" + ( i + 1 ),						
					};
					context.Authors.Add(author);
					context.SaveChanges();
				}
			}
			
		}
		private static void SeedBooks( LibraryDbContext context )
		{
			if (context.Authors.Any()&&!context.Books.Any())
			{
				for (int i = 0; i < 5; i++)
				{
					var book = new Book()
					{
						Title = "Book" + ( i + 1 ),
						AuthorId = i+1,
						Description = "description" + ( i + 1 ),
						CoverImage = "http://thebookcovermachine.com/wp-content/uploads/2014/02/premade-exclusive-book-cover-604.jpg"
					};
					context.Books.Add(book);
					context.SaveChanges();
				}
			}

		}
		private static void SeedBorrowers(LibraryDbContext context)
		{
			if (!context.Borrowers.Any())
			{
				for (int i = 0; i < 5; i++)
				{
					var borrower = new Borrower()
					{
						Name = "Borrower" + ( i + 1 ),
						Address = "address" + ( i + 1 ),
					};
					context.Borrowers.Add(borrower);
					context.SaveChanges();
				}
			}

		}


	}
}
