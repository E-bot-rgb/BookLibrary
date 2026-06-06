using BookLibrary.Application.Interfaces;
using BookLibrary.Domain.Models;
using BookLibrary.Infrastructure.Data;

namespace BookLibrary.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context) { }
    }
}
