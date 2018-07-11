using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.App.Models
{
    public class BookAddViewModel
    {
		[Required]
		[BindProperty]
		public string  Title { get; set; }
		[Required]
		[BindProperty]
		public string Author{ get; set; }
		
		[BindProperty]
		[Url]
		public string ImageUrl{ get; set; }
	}
}
