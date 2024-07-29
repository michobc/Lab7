using System.Text.Json.Serialization;
using LabSession4_CodeFirst.Configurations;
using LabSession4_CodeFirst.Models;
using LabSession4_CodeFirst.Services;
using LabSession4_CodeFirst.Services.Abstractions;
using LabSession4_CodeFirst.Settings;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext with Npgsql for PostgreSQL
builder.Services.AddDbContext<UniversityContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add AutoMapper to the container
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });
builder.Services.AddEndpointsApiExplorer();

// Swagger configuration
builder.Services.AddSwaggerServices();
builder.Services.AddAuthenticationServices(builder.Configuration);


// JWT configuration
var jwtSettings = new JwtSettings();
builder.Configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);
builder.Services.AddSingleton(jwtSettings);

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IKeycloakAuthService, KeycloakAuthService>();

builder.Services.AddHttpClient();

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

app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = "/files",
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    RequestPath = "/files"
});

app.MapControllers();

app.Run();