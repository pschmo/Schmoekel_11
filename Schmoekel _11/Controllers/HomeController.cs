using Microsoft.AspNetCore.Mvc;
using Schmoekel__11.Models;
using Schmoekel__11.Models.NewFolder1;
using System.Diagnostics;

namespace Schmoekel__11.Controllers
{
    public class HomeController : Controller
    {

        private IBookRepository _repo;

        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var booksViewModel = new BooksListViewModel
            {
                Books = _repo.Books
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),
                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };

            return View(booksViewModel);
        }



    }
}
