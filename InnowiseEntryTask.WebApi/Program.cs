using InnowiseEntryTask.Data;
using InnowiseEntryTask.Services;
using InnowiseEntryTask.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace InnowiseEntryTask.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            string connectionString = builder.Configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("Failed to find default connection string");
            options.UseSqlServer(connectionString: connectionString);
        });

        builder.Services
            .AddScoped<IModelMapper<Song, SongOutputModel>, SongMapper>()
            .AddScoped<IEntityMapper<SongInputModel, Song>, SongMapper>()
            .AddScoped<ISongOperator, SongOperator>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Innowise Entry Task API",
                Contact = new OpenApiContact()
                {
                    Name = "Nikita Mihalchenko",
                    Email = "Halfer2000@gmail.com",
                },
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
