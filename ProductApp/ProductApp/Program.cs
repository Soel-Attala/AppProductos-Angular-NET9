using Microsoft.EntityFrameworkCore;
using ProductApp.Context;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AppDbContext>(optionsAction: options =>
    options.UseSqlServer(conectionString));
builder.Services.AddControllers();

//Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("https://localhost4200").AllowAnyMethod().AllowAnyHeader();
    });
});


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
