using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Library.Data.Models
{
    public class Book 
    {
		private ICollection<BorrowersBooks> borrowers;
		private BorrowersBooks lastBorrower;

		public Book()
		{
			this.Borrowers = new List<BorrowersBooks>();
		}
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        [Url]
        public string CoverImage { get; set; }
        [Required]
        public Author Author{ get; set; }

        public int AuthorId { get; set; }
		
		public ICollection<BorrowersBooks> Borrowers
		{
			get => this.borrowers;
			set
			{
				this.borrowers = value;
				this.lastBorrower = borrowers.LastOrDefault();
			}
		}

		public bool IsBorrowed
		{
			get
			{
				var borrower = lastBorrower;// this.Borrowers.FirstOrDefault();
				if (borrower == null)
				{
					return false;
				}

				return borrower.EndDate == null 
					|| borrower
					.EndDate
					.Value.Date <= DateTime.Now.Date;
			}
		}
		

	}
}
