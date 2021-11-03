using CSV;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PimsExporter;
using PimsExporter.Services.InputRepositories;
using PimsExporter.Services.OutputRepositories;
using Services.InputRepositories;
using Services.OutputRepositories;
using System;
using System.Net;
using System.Security;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateDefaultBuilder().Build();

            Console.Write("Password: ");
            var password = GetPassword();
            Console.WriteLine();
            var from = GetOmItemLowerRange();
            var to = GetOmItemUpperRange();

            var exporter = host.Services.GetRequiredService<IApplication>();
            exporter.Password = password;
            Console.WriteLine();
            Console.Write("Starting to export root...");
            exporter.ExportRoot();
            Console.WriteLine("Done.");
            Console.Write("Starting to export OM Items...");
            exporter.ExportOmItems(from, to);
            Console.WriteLine("Done.");

            Console.WriteLine();
            Console.WriteLine("Finished.");
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

        static IHostBuilder CreateDefaultBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app =>
                {
                    app.AddJsonFile("appsettings.json");
                    app.AddJsonFile($"appsettings.{Environment.UserName}.json", true);
                })
                .ConfigureServices((ctx, services) =>
                {
                    var exporterSettings = new ExporterSettings();
                    ctx.Configuration.GetSection(nameof(ExporterSettings)).Bind(exporterSettings);
                    services.AddSingleton(exporterSettings);

                    var csvAdapterSettings = new CsvAdapterSettings();
                    ctx.Configuration.GetSection(nameof(CsvAdapterSettings)).Bind(csvAdapterSettings);
                    services.AddSingleton(csvAdapterSettings);

                    services.AddSingleton<IInputRepositoryFactory, InputRepositoryFactory>();
                    services.AddSingleton<IOutputAdapter, CsvAdapter>();
                    services.AddSingleton<IOutputRepository, OutputRepository>();
                    services.AddSingleton<IApplication, Exporter>();
                });
        }

        private static SecureString GetPassword()
        {
            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.AppendChar(i.KeyChar);
                }
            }
            return pwd;
        }
    }
}
