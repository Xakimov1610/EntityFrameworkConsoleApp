using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace efconsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args)
                .Build()
                .RunAsync();
        }
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}