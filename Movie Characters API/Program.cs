using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Movie_Characters_API.Models;
using Movie_Characters_API.Services.Characters;
using Movie_Characters_API.Services.Franchises;
using Movie_Characters_API.Services.Movies;
using System.Reflection;

namespace Movie_Characters_API
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<MovieCharactersDbContext>(
                opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<ICharacterService, CharacterService>();
            builder.Services.AddScoped<IFranchiseService, FranchiseService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen( options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Movie Characters API",
                    Description = "API to manage movies, franchises and their characters",
                    Contact = new OpenApiContact
                    {
                        Name = "J&S",
                        Url = new Uri("https://gitlab.com/jonashl"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                options.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}