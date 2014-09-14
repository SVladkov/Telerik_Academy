using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Author
    {
        private ICollection<Review> reviews;

        private ICollection<Book> books;

        public Author()
        { 
            this.reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}
