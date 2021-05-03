using BookStore.Api.GraphQL;
using BookStore.Data;
using BookStore.Data.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookStore.Api
{
  public class Startup
  {
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;

    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
      _configuration = configuration;
      _environment = environment;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddGraphQLService();
      services.AddBookStoreDataServices(_environment.IsProduction(), _configuration);
      services.AddCors(options =>
      {
        options.AddPolicy("AllowAllHeaders",
          builder =>
          {
            builder
              .AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
          });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
      app.UseWebSockets();
      if (_environment.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        DataHelper.SeedDatabase(app.ApplicationServices);
      }

      app.UseCors("AllowAllHeaders");
      app.UseHttpsRedirection();
      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapGraphQL();
      });
    }
  }
}