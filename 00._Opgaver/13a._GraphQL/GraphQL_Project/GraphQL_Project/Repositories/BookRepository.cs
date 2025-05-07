using GraphQL_API.Context;
using GraphQL_ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_Project.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly SampleDBContext _context;

        public BookRepository(IDbContextFactory<SampleDBContext> dbContextFactory)
        {
            _context = dbContextFactory.CreateDbContext();
        }

        public async Task<Book?> CreateBookAsync(Guid authorId, string title, int? releaseYear)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                AuthorId = authorId,
                Title = title,
                ReleaseYear = releaseYear
            };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }

        public IQueryable<Book> GetAllBooks()
        {            
            return _context.Books.AsQueryable();
        }

        public async Task<Book?> GetBookById(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book?> UpdateBookAsync(Guid id, Guid? authorId, string? title, int? releaseYear)
        {
            var book = await _context.Books.FindAsync(id);

            if (book != null)
            {
                book.AuthorId = authorId ?? book.AuthorId;
                book.Title = title ?? book.Title;
                book.ReleaseYear = releaseYear ?? book.ReleaseYear;
                _context.Books.Update(book);
                await _context.SaveChangesAsync();
                return book;
            }
            return null;
        }
    }
}
