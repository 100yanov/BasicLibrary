using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Data.Models
{
    public class Book 
    {
		//[BindProperty]
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

        public Borrower Borrower { get; set; }

        public int? BorrowerId { get; set; }

    }
}
