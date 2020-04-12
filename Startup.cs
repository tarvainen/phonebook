using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBook.Data;
using MediatR;
using PhoneBook.Services;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using PhoneBook.Exceptions;

namespace PhoneBook
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<DataContext>(options =>
                options.UseSqlite("Data Source=volumes/data.db"));

            services.AddMediatR(
                typeof(AddContactCommandHandler),
                typeof(GetAllContactsQueryHandler),
                typeof(RemoveContactCommandHandler));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = feature.Error;

                var result = JsonSerializer.Serialize(new { error = exception.Message });

                context.Response.StatusCode = exception switch
                {
                    ContactNotFoundException e => 404,
                    _ => 500
                };

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(result);
            }));

            app.UseRouting();

            app.UseEndpoints(p => p.MapControllers());
        }
    }
}
