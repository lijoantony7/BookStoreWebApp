using BookStoreWebApp.Repository;
using BookStoreWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController ( BookRepository bookRepository, IWebHostEnvironment webHostEnvironment )
        {
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> AllBooks ()
        {
            var result = await _bookRepository.GetAllBooks();
            return View( result );
        }

        public async Task<IActionResult> BookDetails ( int id )
        {
            var result = await _bookRepository.GetById( id );
            return View( result );
        }

        public ViewResult AddBook ( bool isSuccess = false, int bookId = 0 )
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook ( BookViewModel bookViewModel )
        {

            if ( ModelState.IsValid )
            {
                if ( bookViewModel.CoverPhoto != null )
                {
                    string folder = "images/cover-photos/";
                    bookViewModel.CoverPhotoUrl = await UploadImages ( folder, bookViewModel.CoverPhoto );
                }

                if ( bookViewModel.PDFBook != null )
                {
                    string folder = "books/pdf/";
                    bookViewModel.PDFBookUrl = await UploadImages ( folder, bookViewModel.PDFBook );
                }

                if ( bookViewModel.GalleryImages != null )
                {
                    string folder = "images/gallery/";
                    bookViewModel.Gallery = new List<GalleryViewModel>();

                    foreach ( var file in bookViewModel.GalleryImages )
                    {
                        var gallery = new GalleryViewModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImages( folder, file ),
                        };

                        bookViewModel.Gallery.Add( gallery );
                    }
                }

                {
                    int id = await _bookRepository.AddNewBook( bookViewModel );
                    if ( id > 0 )
                    {
                        // IActionResult can return any type of data.
                        //return RedirectToAction( "AddBook" );
                        return RedirectToAction( nameof( AddBook ), new { isSuccess = true, bookId = id } );
                    }
                }
            }

            return View();
        }

        private async Task<string> UploadImages ( string folderPath, IFormFile formFile )
        {
            folderPath += Guid.NewGuid().ToString() + "-" + formFile.FileName;
            string serverFolder = Path.Combine( _webHostEnvironment.WebRootPath, folderPath );

            using ( var fileStream = new FileStream( serverFolder, FileMode.Create ) )
            {
                await formFile.CopyToAsync( fileStream );
            }

            return "/" + folderPath;
        }

        public BookViewModel BookDetail ( string author )
        {
            return _bookRepository.GetByName( author );
        }
    }
}
