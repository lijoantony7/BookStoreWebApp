using BookStoreWebApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApp.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        private readonly BookRepository _bookRepository;
        public TopBooksViewComponent(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync ()
        {
            var result = await _bookRepository.GetTopBooksAsync();
            return View(result);
        }
    }
}
