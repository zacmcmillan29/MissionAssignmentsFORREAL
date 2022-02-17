using System;
namespace Bookstore.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumPages => (int)Math.Ceiling((double)TotalNumBooks / BooksPerPage); //dynamically create TOTAL pages!
    }
}
