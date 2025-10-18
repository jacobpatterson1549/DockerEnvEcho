using System;
using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace DockerEnvEcho;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI(opts => opts.EnableTryItOutByDefault());
        app.MapGet("/", () => Results.Redirect("/swagger"))
            .WithSummary("Redirects to the Swagger documentation page.");
        app.MapGet("/hello", () => "Hello, World!")
            .WithSummary("Returns a greeting");
        app.MapGet("/my_env", () => Environment.GetEnvironmentVariables()
            .Cast<DictionaryEntry>()
            .Where(kvp => kvp.Key?.ToString()?.StartsWith("MY_") ?? false))
            .WithSummary("Lists the environment variable names and values for variables with names that start with MY_");

        app.Run();
    }
}

