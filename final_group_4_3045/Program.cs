using final_group_4_3045.Data;
using final_group_4_3045.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;

namespace final_group_4_3045
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); // Create a new instance of the WebApplicationBuilder class to configure the application

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            // Microsoft documentation suggested putting dependency injection for the database context in Program.cs instead of a startup class.
            // This is because the Program.cs file is the entry point of the application and is responsible for configuring the services and middleware
            // that the application will use. By adding the database context to the services container in Program.cs, it ensures that the context is available
            // throughout the application and can be easily injected into controllers and other services as needed.
            builder.Services.AddOpenApiDocument(); // Add OpenAPI document generation to the services container (dependency injection)
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Add the database context to the services container (dependency injection)

            builder.Services.AddScoped<ITeamMemberContextDAO, TeamMemberDAO>(); // Add the TeamMemberDAO implementation of the ITeamMemberContextDAO interface to the services container (dependency injection)
            builder.Services.AddScoped<IMovieContextDAO, MovieDAO>(); // Add the MovieDAO implementation of the IMovieContextDAO interface to the services container (dependency injection)
            builder.Services.AddScoped<IHobbyContextDAO, HobbyDAO>(); // Add the HobbyDAO implementation of the IHobbyContextDAO interface to the services container (dependency injection)
            builder.Services.AddScoped<IBreakfastContextDAO, BreakfastFoodDAO>(); // Add the BreakfastFoodDAO implementation of the IBreakfastContextDAO interface to the services container (dependency injection)

            var app = builder.Build(); // Build the application using the configured services and middleware

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) // Check if the application is running in development environment
            {
                app.UseExceptionHandler("/Home/Error"); // Use exception handler middleware for error handling in development environment
                // app.MapOpenApi(); // Map OpenAPI endpoints for API documentation in development environment
                app.UseHsts();// Use HSTS (HTTP Strict Transport Security) in development environment for security

                // app.UseSwaggerUI(options =>
                // {
                    // options.SwaggerEndpoint("/openapi/v1.json", "v1");
                // }); // Enable Swagger UI for API documentation in development environment
                app.UseOpenApi(); // Enable OpenAPI middleware for API documentation in development environment
                app.UseSwaggerUI(); // Enable Swagger UI middleware for API documentation in development environment
            }
            app.UseRouting();

            app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS for secure communication

            app.UseAuthorization(); // Use authorization middleware for authentication and authorization


            app.MapControllers(); // Map controller routes for API endpoints

            app.MapStaticAssets(); // Map static assets for serving static files

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets(); // Map the default controller route with static assets

            app.Run(); // Run the application
        }
    }
}

