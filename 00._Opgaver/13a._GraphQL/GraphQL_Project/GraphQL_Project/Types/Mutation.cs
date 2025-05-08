using GraphQL_Project.Repositories;
using GraphQL_ClassLibrary.Models;
using HotChocolate.Execution.Processing;
using HotChocolate.Subscriptions;

namespace GraphQL_Project.Types
{
    [MutationType]
    public static class Mutation
    {
        [GraphQLDescription("Create a new book")]
        public static async Task<Book?> CreateBookAsync(
            [GraphQLDescription("Shown as an ID scaler type. But is of type GUID (example: \"cef5cbe5e277481e8870ffb1e8d0c0f7\")")]
            [ID] Guid authorId, 
            string title, int? releaseYear, 
            [Service] IBookRepository repository, 
            [Service] ITopicEventSender eventSender)
        {
            var book = await repository.CreateBookAsync(authorId, title, releaseYear);
            await eventSender.SendAsync(nameof(Subscription.BookAdded), book);
            return book;
        }

        [GraphQLDescription("Update a book by id")]
        public static async Task<Book?> UpdateBookAsync(
            [GraphQLDescription("Shown as an ID scaler type. But is of type GUID (example: \"cef5cbe5e277481e8870ffb1e8d0c0f7\")")]
            [ID] Guid id, 
            [GraphQLDescription("Shown as an ID scaler type. But is of type GUID (example: \"cef5cbe5e277481e8870ffb1e8d0c0f7\")")]
            [ID] Guid? authorId, 
            string? title, 
            int? releaseYear, 
            [Service] IBookRepository repository)
        {
            return await repository.UpdateBookAsync(id, authorId, title, releaseYear);
        }

        [GraphQLDescription("Delete a book by id")]
        public static async Task<SuccessMessage?> DeleteBookAsync(
            [GraphQLDescription("Shown as an ID scaler type. But is of type GUID (example: \"cef5cbe5e277481e8870ffb1e8d0c0f7\")")]
            [ID] Guid id, 
            [Service] IBookRepository repository)
        {
            await repository.DeleteBookAsync(id);
            return new SuccessMessage { Message = "Book deleted successfully." };
        }
    }

}
