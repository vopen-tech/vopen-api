using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Swashbuckle.AspNetCore.Swagger;
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            // Add Swagger generation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "vOpen API",
                    Version = "v1",
                    Description = "The API of the open source conferences",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Mariano Vazquez",
                        Email = "marianodvazquez@gmail.com",
                        Url = "https://nanovazquez.dev"
                    },
                    License = new License { Name = "MIT" }
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<VOpenDbContext>(builder => builder.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<EventsRepository, EventsRepository>();
            services.AddScoped<EditionsRepository, EditionsRepository>();
            services.AddScoped<EditionsActivitiesRepository, EditionsActivitiesRepository>();
            services.AddScoped<EditionsActivitiesScoresRepository, EditionsActivitiesScoresRepository>();
            services.AddScoped<LegacyGlobalRepository, LegacyGlobalRepository>();

            // TODO: remove
            // var optionsBuilder = new DbContextOptionsBuilder<VOpenDbContext>();
            // optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            // VOpenDbInitializer.Cleanup(optionsBuilder.Options);
            // VOpenDbInitializer.Seed(optionsBuilder.Options);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");

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

            app.UseMvc();
        }
    }
}
