using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace PDFCloudCCExample
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("PDFCloudCCExample started");
      CreateWebHostBuilder(args).Build().Run();
      Console.WriteLine("PDFCloudCCExample finished");
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
  }
}
