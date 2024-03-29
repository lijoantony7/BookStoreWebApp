using BookStoreWebApp.Repository;
using BookStoreWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;

        public BookController (BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public ViewResult AllBooks ()
        {
            var result = _bookRepository.GetAllBooks();
            return View( result );
        }

        public ViewResult BookDetails ( int id )
        {
            var result = _bookRepository.GetById( id );
            return View( result );
        }

        public ViewResult AddBook (bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public IActionResult AddBook (BookViewModel bookViewModel)
        {
            int id = _bookRepository.AddNewBook( bookViewModel );
            if( id > 0 )
            {
                // IActionResult can return any type of data.
                //return RedirectToAction( "AddBook" );
                return RedirectToAction( nameof(AddBook), new {isSuccess = true, bookId = id} );
            }
            return View();
        }

        public BookViewModel BookDetail ( string author )
        {
            return _bookRepository.GetByName( author );
        }
    }
}
