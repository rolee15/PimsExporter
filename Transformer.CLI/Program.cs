﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using CSV;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PimsExporter;
using PimsExporter.Domain.Logging;

namespace TransformerCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = CreateDefaultBuilder().Build();
            PimsLogger logger = new PimsLogger();

            Console.Write("Location of the export folder: ");
            logger.LogInfo("Location of the export folder: ");
            var path = Console.ReadLine();

            var transformer = host.Services.GetRequiredService<Transformer>();

            Console.WriteLine("Starting to filter active items...");
            logger.LogInfo("Starting to filter active items...");
            transformer.TransformOmItems(path);
            Console.WriteLine("Om Items finished.");
            logger.LogInfo("Om Items finished.");

            Console.WriteLine("Starting to filter active versions and cosignatures...");
            logger.LogInfo("Starting to filter active versions and cosignatures...");
            transformer.TransformVersionsAndCoSignatures(path);
            Console.WriteLine("Versions and CoSignatures finished.");
            logger.LogInfo("Versions and CoSignatures finished.");

            Console.WriteLine("Finished...");
            logger.LogInfo("Finished...");
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
