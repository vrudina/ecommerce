using Microsoft.EntityFrameworkCore;
using shopping_app_auth.Model;
using shopping_app_auth.Repository.Interfaces;
using shopping_app_auth.Repository;
using shopping_app_auth.Services.Interfaces;
using shopping_app_auth.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container.
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingAuth")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Register the repositories
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

// Register the services
builder.Services.AddScoped<IRoleService, RoleService>();

// Register the logger service as a singleton
builder.Services.AddSingleton<ILoggerService, LoggerService>();

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
