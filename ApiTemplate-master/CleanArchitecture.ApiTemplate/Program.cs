using AspNetCoreRateLimit;
using CleanArchitecture.DataAccess;
using CleanArchitecture.DataAccess.Models;
using CleanArchitecture.Services;
using CleanArchitecture.Services.Interfaces;
using CleanArchitecture.Services.Services;
using CleanArchitecture.Utilities.MiddelWare;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using CleanArchitecture.Services.Interfaces.ICuttingDownIgnoredService;
using CleanArchitecture.Services.Services.CuttingDownIgnoredService;
using CleanArchitecture.Services.Interfaces.IcuttingDownMasterService;
using CleanArchitecture.Services.Services.CuttingDownMasterService;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace CleanArchitecture.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;



            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDevClient", policy =>
                {
                    policy.AllowAnyOrigin()      // ✅ This allows requests from all domains
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // ============================
            // 1. Dependency Injection Setup
            // ============================
            // Register Data Access Layer, Service Layer, and API Layer services
            builder.Services
                .AddDataAccessServices(config)
                .AddServiceLayer()
                .AddApiLayer(config);

            // Register CuttingDownService with DI container
            builder.Services.AddScoped<ICuttingDownService, CuttingDownService>();
            builder.Services.AddScoped<ICuttingDownIgnoredService, CuttingDownIgnoredService>();
            builder.Services.AddScoped<ICuttingDownMasterService,  CuttingDownMasterService>();




            // ============================
            // 2. Identity Configuration
            // ============================
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CleanArchitecture.DataAccess.Contexts.ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Disable requirement for confirmed email during sign-in for testing convenience
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
            });

            // Add Authorization services (policies, roles, etc.)
            builder.Services.AddAuthorization();

            // ============================
            // 3. Rate Limiting Configuration
            // ============================
            // Enable in-memory caching required by rate limiting middleware
            builder.Services.AddMemoryCache();

            // Configure IP-based rate limiting options and policies from appsettings.json
            builder.Services.Configure<IpRateLimitOptions>(config.GetSection("IpRateLimiting"));
            builder.Services.Configure<IpRateLimitPolicies>(config.GetSection("IpRateLimitPolicies"));

            // Add in-memory rate limiting stores and services
            builder.Services.AddInMemoryRateLimiting();
            builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            // ============================
            // 4. Response Compression Setup
            // ============================
            builder.Services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true; // Enable compression for HTTPS requests
                options.Providers.Add<GzipCompressionProvider>(); // Use Gzip compression
            });

            builder.Services.Configure<GzipCompressionProviderOptions>(options =>
            {
                // Set compression level to fastest to optimize for speed over size
                options.Level = System.IO.Compression.CompressionLevel.Fastest;
            });

            // ============================
            // 5. JSON Serialization Configuration
            // ============================
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // Use camelCase naming for JSON properties
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

                    // Disable pretty-printing to reduce payload size
                    options.JsonSerializerOptions.WriteIndented = false;

                    // Ignore null properties in serialized JSON
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });
            // enum
            builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

            // ============================
            // 6. Build Application
            // ============================
            var app = builder.Build();

            // ============================
            // 7. Middleware Pipeline Setup
            // ============================
            // Enable IP rate limiting middleware to enforce request limits
            app.UseIpRateLimiting();
            app.UseCors("AllowAngularDevClient");


            // Custom middleware to limit bandwidth (request size) per client IP
            app.UseMiddleware<BandwidthLimitMiddleware>();

            // Enable response compression middleware
            app.UseResponseCompression();

            // Serve swagger UI and API documentation in Development environment only
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Serve static files like images, JS, CSS from wwwroot folder
            app.UseStaticFiles();

            // Redirect HTTP requests to HTTPS
            app.UseHttpsRedirection();

            // Enable authentication and authorization middlewares
            app.UseAuthentication();
            app.UseAuthorization();

            // Map API controller routes
            app.MapControllers();

            // Run the web application
            app.Run();
        }
    }
}
