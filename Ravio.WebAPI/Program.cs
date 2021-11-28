using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Ravio.WebAPI
{
    public class Program
    {
        public static void Main()
        {
            Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>().UseUrls("https://localhost:5001")).Build().Run();
        }
    }
}
