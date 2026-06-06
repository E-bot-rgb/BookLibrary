using BookLibrary.Application.Interfaces;
using BookLibrary.Domain.Models;
using BookLibrary.Infrastructure.Data;

namespace BookLibrary.Infrastructure.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context) { }
    }
}
