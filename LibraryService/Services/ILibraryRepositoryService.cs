using LibraryService.Models;
using System.Collections.Generic;

namespace LibraryService.Services
{
    public interface ILibraryRepositoryService : IRepository<Book>
    {
        IList<Book> GetByTitle(string title);
        IList<Book> GetByAuthor(string author);
        IList<Book> GetByCategory(string category);
    }
}
