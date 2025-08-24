using DotNetEnv;
using EP.API.Extensions;
using EP.Application;
using EP.Infrastructure;
using EP.Infrastructure.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.AddLogger();
Env.Load();

builder.Configuration.AddEnvironmentVariables();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JWT_SETTINGS"));
builder.Services.AddControllers();
builder.Services.AddSwaggerServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddCorsPolicies();
builder.Services.AddJwtConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.AddAspMiddlewares();
app.AddMinimalApis();
app.Run();
