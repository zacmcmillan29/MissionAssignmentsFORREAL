using System;
using System.Linq;

namespace Bookstore.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
