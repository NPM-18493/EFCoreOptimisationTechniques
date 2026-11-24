using EFDatabaseLayer;
using ServiceLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = "Data Source=127.0.0.1,1433;Initial Catalog=EFCoreOptimizationLab;User ID=sa;Password=TimCookRetired@2026;Pooling=False;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Authentication=SqlPassword;Application Name=vscode-mssql;Connect Retry Count=1;Connect Retry Interval=10;Command Timeout=30";//builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Register the DbContext in Dependency Injection (MISSING PIECE)
builder.Services.AddDbContext<EfcoreOptimizationLabContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
