using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MilkShake.Data;
using Swashbuckle.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MilkShakeDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MilkShakeContext") ?? throw new InvalidOperationException("Connection string 'MilkShakeContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
