using System;
using System.Linq;

namespace Bookstore.Models.ViewModels
{
    public class BooksViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public PageInfo PageInformation { get; set; }
        
    }
}
