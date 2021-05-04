using System;
using System.Linq;
using Bogus;
using Bogus.Extensions;
using BookStore.Data.Context;
using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Data.Helpers
{
  public static class DataHelper
  { 
    public static void SeedDatabase(IServiceProvider serviceProvider)
    {
      using var context =
        new BookStoreContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreContext>>());
      if (context.Users.Any() || context.Books.Any() || context.Authors.Any())
      {
        return;
      }

      var authors = new Faker<Author>()
        .RuleFor(f => f.Id, f => f.Random.Guid())
        .RuleFor(f => f.Email, f => f.Person.Email)
        .RuleFor(f => f.FirstName, f => f.Person.FirstName)
        .RuleFor(f => f.LastName, f => f.Person.LastName)
        .RuleFor(f => f.DateOfBirth, f => f.Date.Between(DateTime.Now, DateTime.Now.AddMonths(-240)))
        .RuleFor(f => f.ProfileImage, f => f.Image.PlaceImgUrl(640, 640, "people"))
        .RuleFor(f => f.DateCreated, f => f.Date.Between(DateTime.Now, DateTime.Now.AddMonths(8)))
        .RuleFor(f => f.Active, f => f.Random.Bool())
        .FinishWith((f, u) => { Console.WriteLine($"{u.Id} - {u.FirstName} {u.LastName} created."); })
        .GenerateBetween(1000, 1000);
      
      var books = new Faker<Book>()
        .RuleFor(f => f.Id, f => f.Random.Guid())
        .RuleFor(f => f.Title, f => f.Commerce.ProductName())
        .RuleFor(f => f.Description, f => f.Commerce.ProductDescription())
        .RuleFor(f => f.CoverImage, f =>  f.Image.PlaceImgUrl(640, 640, "book"))
        .RuleFor(f => f.ReleaseDate, f => f.Date.Between(DateTime.Now, DateTime.Now.AddMonths(-120)))
        .RuleFor(f => f.ISBN10, f => f.Commerce.Ean13())
        .RuleFor(f => f.ISBN13, f => f.Commerce.Ean13())
        .RuleFor(f => f.Price, f => f.Random.Int(1000, 15000))
        .RuleFor(f => f.DateCreated, f => f.Date.Between(DateTime.Now, DateTime.Now.AddMonths(8)))
        .RuleFor(f => f.Active, f => f.Random.Bool())
        .FinishWith((f, u) => { Console.WriteLine($"{u.Id} - {u.Title} created."); })
        .GenerateBetween(5000, 5000);
      
      context.Authors.AddRange(authors);
      context.Books.AddRange(books);
      context.SaveChanges();
      
      
    }
  }
}