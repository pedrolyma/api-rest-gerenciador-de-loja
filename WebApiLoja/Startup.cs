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

namespace WebApiLoja
{
    public class Startup
    {
        private readonly string MyCors = "";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string CorsPolicy = "_corsPolicy";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiLoja", Version = "v1" });
            });

            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(builder =>
            //        {
            //            builder.WithOrigins(Configuration.GetSection("AllowedOrigins").Get<string[]>())
            //            .WithHeaders("Authorization")
            //            .WithMethods("GET", "POST", "DELETE");
            //        });
            //    options.AddPolicy("SpecificOrigin", builder =>
            //    {
            //        builder.WithOrigins("http://localhost:4200").WithHeaders("Authorization");
            //    });
            //});

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                    builder => builder.WithOrigins("http://localhost:4200", "http://localhost:4200") // novo
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder  //novo
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiLoja v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("*");
            //           app.UseCors();
            //           app.UseCors(option => option.AllowAnyMethod()
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllers().RequireCors(CorsPolicy); // novo
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = string.Empty;
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Rest Controle de Loja de Confeccoes");
            });
        }
    }
}
