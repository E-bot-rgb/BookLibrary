using BookLibrary.Application.DTOs;

namespace BookLibrary.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto?> GetByIdAsync(int id);
        Task AddAsync(CreateBookDto dto);
        Task UpdateAsync(int id, UpdateBookDto dto);
        Task DeleteAsync(int id);
    }
}
