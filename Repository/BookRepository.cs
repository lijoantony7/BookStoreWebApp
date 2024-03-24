using BookStoreWebApp.ViewModels;

namespace BookStoreWebApp.Repository
{
    public class BookRepository
    {
        public List<BookViewModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookViewModel GetById(int id)
        {
            return DataSource().FirstOrDefault(b => b.Id == id);
        }

        public BookViewModel GetByName(string author)
        {
            return DataSource().FirstOrDefault(b => b.Author == author);
        }

        private List<BookViewModel> DataSource()
        {
            return new List<BookViewModel>()
            {
                new BookViewModel() { Id = 1, Title = "Kayar", Author = "Thakazhi Sivasankara Pillai", Description = "Description for Kayar" },
                new BookViewModel() { Id = 2, Title = "Naalukettu", Author = "M. T. Vasudevan Nair", Description = "Description for Naalukettu" },
                new BookViewModel() { Id = 3, Title = "Chemmeen", Author = "Thakazhi Sivasankara Pillai", Description = "Description for Chemmeen" },
                new BookViewModel() { Id = 4, Title = "Balyakalasakhi", Author = "Vaikom Muhammad Basheer", Description = "Description for Balyakalasakhi" },
                new BookViewModel() { Id = 5, Title = "Aadujeevitham", Author = "Benyamin", Description = "Description for Aadujeevitham" }
            };
        }

    }
}
