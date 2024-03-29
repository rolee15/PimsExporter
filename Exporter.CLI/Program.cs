﻿using System;
using System.Security;
using System.Threading.Tasks;
using CSV;
using CSV.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PimsExporter;
using PimsExporter.Services.InputRepositories;
using Services.InputRepositories;
using static Domain.Constants;

namespace ExporterCLI
{
    internal class Program
    {

        private static async Task Main(string[] args)
        {
            var host = CreateDefaultBuilder().Build();
            var logger = host.Services.GetRequiredService<IPimsLogger>();
          
            Console.Write("Password: ");
            var password = GetPassword();
            Console.WriteLine();
            var from = GetOmItemLowerRange();
            var to = GetOmItemUpperRange();

            var exporter = host.Services.GetRequiredService<IApplication>();
            exporter.Password = password;

            Console.WriteLine("Starting to export root...");
            logger.LogInfo("Starting to export root...");
            exporter.ExportRoot(from, to);
            Console.WriteLine("Done.");
            logger.LogInfo("Done.");

            Console.WriteLine("Starting to export OM Items...");
            logger.LogInfo("Starting to export OM Items...");
            exporter.ExportOmItems(from, to);
            Console.WriteLine("Done.");
            logger.LogInfo("Done.");

            Console.WriteLine("Starting to export Versions...");
            logger.LogInfo("Starting to export Versions...");
            exporter.ExportVersions(from, to);
            Console.WriteLine("Done.");
            logger.LogInfo("Done.");

            Console.WriteLine("Starting to export Co-Signatures...");
            logger.LogInfo("Starting to export Co-Signatures...");
            await exporter.ExportCoSignaturesAsync(from, to);
            Console.WriteLine("Done.");
            logger.LogInfo("Done.");

            Console.WriteLine();
            Console.WriteLine("Finished.");
            logger.LogInfo("Finished.");
            Console.ReadLine();
        }

        private static int GetOmItemLowerRange()
        {
            Console.Write("Where do you want to start exporting OM Items? ");
            return Convert.ToInt32(Console.ReadLine());
        }

        private static int GetOmItemUpperRange()
        {
            Console.Write("Which is the last OM Item to export? ");
            return Convert.ToInt32(Console.ReadLine());
        }

        private static IHostBuilder CreateDefaultBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app =>
                {
                    app.AddJsonFile("Settings\\appsettings.json");
                    app.AddJsonFile($"Settings\\appsettings.{Environment.UserName}.json", true);
                })
                .ConfigureServices((ctx, services) =>
                {
                    services.Configure<ExporterSettings>(ctx.Configuration.GetSection(nameof(ExporterSettings)),
                        o => o.BindNonPublicProperties = true);
                    services.Configure<CsvAdapterSettings>(ctx.Configuration.GetSection(nameof(CsvAdapterSettings)),
                         o => o.BindNonPublicProperties = true);

                    var csvAdapterSettings = new CsvAdapterSettings();
                    ctx.Configuration.GetSection(nameof(CsvAdapterSettings)).Bind(csvAdapterSettings);

                    services.AddSingleton<CsvAdapterSettings>(csvAdapterSettings);
                    services.AddSingleton<IInputRepositoryFactory, InputRepositoryFactory>();
                    services.AddSingleton<IPimsLogger, PimsLogger>();
                    services.AddSingleton<IOutputAdapter, CsvAdapter>();
                    services.AddSingleton<IApplication, Exporter>();
                });
        }

        private static SecureString GetPassword()
        {
            var pwd = new SecureString();
            while (true)
            {
                var i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter) break;

                if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0) pwd.RemoveAt(pwd.Length - 1);
                }
                else if (i.KeyChar != '\u0000'
                        ) // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.AppendChar(i.KeyChar);
                }
            }

            return pwd;
        }
    }
}