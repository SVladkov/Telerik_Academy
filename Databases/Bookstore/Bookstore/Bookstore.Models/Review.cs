using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public int BookId { get; set; } // sometimes we need only the id

        public virtual Book Book { get; set; } // sometimes we need the whole entry

        public int? AuthorId { get; set; } // nullable, because he could be anonymous

        public virtual Author Author { get; set; }
    }
}
