using EP.API.Extensions;
using EP.Domain.Entities;
using EP.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EP.API.Middlewares;
using EP.Application.Services;
using EP.Domain.Interfaces.Repositories;
using EP.Domain.Interfaces.Services;
using EP.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.AddLogger();


// Add services to the container.

builder.Services.AddDbContext<ExtraDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("ExtraDataConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.AddSwaggerServices();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// ********************************************************** DI ********************************************************** //

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// ********************************************************** DI ********************************************************** //

builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
    })
    .AddEntityFrameworkStores<ExtraDbContext>()
    .AddDefaultTokenProviders();
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmpireOfPhone API v1");
        c.DocumentTitle = "EmpireOfPhone API Docs";
    });
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
