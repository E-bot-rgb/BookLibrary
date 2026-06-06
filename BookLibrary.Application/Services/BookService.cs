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

        public async Task<IEnumerable<Book>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<Book?> GetByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task AddAsync(Book book) =>
            await _repository.AddAsync(book);

        public async Task UpdateAsync(Book book) =>
            await _repository.UpdateAsync(book);

        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
