using System;
using System.Linq;

namespace Bookstore.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext context { get; set; }

        public EFBookstoreRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;

        //public IQueryable<Book> Books => throw new NotImplementedException();
    }
}
