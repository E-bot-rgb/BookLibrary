using BookLibrary.Application.Interfaces;
using BookLibrary.Infrastructure.Data;
using BookLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context) { }

        public override async Task<IEnumerable<Book>> GetAllAsync() =>
            await _context.Set<Book>().Include(b => b.Author).ToListAsync();

        public override async Task<Book?> GetByIdAsync(int id) =>
            await _context.Set<Book>().Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
    }
}
