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

            //Console.Write("Location of the export folder: ");
            //var path = Console.ReadLine();
            var path = @"C:\PIMSExport\PRODexport_20220811";
            
            Console.Write("Starting to filter active items...");
            
            var transformer = host.Services.GetRequiredService<Transformer>();

            transformer.TransformOmItems(path);
            Console.WriteLine("Om Items finished.");
            transformer.TransformVersionsAndCoSignatures(path);
            Console.WriteLine("Versions and CoSignatures finished.");

            Console.WriteLine("Finished...");
            Console.Read();
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
