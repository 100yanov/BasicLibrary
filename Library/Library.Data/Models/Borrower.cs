using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Borrower
    {
		public Borrower()
		{
			this.Books = new List<Book>();
		}
        public Borrower( string name )
			:this()
        {
			this.Name = name;
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

   
        [MaxLength(100)]
        public string Address { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}