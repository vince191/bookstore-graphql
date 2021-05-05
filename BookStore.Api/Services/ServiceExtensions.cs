using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Api.Services
{
  public static class ServiceExtensions
  {
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
      services.AddTransient<IBookService, BookService>();
      return services;
    } 
  }
}