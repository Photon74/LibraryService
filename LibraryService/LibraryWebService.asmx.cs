using LibraryService.Models;
using LibraryService.Services;
using LibraryService.Services.Imp;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

namespace LibraryService
{
    /// <summary>
    /// Сводное описание для LibraryWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class LibraryWebService : WebService
    {
        private readonly ILibraryRepositoryService _libraryRepositoryService;

        public LibraryWebService()
        {
            _libraryRepositoryService = new LibraryRepository(new LibraryDatabaseContext());
        }

        [WebMethod]
        public List<Book> GetBooksByTitle(string title)
        {
            return _libraryRepositoryService.GetByTitle(title).ToList();
        }

        [WebMethod]
        public List<Book> GetBooksByCategory(string category)
        {
            return _libraryRepositoryService.GetByCategory(category).ToList();
        }

        [WebMethod]
        public List<Book> GetBooksByAuthor(string author)
        {
            return _libraryRepositoryService.GetByAuthor(author).ToList();
        }

        [WebMethod]
        public List<Book> GetAll()
        {
            return _libraryRepositoryService.GetAll().ToList();
        }

        [WebMethod]
        public Book GetBookById(string id)
        {
            return _libraryRepositoryService.GetById(id);
        }

        [WebMethod]
        public void AddBook(Book book)
        {
            _libraryRepositoryService.Add(book);
        }

        [WebMethod]
        public void DeleteBook(Book book)
        {
            _libraryRepositoryService.Delete(book);
        }

        [WebMethod]
        public void UpdateBook(Book book)
        {
            _libraryRepositoryService.Update(book);
        }
    }
}
