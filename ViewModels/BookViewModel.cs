using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApp.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required( ErrorMessage = "Title is required." )]
        [StringLength( 100, ErrorMessage = "Title cannot be longer than 100 characters." )]
        public string? Title { get; set; }

        [StringLength( 500, ErrorMessage = "Description cannot be longer than 500 characters." )]
        public string? Description { get; set; }

        [Required( ErrorMessage = "Author is required." )]
        [StringLength( 100, ErrorMessage = "Author name cannot be longer than 100 characters." )]
        public string? Author { get; set; }

        [Required( ErrorMessage = "Category is required." )]
        [StringLength( 50, ErrorMessage = "Category name cannot be longer than 50 characters." )]
        public string? Category { get; set; }

        [Range( 1, int.MaxValue, ErrorMessage = "Total pages must be at least 1." )]
        public int TotalPages { get; set; }

        [Required( ErrorMessage = "Language is required." )]
        [StringLength( 50, ErrorMessage = "Language name cannot be longer than 50 characters." )]
        public string? Language { get; set; }

        [Display(Name = "Upload the cover photo")]
        [Required]
        public IFormFile? CoverPhoto { get; set; }

        public DateTime? CreatedBy { get; set; }
        public DateTime? UpdatedBy { get; set; }

        [Display(Name = "Upload your gallery images.")]
        public List<IFormFile>? GalleryImages {  get; set; }
        public List<GalleryViewModel>? Gallery { get; set; }
    }
}