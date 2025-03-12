namespace Dotcentric.Website;

public class Program
{
    public static IConfiguration Configuration { get; } =
        new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
            .AddJsonFile($"appsettings.{Environment.MachineName}.json", true, true)
            .AddEnvironmentVariables()
            .Build();

    public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureCmsDefaults()
            .ConfigureAppConfiguration((ctx, builder) =>
            {
                builder.AddConfiguration(Configuration);
            })
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}
