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
        public static async Task<Book?> CreateBookAsync(Guid authorId, string title, int? releaseYear, [Service] IBookRepository repository, [Service] ITopicEventSender eventSender)
        {
            var book = await repository.CreateBookAsync(authorId, title, releaseYear);
            await eventSender.SendAsync(nameof(Subscription.BookAdded), book);
            return book;
        }

        [GraphQLDescription("Update a book by id")]
        public static async Task<Book?> UpdateBookAsync(Guid id, Guid? authorId, string? title, int? releaseYear, [Service] IBookRepository repository)
        {
            return await repository.UpdateBookAsync(id, authorId, title, releaseYear);
        }

        [GraphQLDescription("Delete a book by id")]
        public static async Task<SuccessMessage?> DeleteBookAsync(Guid id, [Service] IBookRepository repository)
        {
            await repository.DeleteBookAsync(id);
            return new SuccessMessage { Message = "Book deleted successfully." };
        }
    }

}
