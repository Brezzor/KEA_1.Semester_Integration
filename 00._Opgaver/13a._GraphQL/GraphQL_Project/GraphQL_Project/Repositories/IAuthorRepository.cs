using GraphQL_ClassLibrary.Models;

namespace GraphQL_Project.Repositories
{
    public interface IAuthorRepository
    {
        IQueryable<Author> GetAllAuthors();
        Task<Author?> GetAuthorById(Guid id);
    }
}
