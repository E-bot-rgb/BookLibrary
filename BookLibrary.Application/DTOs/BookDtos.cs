namespace BookLibrary.Application.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
    }

    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public int AuthorId { get; set; }
    }

    public class UpdateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public int AuthorId { get; set; }
    }
}
