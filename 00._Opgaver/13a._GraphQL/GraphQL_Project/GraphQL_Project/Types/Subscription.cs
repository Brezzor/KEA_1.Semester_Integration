using GraphQL_ClassLibrary.Models;

namespace GraphQL_Project.Types
{
    [SubscriptionType]
    public static class Subscription
    {
        [Subscribe]
        [Topic]
        [GraphQLDescription("Updates when a new book has been added")]
        public static Book? BookAdded([EventMessage] Book book) => book;
    }

}
