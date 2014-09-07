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

        public Author()
        { 
            this.reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        //[Index(IsUnique = true)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }
    }
}
