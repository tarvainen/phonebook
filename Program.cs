using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PhoneBook.Migrations;

namespace PhoneBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            host.RunMigrations();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .UseUrls("http://0.0.0.0:5000");
                });
    }
}
