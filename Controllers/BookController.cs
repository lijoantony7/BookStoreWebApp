using BookStoreWebApp.Repository;
using BookStoreWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;

        public BookController()
        {
            _bookRepository = new BookRepository();
        }

        public ViewResult AllBooks()
        {
            var result = _bookRepository.GetAllBooks();
            return View(result);
        }

        public ViewResult BookDetails(int id)
        {
            var result = _bookRepository.GetById(id);
            return View(result);
        }

        public BookViewModel BookDetail(string author)
        {
            return _bookRepository.GetByName(author);
        }
    }
}
