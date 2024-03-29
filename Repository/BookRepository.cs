using BookStoreWebApp.BookStoreContext;
using BookStoreWebApp.ViewModels;

namespace BookStoreWebApp.Repository
{
    public class BookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository ( AppDbContext context )
        {
            _context = context;
        }

        public int AddNewBook ( BookViewModel book )
        {
            var newBook = new Books()
            {
                Title = book.Title,
                Author = book.Author,
                Language = book.Language,
                Description = book.Description,
                TotalPages = book.TotalPages,
                Category = book.Category,
                CreatedBy = DateTime.UtcNow,
                UpdatedBy = DateTime.UtcNow,
            };

            _context.Books.Add( newBook );
            _context.SaveChanges();

            return newBook.Id;
        }

        public List<BookViewModel> GetAllBooks ()
        {
            return DataSource();
        }

        public BookViewModel GetById ( int id )
        {
            return DataSource().FirstOrDefault( b => b.Id == id );
        }

        public BookViewModel GetByName ( string author )
        {
            return DataSource().FirstOrDefault( b => b.Author == author );
        }

        private List<BookViewModel> DataSource ()
        {
            return new List<BookViewModel>()
            {
                new BookViewModel() { Id = 1, Title = "Kayar", Author = "Thakazhi Sivasankara Pillai", Description = "Description for Kayar", Category = "Fiction", Language = "Malayalam", TotalPages = 300 },
                new BookViewModel() { Id = 2, Title = "Naalukettu", Author = "M. T. Vasudevan Nair", Description = "Description for Naalukettu", Category = "Fiction", Language = "Malayalam", TotalPages = 250 },
                new BookViewModel() { Id = 3, Title = "Chemmeen", Author = "Thakazhi Sivasankara Pillai", Description = "Description for Chemmeen", Category = "Fiction", Language = "Malayalam", TotalPages = 400 },
                new BookViewModel() { Id = 4, Title = "Balyakalasakhi", Author = "Vaikom Muhammad Basheer", Description = "Description for Balyakalasakhi", Category = "Fiction", Language = "Malayalam", TotalPages = 200 },
                new BookViewModel() { Id = 5, Title = "Aadujeevitham", Author = "Benyamin", Description = "Description for Aadujeevitham", Category = "Fiction", Language = "Malayalam", TotalPages = 350 }
            };
        }


    }
}
