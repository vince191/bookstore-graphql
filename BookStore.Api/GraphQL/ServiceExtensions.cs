using BookStore.Api.GraphQL.Authors;
using BookStore.Api.GraphQL.Books;
using BookStore.Api.GraphQL.Ratings;
using BookStore.Api.GraphQL.Users;
using HotChocolate.Language;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace BookStore.Api.GraphQL
{
  public static class ServiceExtensions
  {
    public static IServiceCollection AddGraphQLService(this IServiceCollection services)
    {
      services
        // Global Services
        .AddRouting()
        .AddMemoryCache()
        .AddSha256DocumentHashProvider(HashFormat.Hex)
        // GraphQL server configuration
        .AddGraphQLServer()
        .AddQueryType(d => d.Name("Query"))
        .AddTypeExtension<AuthorQueries>()
        .AddTypeExtension<BookQueries>()
        .AddTypeExtension<UserQueries>()
        //.AddMutationType(d => d.Name("Mutation"))
        //.AddTypeExtension<AuthorMutations>()
        //.AddTypeExtension<BookMutations>()
        //.AddTypeExtension<UserMutations>()
        //.AddSubscriptionType(d => d.Name("Subscription"))
        //.AddTypeExtension<AuthorSubscriptions>()
        //.AddTypeExtension<BookSubscriptions>()
        //.AddTypeExtension<UserSubscriptions>()
        .AddInMemorySubscriptions()
        .AddFiltering()
        .AddSorting()
        .UseAutomaticPersistedQueryPipeline()
        //.AddRedisQueryStorage((sp) => ConnectionMultiplexer.Connect("host:port").GetDatabase())
        //.AddRedisSubscriptions((sp) => ConnectionMultiplexer.Connect("host:port"))
        .AddInMemoryQueryStorage();

      return services;
    }
  }
}