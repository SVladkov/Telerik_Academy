using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bookstore.Data;

namespace Bookstore.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new BookstoreDbContext();

            db.Authors.Any();
        }
    }
}
