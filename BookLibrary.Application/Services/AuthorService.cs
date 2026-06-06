using BookLibrary.Application.Interfaces;
using BookLibrary.Domain.Models;

namespace BookLibrary.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Author>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<Author?> GetByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task AddAsync(Author author) =>
            await _repository.AddAsync(author);

        public async Task UpdateAsync(Author author) =>
            await _repository.UpdateAsync(author);

        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
