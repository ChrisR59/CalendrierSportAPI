using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaSportif.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AgendaSportif
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
            services.AddControllers();
            services.AddDbContext<DataDbContext>();//Ajouter authorize cross origin
            services.AddCors(cors =>
            {
                cors.AddPolicy("AllowAll", o =>
                {
                    o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                }); 
                
                cors.AddPolicy("LimitToOneOrigin", o =>
                {
                    o.WithOrigins("192.168.1.11").AllowAnyHeader().AllowAnyMethod();
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
            app.UseCors(options => {
                //Toute origine et toute methode et tout entete
                options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
