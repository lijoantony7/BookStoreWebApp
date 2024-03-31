using BookStoreWebApp.BookStoreContext;
using BookStoreWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApp.Repository
{
    public class BookRepository
    {
        private readonly AppDbContext _dbContext;
        public BookRepository ( AppDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddNewBook ( BookViewModel book )
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
                CoverImageUrl = book.CoverPhotoUrl,
                PDFBookUrl = book.PDFBookUrl,
            };

            newBook.BookGalleries = new List<BookGallery>();
            foreach ( var file in book.Gallery )
            {
                newBook.BookGalleries.Add( new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL,
                } );
            }

            _dbContext.Books.Add( newBook );
            await _dbContext.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task<List<BookViewModel>> GetAllBooks ()
        {
            var bookModel = new List<BookViewModel>();
            var books = await _dbContext.Books.ToListAsync();
            if ( books?.Any() == true )
            {
                foreach ( var book in books )
                {
                    bookModel.Add( new BookViewModel()
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Author = book.Author,
                        Language = book.Language,
                        Description = book.Description,
                        TotalPages = book.TotalPages,
                        Category = book.Category,
                        CoverPhotoUrl = book.CoverImageUrl,
                        CreatedBy = book.CreatedBy,
                        UpdatedBy = book.UpdatedBy,
                    } );
                }
            }

            return bookModel;
        }

        public async Task<BookViewModel> GetById ( int id )
        {
            var result = await _dbContext.Books
                .Where( x => x.Id == id )
                .Select( book => new BookViewModel
                {
                    Title = book.Title,
                    Author = book.Author,
                    Language = book.Language,
                    Description = book.Description,
                    TotalPages = book.TotalPages,
                    Category = book.Category,
                    CoverPhotoUrl = book.CoverImageUrl,
                    CreatedBy = book.CreatedBy,
                    UpdatedBy = book.UpdatedBy,
                    Gallery = book.BookGalleries.Select( g => new GalleryViewModel
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL,
                    } ).ToList(),
                    PDFBookUrl = book.PDFBookUrl,
                } ).FirstOrDefaultAsync();

            return result;
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
