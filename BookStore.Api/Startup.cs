using BookStore.Api.Core;
using BookStore.Api.Core.Configuration;
using BookStore.Api.GraphQL;
using BookStore.Api.Services;
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
      var redisConfiguration = _configuration.GetSection("RedisConfiguration").Get<RedisConfiguration>();
      
      services.AddControllers();
      services.AddGraphQLService(redisConfiguration);
      services.AddDataServices(_environment.IsProduction(), _configuration);
      services.AddApiServices();
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
      services.AddAutoMapper(typeof(MappingProfile));
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