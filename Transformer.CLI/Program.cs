using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using CSV;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PimsExporter;

namespace TransformerCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = CreateDefaultBuilder().Build();

            Console.Write("Starting to filter active items...");
            var transformer = host.Services.GetRequiredService<Transformer>();

            transformer.TransformOmItems();

            Console.WriteLine();

        }

        private static IHostBuilder CreateDefaultBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((ctx, services) =>
                {
                    services.Configure<CsvAdapterSettings>(ctx.Configuration.GetSection(nameof(CsvAdapterSettings)),
                        o => o.BindNonPublicProperties = true);

                    services.AddSingleton<IOutputAdapter, CsvAdapter>();
                    services.AddSingleton<Transformer>();
                });
        }
    }
}
