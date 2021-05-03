using BookStore.Api.GraphQL.Authors;
using BookStore.Api.GraphQL.Books;
using BookStore.Api.GraphQL.Ratings;
using BookStore.Api.GraphQL.Users;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Api.GraphQL
{
  public static class ServiceExtensions
  {
    public static IServiceCollection AddGraphQLService(this IServiceCollection services)
    {
      services
        .AddGraphQLServer()
        .AddQueryType(d => d.Name("Query"))
        .AddTypeExtension<AuthorQueries>()
        //.AddTypeExtension<BookQueries>()
        //.AddTypeExtension<RatingQueries>()
        //.AddTypeExtension<UserQueries>()
        //.AddMutationType(d => d.Name("Mutation"))
        //.AddTypeExtension<AuthorMutations>()
        //.AddTypeExtension<BookMutations>()
        //.AddTypeExtension<RatingMutations>()
        //.AddTypeExtension<UserMutations>()
        //.AddSubscriptionType(d => d.Name("Subscription"))
        //.AddTypeExtension<AuthorSubscriptions>()
        //.AddTypeExtension<BookSubscriptions>()
        //.AddTypeExtension<RatingSubscriptions>()
        //.AddTypeExtension<UserSubscriptions>()
        .AddInMemorySubscriptions()
        .AddFiltering()
        .AddSorting();

      return services;
    }
  }
}