using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using vopen_api.Data;
using vopen_api.Repositories;

namespace vopen_api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "vOpen API",
                    Version = "v1",
                    Description = "The API of the open source conferences",
                    Contact = new OpenApiContact
                    {
                        Name = "Mariano Vazquez",
                        Email = "marianodvazquez@gmail.com",
                        Url = new System.Uri("https://nanovazquez.dev")
                    },
                    License = new OpenApiLicense { Name = "MIT" }
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddMemoryCache();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

            services.AddDbContext<VOpenDbContext>(builder => builder.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<EventsRepository, EventsRepository>();
            services.AddScoped<EditionsRepository, EditionsRepository>();
            services.AddScoped<EditionsActivitiesRepository, EditionsActivitiesRepository>();
            services.AddScoped<EditionsActivitiesScoresRepository, EditionsActivitiesScoresRepository>();
            services.AddScoped<LegacyGlobalRepository, LegacyGlobalRepository>();

            //// TODO: remove
            //var optionsBuilder = new DbContextOptionsBuilder<VOpenDbContext>();
            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //VOpenDbInitializer.Cleanup(optionsBuilder.Options);
            //VOpenDbInitializer.Seed(optionsBuilder.Options);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            // {documentname} is the c.SwaggerDoc name ("v1", see services.AddSwaggerGen)
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/{documentname}/swagger/swagger.json";
            });

            // Enable middleware to serve the Swagger UI, specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/v1/swagger/swagger.json", "vOpen API V1");
                c.RoutePrefix = "api/swagger";
            });

            // Setup Static files server
            // (see https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-2.2)
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                RequestPath = "/static-files"
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("default");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
