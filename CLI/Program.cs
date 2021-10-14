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
            //var output = new Output("c:\\pims.csv", Output.CSV);
            //var exporter = new Exporter(sharepointSite, credentials, output);

            //exporter.ExportAll();

            Console.WriteLine($"\nUser: {credentials.UserName}\nPass: {credentials.Password}\n");

            Console.WriteLine("Finished.\n");
            Console.ReadLine();
        }

        private static NetworkCredential GetCredentials()
        {
            Console.Write("Username: ");
            var userName = GetUserName();
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

        private static string GetUserName()
        {
            return Console.ReadLine();
        }
    }
}
