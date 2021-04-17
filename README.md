# Serilog.Sample
Serilog Sample project

## What Is Serilog?
Is a third-party logging library that plugs into the default ILogger implementations. Also, enables developers to log the events into various destinations like files, console, databases, and more. It supports structured logging, which allows more details and information about the event to be logged.

You will need to isntalinstall the package `Serilog.AspNetCore` . Once installed you can already plug in in your Net Core Api project. 


```C#
    public class Program
    {
        public static void Main(string[] args)
        {
            // Read Configuration from appSettings
            // You can also configure it on the 'UseSerilog' method. 
            // That will overwrite what it is on the appsettings.json file
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //Initialize Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            Log.Information("Application Starting.");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
```

## Resources

* [Nuget](https://github.com/serilog/serilog)
* [Documentation](https://github.com/serilog/serilog/wiki)
* [Serilog Web site](https://serilog.net/)
* [Git hub](https://github.com/serilog/serilog)