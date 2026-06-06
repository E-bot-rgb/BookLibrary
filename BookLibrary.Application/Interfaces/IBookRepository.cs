using BookLibrary.Domain.Models;

namespace BookLibrary.Application.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
    }
}
