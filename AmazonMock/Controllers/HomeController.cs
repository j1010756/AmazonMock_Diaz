using AmazonMock.Models;
using AmazonMock.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AmazonMock.Controllers
{
    public class HomeController : Controller
    {
        // get info from interface
        private IBookRepository _repo;

        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        // set index to take in the current page number
        public IActionResult Index(int pageNum)
        {
            // show 10 books per page
            int pageSize = 10;

            // make new list view
            var bookComponents = new BooksListViewModel
            {
                Books = _repo.Books
                    // order by id
                    .OrderBy(x => x.BookID)

                    // skip previously logged entries
                    .Skip((pageNum - 1) * pageSize)

                    // take defined page size
                    .Take(pageSize),

                // make new instance of pagination info
                PaginationInfo = new PaginationInfo
                {
                    // set current page to page number
                    CurrentPage = pageNum,

                    // set items per page to page size
                    ItemsPerPage = pageSize,

                    // set total items to total number of records
                    TotalItems = _repo.Books.Count()
                }
            };
            return View(bookComponents);
        }
    }
}
