using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Constants;

namespace PimsExporter.Domain.Logging
{
   
    public class PimsLogger : IPimsLogger
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public PimsLogger()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = Path.Combine(LogOutputDir.dirPath, "log.txt") };

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            NLog.LogManager.Configuration = config;
        }
        
        public void LogInfo(string message)
        {
            Logger.Info(message);
        }
        public void LogError(string message)
        {
            Logger.Error(message);
        }
    }
}
