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

            if ( bookViewModel.CoverPhoto != null )
            {
                string folder = "images/cover-photos/";
                string fileName = Guid.NewGuid().ToString() + "-" + bookViewModel.CoverPhoto.FileName;
                string serverFolder = Path.Combine( _webHostEnvironment.WebRootPath, folder, fileName );

                // Use a using statement to ensure the FileStream is properly disposed
                using ( var fileStream = new FileStream( serverFolder, FileMode.Create ) )
                {
                    await bookViewModel.CoverPhoto.CopyToAsync( fileStream );
                }
            }

            if ( ModelState.IsValid )
            {
                int id = await _bookRepository.AddNewBook( bookViewModel );
                if ( id > 0 )
                {
                    // IActionResult can return any type of data.
                    //return RedirectToAction( "AddBook" );
                    return RedirectToAction( nameof( AddBook ), new { isSuccess = true, bookId = id } );
                }
            }

            return View();
        }

        public BookViewModel BookDetail ( string author )
        {
            return _bookRepository.GetByName( author );
        }
    }
}
