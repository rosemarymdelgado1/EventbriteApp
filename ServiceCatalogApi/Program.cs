using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ServiceCatalogApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static class Extensions
        {
            public static DateTime ToEventDateTime(this DateTime dDateTime)
            {
                DateTime edtDateTime = new DateTime();
                edtDateTime.DateTime = DateTime.ParseExact(dDateTime.ToString("MM/dd/yyyy HH:mm"), "MM/dd/yyyy HH:mm", null);
                return edtDateTime;
            }

        }
    }
}
