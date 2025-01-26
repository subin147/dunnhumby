using Microsoft.EntityFrameworkCore;
using ProductManagment.Api.Data.Context;
using ProductManagment.Api.EndPoints;
using Serilog;
using FluentValidation;
using ProductManagment.Api;
using ProductManagment.Api.Data.Repositories;
using ProductManagment.Api.Middlewares;
var builder = WebApplication.CreateBuilder(args);

// Add environment-specific configuration files
var environment = builder.Environment.EnvironmentName;

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"app.{environment.ToLower()}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.ConfigureHttpJsonOptions(opts => opts.SerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ProductDatabase")));

builder.Services.AddValidatorsFromAssembly(typeof(ProductManagment.Api.DTOs.ProductDto).Assembly, includeInternalTypes: true);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository,ProductRepository>();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWeb", policy =>
    {
        policy.WithOrigins("http://localhost:3000") 
              .AllowAnyMethod()  
              .AllowAnyHeader()
              .AllowCredentials();  
    });
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.MapProductEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowWeb");
}

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseHttpsRedirection();


await app.RunAsync();

