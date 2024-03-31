using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApp.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync ()
        {
            return View();
        }
    }
}
