using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data
{
public    class LibraryDbContext: DbContext
    {
        //public LibraryDbContext(DbContextOptions options) : base(options)
        //{
        //}
        public LibraryDbContext()
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Borrower> Borrowers{ get; set; }
		public DbSet<BorrowersBooks> BorrowedBooks { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Library_Stucky;Integrated Security=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>().HasKey(e=>e.Id);
            builder.Entity<Author>().HasKey(e => e.Id);
            builder.Entity<Borrower>().HasKey(e => e.Id);

            builder.Entity<Book>()
                .HasOne(e => e.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(e => e.AuthorId);

			builder.Entity<BorrowersBooks>()
				 .HasOne(e => e.Book)
				 .WithMany(b => b.Borrowers)
				 .HasForeignKey(e => e.BookId);

			builder.Entity<BorrowersBooks>()
				 .HasOne(e => e.Borrower)
				 .WithMany(b => b.Books)
				 .HasForeignKey(e => e.BorrowerId);

			builder.Entity<BorrowersBooks>()
				.HasKey(b => new { b.BookId, b.BorrowerId });
			

			base.OnModelCreating(builder);
        }
    }
}
