namespace BookLibrary.Application.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
    }

    public class CreateAuthorDto
    {
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
    }

    public class UpdateAuthorDto
    {
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
    }
}
