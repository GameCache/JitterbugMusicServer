using System.Reflection;
using JitterbugMusic.Server.OpenSubsonic;
using Microsoft.AspNetCore.Mvc.Formatters;
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    _ = builder.Services.AddControllers(options =>
    {
        while (options.OutputFormatters.Count > 0)
        {
            options.OutputFormatters.RemoveAt(0);
        }
        options.OutputFormatters.Add(new SubsonicOutputFormatter());
        options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
    });

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    _ = builder.Services.AddEndpointsApiExplorer();
    _ = builder.Services.AddSwaggerGen(options =>
    {
        string xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

    WebApplication app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        _ = app.UseSwagger();
        _ = app.UseSwaggerUI();
    }

    _ = app.UseHttpsRedirection();
    _ = app.UseAuthorization();
    _ = app.MapControllers();
    app.Run();
}

/// <summary>Contains startup behavior.</summary>
public partial class Program { }