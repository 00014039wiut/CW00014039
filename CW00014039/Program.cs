using CW00014039.Data;
using CW00014039.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

internal class Program
{
    private static void Main(string[] args)
    {
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";



        var builder = WebApplication.CreateBuilder(args);





        builder.Services.AddCors(options =>

        {

            options.AddPolicy(MyAllowSpecificOrigins,

                       policy =>

                       {

                           policy.WithOrigins("http://localhost:4200")

                           .AllowAnyHeader()

                           .AllowAnyMethod()

                           .AllowAnyOrigin();

                       });

        });

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<FeedbackDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FeedbackConnectionString")));
        builder.Services.AddScoped<IFeedbacksRepository, FeedbacksRepository>();
        builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();
       

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors(MyAllowSpecificOrigins);

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}