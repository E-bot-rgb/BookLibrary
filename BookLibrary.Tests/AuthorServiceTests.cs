using BookLibrary.Application.Interfaces;
using BookLibrary.Application.Services;
using BookLibrary.Domain.Models;
using NSubstitute;

namespace BookLibrary.Tests
{
    public class AuthorServiceTests
    {
        private readonly IAuthorRepository _repository;
        private readonly AuthorService _service;

        public AuthorServiceTests()
        {
            _repository = Substitute.For<IAuthorRepository>();
            _service = new AuthorService(_repository);
        }

        [Fact]
        public async Task GetAllAsync_WhenAuthorsExist_ReturnsAllAuthors()
        {
            // Arrange
            var authors = new List<Author>
            {
                new Author { Id = 1, Name = "J.K. Rowling", Bio = "British author" },
                new Author { Id = 2, Name = "Stephen King", Bio = "American author" }
            };
            _repository.GetAllAsync().Returns(authors);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_WhenAuthorExists_ReturnsCorrectAuthor()
        {
            // Arrange
            var author = new Author { Id = 1, Name = "J.K. Rowling", Bio = "British author" };
            _repository.GetByIdAsync(1).Returns(author);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("J.K. Rowling", result.Name);
        }

        [Fact]
        public async Task GetByIdAsync_WhenAuthorDoesNotExist_ReturnsNull()
        {
            // Arrange
            _repository.GetByIdAsync(99).Returns((Author?)null);

            // Act
            var result = await _service.GetByIdAsync(99);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AddAsync_WithValidAuthor_CallsRepositoryOnce()
        {
            // Arrange
            var author = new Author { Name = "New Author", Bio = "New Bio" };

            // Act
            await _service.AddAsync(author);

            // Assert
            await _repository.Received(1).AddAsync(author);
        }

        [Fact]
        public async Task UpdateAsync_WithValidAuthor_CallsRepositoryOnce()
        {
            // Arrange
            var author = new Author { Id = 1, Name = "Updated Author", Bio = "Updated Bio" };

            // Act
            await _service.UpdateAsync(author);

            // Assert
            await _repository.Received(1).UpdateAsync(author);
        }

        [Fact]
        public async Task DeleteAsync_WithValidId_CallsRepositoryOnce()
        {
            // Arrange
            int authorId = 1;

            // Act
            await _service.DeleteAsync(authorId);

            // Assert
            await _repository.Received(1).DeleteAsync(authorId);
        }

        [Fact]
        public async Task GetAllAsync_WhenNoAuthorsExist_ReturnsEmptyList()
        {
            // Arrange
            _repository.GetAllAsync().Returns(new List<Author>());

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Empty(result);
        }
    }
}
