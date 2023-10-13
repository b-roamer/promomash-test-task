using System.Text.Json.Serialization;
using Application;
using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Exceptions;
using WebAPI.Middleware;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Setting up Serilog config
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    .Enrich.WithMachineName()
    .CreateBootstrapLogger();

Log.Information("Starting up...");

// Setting up logger to use Serilog
builder.Host.UseSerilog();

// Add services to the container.
// Adding database context
var connectionString = builder.Configuration.GetConnectionString("PromomashTestTaskDB");
builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo {Title = "Promomash Test Task API", Version = "v1"});
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

// Adding layers
builder.Services
    .AddApplication()
    .AddInfrastructure();

// Adding Web API services
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

app.UseSerilogRequestLogging();

// Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<DatabaseContext>();

    Log.Information("Migrating database...");
    dbContext.Database.Migrate();
    Log.Information("Finished migrating database.");
}

// Global CORS policy
app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

// Adding custom middleware
app.ConfigureCustomMiddleware();

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