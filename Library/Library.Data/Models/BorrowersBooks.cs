using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Models
{
	public class BorrowersBooks
	{
		public BorrowersBooks()
		{
			this.StartDate = DateTime.Today;
		}
		public BorrowersBooks(DateTime startDate)
		{
			this.StartDate = startDate.Date<=DateTime.Today
				?startDate 
				: throw new ArgumentException("Invalid start date");
		}
		public BorrowersBooks( DateTime startDate , DateTime endDate)
			:this(startDate)
		{
			this.EndDate = endDate.Date <= startDate
				? endDate
				: throw new ArgumentException("Invalid end date");
		}

		public int BorrowerId { get; set; }

		public Borrower Borrower { get; set; }

		public int BookId { get; set; }

		public Book Book { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime? EndDate { get; set; }
	}
}

