﻿using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult About() {
            return View();
        }
    }
}
