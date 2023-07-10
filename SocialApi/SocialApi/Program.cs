using Microsoft.EntityFrameworkCore;
using SocialApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(
        options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("conn"));
        }
    );

builder.Services.AddCors(
        options =>
        {
            options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    }
                );
        }
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseCors();

app.MapControllers();

app.Run();
