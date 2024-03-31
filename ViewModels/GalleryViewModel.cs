using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApp.ViewModels
{
    public class GalleryViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string?  URL { get; set; }
    }
}