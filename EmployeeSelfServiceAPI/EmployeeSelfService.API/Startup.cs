using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSelfService.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace EmployeeSelfService.API
{
    public class Startup
    {
        public const string AllowAllCorsPolicyName = "AllowAll";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<EmployeeService, EmployeeService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee Self Service API", Version = "v1" });
            });
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(AllowAllCorsPolicyName,
                    builder =>
                    {
                        builder
                            .SetIsOriginAllowed(origin => true)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(); // Images, Icons, Swagger Custom files

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(AllowAllCorsPolicyName);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    env.IsDevelopment() ? "/swagger/v1/swagger.json" : "/EmployeeSelfServiceAPI/swagger/v1/swagger.json",
                    "EmployeeSelfServiceAPI");

                c.RoutePrefix = string.Empty; // To serve the Swagger UI at the apps root (http://localhost)
            });
        }
    }
}
