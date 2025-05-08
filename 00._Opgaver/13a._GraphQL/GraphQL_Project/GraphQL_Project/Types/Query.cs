using GraphQL_Project.Repositories;
using GraphQL_ClassLibrary.Models;
using System.Threading.Tasks;

namespace GraphQL_Project.Types
{
    [QueryType]
    public static class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Get all books")]
        public static IEnumerable<Book?>? GetBooks([Service] IBookRepository repository) =>
            repository.GetAllBooks();
        
        [UseProjection]
        [GraphQLDescription("Get a book by id")]
        public static async Task<Book?> GetBook(
            [GraphQLDescription("Shown as an ID scaler type. But is of type GUID (example: \"cef5cbe5e277481e8870ffb1e8d0c0f7\")")]
            [ID] Guid id, 
            [Service] IBookRepository repository) =>
            await repository.GetBookById(id);

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Get all authors")]
        public static IEnumerable<Author?>? GetAuthors([Service] IAuthorRepository repository) =>
            repository.GetAllAuthors();

        [UseProjection]
        [GraphQLDescription("Get an author by id")]
        public static async Task<Author?> GetAuthor(
            [GraphQLDescription("Shown as an ID scaler type. But is of type GUID (example: \"cef5cbe5e277481e8870ffb1e8d0c0f7\")")]
            [ID] Guid id, 
            [Service] IAuthorRepository repository) =>
            await repository.GetAuthorById(id);
    }

}
