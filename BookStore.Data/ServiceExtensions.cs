using BookStore.Data.Context;
using BookStore.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Data
{
  public static class ServiceExtensions
  {
    public static void AddDataServices(this IServiceCollection services,
      bool isProduction,
      IConfiguration configuration)
    {
      if (isProduction)
      {
        var databaseConnectionString = configuration.GetConnectionString("BookStoreDB");
        services.AddDbContextPool<BookStoreContext>(options => { options.UseSqlServer(databaseConnectionString); });
      }
      else
      {
        services.AddDbContextPool<BookStoreContext>(options => { options.UseInMemoryDatabase("BookStoreDB"); });
      }


      services.AddTransient<IAuthorRepository, AuthorRepository>();
      services.AddTransient<IBookRepository, BookRepository>();
      services.AddTransient<IUserRepository, UserRepository>();
    }
  }
}