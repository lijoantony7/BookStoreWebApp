namespace BookStoreWebApp.BookStoreContext
{
    public class Books
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? Category { get; set; }
        public int TotalPages { get; set; }
        public string? Language { get; set; }
        public DateTime? CreatedBy { get; set; }
        public DateTime? UpdatedBy { get; set; }
        public List<BookGallery>? BookGalleries { get; set; }
    }
}
