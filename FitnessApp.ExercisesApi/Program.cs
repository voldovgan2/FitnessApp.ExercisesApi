using System.Threading.Tasks;
using ExercisesApi.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ExercisesApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            await DataInitializer.EnsureExercisesCreatedAsync(host.Services, true);
            await host.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
