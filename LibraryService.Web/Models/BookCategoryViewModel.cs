using LibraryServiceReference;

namespace LibraryService.Web.Models
{
    public class BookCategoryViewModel
    {
        public List<Book> Books { get; set; }

        public SearchType SearchType { get; set; }

        public string SearchString { get; set; }
    }
}
