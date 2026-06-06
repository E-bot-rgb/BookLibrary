using BookLibrary.API.Data;
using BookLibrary.API.Interfaces;
using BookLibrary.API.Models;

namespace BookLibrary.API.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context) { }
    }
}
