using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {



        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        // GET: /<controller>/
        public IActionResult Index(int pageNum = 1) //sets the default if nothing else comes in to be on page 1
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)   //-1 helps display the right results... think about why 
                .Take(pageSize),

                PageInformation = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                    //TotalNumPages = repo.Projects
                }
            };

            //var blah = context.Projects.ToList();
            //var blah = 

            return View(x);
        }

    }
}
