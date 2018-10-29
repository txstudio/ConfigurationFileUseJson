using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ConsoleApp
{

    

    class Program
    {
        static void Main(string[] args)
        {
            //appsettings.json properties => Copy to Output Directory : "Copy if newer"
            var builder = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            
            IConfigurationRoot configuration = builder.Build();

            //取得連線字串
            Console.WriteLine("ConnectionString \"TestDb\"");
            Console.WriteLine(configuration.GetConnectionString("TestDb"));
            Console.WriteLine();
            Console.WriteLine("ConnectionString \"ProductionDb\"");
            Console.WriteLine(configuration.GetConnectionString("ProductionDb"));
            Console.WriteLine();
            Console.WriteLine();

            //取得應用程式設定
            Console.WriteLine("ApplicationName: {0}", configuration["ApplicationName"]);
            Console.WriteLine("Version: {0}", configuration["Version"]);
            Console.WriteLine();
            Console.WriteLine();

            //使用強行別指定應用程式
            //  dotnet add package Microsoft.Extensions.Configuration.Binder
            AppSettings _appSettings = configuration.Get<AppSettings>();

            Console.WriteLine("strongly typed configuration");
            Console.WriteLine(JsonConvert.SerializeObject(_appSettings, Formatting.Indented));

            Console.WriteLine();
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }
}
