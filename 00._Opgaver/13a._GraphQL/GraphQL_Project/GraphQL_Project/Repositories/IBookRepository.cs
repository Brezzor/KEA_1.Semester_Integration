using GraphQL_ClassLibrary.Models;

namespace GraphQL_Project.Repositories
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAllBooks();
        Task<Book?> GetBookById(Guid id);
        Task<Book?> CreateBookAsync(Guid authorId, string title, int? releaseYear);
        Task<Book?> UpdateBookAsync(Guid id, Guid? authorId, string? title, int? releaseYear);
        Task DeleteBookAsync(Guid id);
    }
}
