using LibraryService.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace LibraryService.Services.Imp
{
    public class LibraryDatabaseContext : ILibraryDatabaseContextService
    {
        private IList<Book> _libraryDatabase;

        public IList<Book> Books { get { return _libraryDatabase; } }

        public LibraryDatabaseContext()
        {
            Initialize();
        }

        private void Initialize()
        {
            _libraryDatabase = (List<Book>)JsonConvert.DeserializeObject(
                Encoding.UTF8.GetString(Properties.Resources.books),
                typeof(List<Book>));

            
        }
    }
}