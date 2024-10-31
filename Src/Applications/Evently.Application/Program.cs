using Microsoft.AspNetCore.Builder;

namespace Evently.Application;

public static class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        Startup.ConfigurationService(builder.Services, builder.Configuration);

        WebApplication app = builder.Build();

        Startup.Configuration(app);

        app.Run();

    }
}

