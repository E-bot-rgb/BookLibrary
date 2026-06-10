using BookLibrary.Application.DTOs;
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

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var authors = await _repository.GetAllAsync();
            return authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                Bio = a.Bio
            });
        }

        public async Task<AuthorDto?> GetByIdAsync(int id)
        {
            var author = await _repository.GetByIdAsync(id);
            if (author == null) return null;
            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Bio = author.Bio
            };
        }

        public async Task AddAsync(CreateAuthorDto dto)
        {
            var author = new Author
            {
                Name = dto.Name,
                Bio = dto.Bio
            };
            await _repository.AddAsync(author);
        }

        public async Task UpdateAsync(int id, UpdateAuthorDto dto)
        {
            var author = await _repository.GetByIdAsync(id);
            if (author == null) return;
            author.Name = dto.Name;
            author.Bio = dto.Bio;
            await _repository.UpdateAsync(author);
        }

        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
