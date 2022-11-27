using LibraryService.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibraryService.Services.Imp
{
    public class LibraryRepository : ILibraryRepositoryService
    {
        private readonly ILibraryDatabaseContextService _context;

        public LibraryRepository(ILibraryDatabaseContextService context) => _context = context;

        public void Add(Book book)
        {
            var books = _context.Books;
            books.Add(book);
            var jsonBooks = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText("books.json", jsonBooks, System.Text.Encoding.UTF8);
        }

        public void Delete(Book book)
        {
            var books = _context.Books;
            books.Remove(book);
            var jsonBooks = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText("books.json", jsonBooks, System.Text.Encoding.UTF8);
        }

        public IList<Book> GetAll()
        {
            return _context.Books;
        }

        public IList<Book> GetByAuthor(string authorName)
        {
            return _context.Books
                .Where(book =>
                    book.Authors.Where(author =>
                    author.Name.ToLower().Contains(authorName.ToLower())).Count() > 0)
                .ToList();
        }

        public IList<Book> GetByCategory(string category)
        {
            return _context.Books
                .Where(book =>
                    book.Category.ToLower().Contains(category.ToLower()))
                .ToList();
        }

        public Book GetById(string id)
        {
            return _context.Books
                .Where(book => book.Id == id)
                .FirstOrDefault();
        }

        public IList<Book> GetByTitle(string title)
        {
            return _context.Books
                .Where(book =>
                    book.Title.ToLower().Contains(title.ToLower()))
                .ToList();
        }

        public void Update(Book book)
        {
            var books = _context.Books;
            var oldBook = books.FirstOrDefault(b => b.Id == book.Id);
            if (oldBook != null)
            {
                books.Remove(oldBook);
                books.Add(book);
            }
            var jsonBooks = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText("books.json", jsonBooks, System.Text.Encoding.UTF8);
        }
    }
}