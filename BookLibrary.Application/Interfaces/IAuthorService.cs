using BookLibrary.Application.DTOs;

namespace BookLibrary.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto?> GetByIdAsync(int id);
        Task AddAsync(CreateAuthorDto dto);
        Task UpdateAsync(int id, UpdateAuthorDto dto);
        Task DeleteAsync(int id);
    }
}
