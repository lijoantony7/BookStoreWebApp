using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
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
