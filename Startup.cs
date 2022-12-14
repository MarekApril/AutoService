using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoServis.Authorization;
using AutoServis.Contracts;
using AutoServis.Entities;
using AutoServis.Factory;
using Microsoft.EntityFrameworkCore;

namespace AutoServis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                    builder => builder.WithOrigins("http://10.0.2.2:5001" ,"http://localhost:5001", "http://127.0.0.1:5001", "http://192.168.1.1", "http://127.0.0.1", "http://127.0.0.1:8080")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            services.AddControllers();
            services.AddSwaggerGen();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddDbContext<AutoServiceDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AutoServiceDb")));
            services.AddScoped<IAdresFactory, AdresFactory>();
            services.AddScoped<IKontrahentFactory, KontrahentFactory>();
            services.AddScoped<IZamowieniaFactory, ZamowieniaFactory>();
            services.AddScoped<IMechanikFactory, MechanikFactory>();
            services.AddScoped<ISamochodFactory, SamochodFactory>();
            services.AddTransient<ISendGridEmailFactory, SendGridEmailFactory>();
            services.Configure<SendGridEmailSenderOptions>(options =>
            {
                options.ApiKey = Configuration["ExternalProviders:SendGrid:ApiKey"];
                options.SenderEmail = Configuration["ExternalProviders:SendGrid:SenderEmail"];
                options.SenderName = Configuration["ExternalProviders:SendGrid:SenderName"];
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoServis v1"));
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Median from Number API");
            });

            app.UseRouting();

            app.UseCors("CorsApi");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
