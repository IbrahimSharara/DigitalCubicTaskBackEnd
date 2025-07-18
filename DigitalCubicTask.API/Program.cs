using DigitalCubicTask.API.Entities;
using DigitalCubicTask.API.Interfaces;
using DigitalCubicTask.API.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITaskService ,  TaskService>();
builder.Services.AddDbContext<ApplicationDBContext>((DbContextOptionsBuilder op) =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddCors(
    op =>
    {
        op.AddPolicy("AllowAllOrigins", builder =>
        {
            builder.AllowAnyMethod()
                   .AllowAnyHeader()
            .AllowAnyOrigin();

        });
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
app.UseCors("AllowAllOrigins");
app.Run();
