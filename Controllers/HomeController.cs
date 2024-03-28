using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string? Title {  get; set; }
        public ViewResult Index()
        {
            //ViewData["Title"] = "Welcome Page";
            Title = "New Home";  // passing title using viewdata attribute
            return View();
        }

        public ViewResult About() 
        {
            //View Discovery takes places to find the view
            //View Discovery determine which file to be opened.
            //will search for the VIEW in view->particular folder and view->shared folder.
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
