using GraphQL_API.Context;
using GraphQL_ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GraphQL_Project.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly SampleDBContext _context;

        public AuthorRepository(IDbContextFactory<SampleDBContext> dbContextFactory)
        {
            _context = dbContextFactory.CreateDbContext();
        }

        public IQueryable<Author> GetAllAuthors()
        {
            return _context.Authors.AsQueryable();
        }

        public async Task<Author?> GetAuthorById(Guid id)
        {
            return await _context.Authors.FindAsync(id);
        }
    }
}
