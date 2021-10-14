using PimsExporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var sharepointSiteUrl = GetSharePointSiteUrl();
            var credentials = GetCredentials();
            var outDirPath = GetOutputPath();
            Console.WriteLine();
            var exporter = new Exporter(sharepointSiteUrl, credentials, outDirPath);

            exporter.ExportAll();

            Console.WriteLine($"Url: {sharepointSiteUrl}");
            Console.WriteLine($"User: {credentials.UserName}");
            Console.WriteLine($"Pass: {credentials.Password}");

            Console.WriteLine("\nFinished.\n");
            Console.ReadLine();
        }

        private static string GetOutputPath()
        {
            Console.WriteLine("Output dir path: ");
            return Console.ReadLine();
        }

        private static Uri GetSharePointSiteUrl()
        {
            Console.Write("Sharepoint site url: ");
            var url = Console.ReadLine();
            return new Uri(url);
        }

        private static NetworkCredential GetCredentials()
        {
            Console.Write("Username: ");
            var userName = Console.ReadLine();
            Console.Write("Password: ");
            var password = GetPassword();
            return new NetworkCredential(userName, password);
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
