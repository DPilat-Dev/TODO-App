using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.Services;
using ToDoApp.Core.Interfaces;
using ToDoApp.Infrastructure.Data;
using ToDoApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext to use SQL Server with connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register your services and repositories
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IToDoService, ToDoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Root path for Swagger
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
