using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Training.Application.Services;
using Training.Data.Domain;
using Training.Data.EF;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Training.Presentation.API.Filters;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System;
using System.IO;

namespace Training.Presentation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            InitDbContext(services);
            RegisterRepositories(services);
            RegisterServices(services);
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = ".NET Academy", Version = "Lesson 13" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<UnitOfWork>();
                context.Database.Migrate();
            }
         
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private void InitDbContext(IServiceCollection services)
        {
            services.AddDbContext<UnitOfWork>(opts =>
                opts.UseSqlServer(Configuration["ConnectionString:NetCoreTrainingDB"]));
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IStudioRepository, StudioRepository>();
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<MyResultFilter>();
            services.AddScoped<MyActionFilter>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<IStudioService, StudioService>();
            services.AddScoped<ISessionService, SessionService>();
        }
    }
}