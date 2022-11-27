using LibraryService.Web.Models;
using LibraryServiceReference;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryService.Web.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILogger<LibraryController> _logger;

        public LibraryController(ILogger<LibraryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(SearchType searchType, string searchString)
        {
            var _client = new LibraryWebServiceSoapClient(LibraryWebServiceSoapClient.EndpointConfiguration.LibraryWebServiceSoap);
            try
            {
                if (searchType == SearchType.All || (!string.IsNullOrEmpty(searchString) && searchString.Length >= 3))
                {
                    switch (searchType)
                    {
                        case SearchType.Title:
                            return View(new BookCategoryViewModel
                            {
                                Books = _client.GetBooksByTitle(searchString).ToList()
                            });
                        case SearchType.Category:
                            return View(new BookCategoryViewModel
                            {
                                Books = _client.GetBooksByCategory(searchString).ToList()
                            });
                        case SearchType.Author:
                            return View(new BookCategoryViewModel
                            {
                                Books = _client.GetBooksByAuthor(searchString).ToList()
                            });
                        case SearchType.Id:
                            return View(new BookCategoryViewModel
                            {
                                Books = new List<Book> { _client.GetBookById(searchString) }
                            });
                        case SearchType.All:
                            return View(new BookCategoryViewModel
                            {
                                Books = _client.GetAll().ToList()
                            });
                    }
                }
            }
            catch (Exception)
            {
                return View(new BookCategoryViewModel
                {
                    Books = new List<Book>()
                });
            }
            return View(new BookCategoryViewModel
            {
                Books = new List<Book>()
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}