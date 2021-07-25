using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;

namespace Logging.ConsoleApp
{
    class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        static void Main(string[] args)
        {
            // Load configuration
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            _log.Info("This is log info");
            _log.Error("This is log error");
            _log.Warn("This is log warning");
            _log.Fatal("This is log fatal");

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
