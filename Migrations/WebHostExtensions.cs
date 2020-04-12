using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBook.Data;

namespace PhoneBook.Migrations
{
    public static class WebHostExtensions
    {
        public static IHost RunMigrations(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;
            var dataContext = services.GetRequiredService<DataContext>();

            dataContext.Database.Migrate();

            return host;
        }
    }
}
