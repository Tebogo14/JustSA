using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Just.Entityframeworkcore;
using Just.Entityframeworkcore.EntityFramework;
using JustSA.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace JustSA
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<JustDbContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString(JustConst.ConnectionStringName)));

            services.AddScoped<IMemberService, MemberService>();

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("version1", new OpenApiInfo
                {
                    Version = "Version1",
                    Title = "Just API",
                    Description = "This are API for the Just Sport Capture Members"
                });
            });

            services.AddCors(
            options => options.AddPolicy(
            MyAllowSpecificOrigins,
                builder => builder
            .WithOrigins(Configuration["App:CorsOrigins"].Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray()
            ).AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()));


            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(swagger =>
            {
                swagger.SwaggerEndpoint("/swagger/version1/swagger.json", "Just API");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
