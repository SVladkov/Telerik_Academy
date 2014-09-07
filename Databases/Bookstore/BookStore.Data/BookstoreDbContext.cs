using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Bookstore.Models;

namespace Bookstore.Data
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext()
            : base("BookstoreConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookstoreDbContext, BookStore.Data.Migrations.Configuration>());
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<Author> Authors { get; set; }
    }
}
