using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MilkShake.Data;
using MilkShake.Repository;
using MilkShake.UnitOfWork;
using Swashbuckle.AspNetCore;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MilkShakeDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MilkShakeContext") ?? throw new InvalidOperationException("Connection string 'MilkShakeContext' not found.")));


builder.Services.AddCors(
    o => o.AddPolicy("CorsPolicy", builder =>
    {
        builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .WithOrigins(
            "http://localhost:4200",
            "https://localhost:7149",
            "http://127.0.0.1:4200"

    );
    }));

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<UserRepository>();

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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
