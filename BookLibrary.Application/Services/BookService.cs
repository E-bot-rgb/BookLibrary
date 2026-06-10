using BookLibrary.Application.DTOs;
using BookLibrary.Application.Interfaces;
using BookLibrary.Domain.Models;

namespace BookLibrary.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await _repository.GetAllAsync();
            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Year = b.Year,
                AuthorId = b.AuthorId,
                AuthorName = b.Author?.Name ?? string.Empty
            });
        }

        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) return null;
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Year = book.Year,
                AuthorId = book.AuthorId,
                AuthorName = book.Author?.Name ?? string.Empty
            };
        }

        public async Task AddAsync(CreateBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Year = dto.Year,
                AuthorId = dto.AuthorId
            };
            await _repository.AddAsync(book);
        }

        public async Task UpdateAsync(int id, UpdateBookDto dto)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) return;
            book.Title = dto.Title;
            book.Year = dto.Year;
            book.AuthorId = dto.AuthorId;
            await _repository.UpdateAsync(book);
        }

        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
