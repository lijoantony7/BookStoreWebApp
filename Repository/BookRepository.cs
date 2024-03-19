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
            return
            [
                new BookViewModel() {Id = 1, Title = "Kayar", Author = "Thakazhi Sivasankara Pillai"},
                new BookViewModel() {Id = 2, Title = "Naalukettu", Author = "M. T. Vasudevan Nair"},
                new BookViewModel() {Id = 3, Title = "Chemmeen", Author = "Thakazhi Sivasankara Pillai"},
                new BookViewModel() {Id = 4, Title = "Balyakalasakhi", Author = "Vaikom Muhammad Basheer"},
                new BookViewModel() {Id = 5, Title = "Aadujeevitham", Author = "Benyamin"}
            ];

        }
    }
}
