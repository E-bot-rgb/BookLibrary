using BookLibrary.API.Data;
using BookLibrary.API.Interfaces;
using BookLibrary.API.Models;

namespace BookLibrary.API.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context) { }
    }
}
