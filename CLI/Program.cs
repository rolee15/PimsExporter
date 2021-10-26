using PimsExporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateDefaultBuilder().Build();
            var appSettings = host.Services.GetRequiredService<IOptions<AppSettings>>().Value;

            Console.Write("Password: ");
            var password = GetPassword();
            Console.WriteLine();
            var exporter = new Exporter(new Uri(appSettings.SharepointUrl), new NetworkCredential(appSettings.UserName, password), appSettings.OutputDir);
            
            exporter.ExportAll();
            
            Console.WriteLine($"Url: {appSettings.SharepointUrl}");
            Console.WriteLine($"User: {appSettings.UserName}");
            Console.WriteLine($"Output: {appSettings.OutputDir}");
            
            Console.WriteLine("\nFinished.\n");
            Console.ReadLine();
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
                    services.Configure<AppSettings>(ctx.Configuration);
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
