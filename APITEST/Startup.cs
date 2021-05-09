using BusinessModel;
using BusinessModel.Helpers;
using BusinessModel.Interfaces;
using BusinessModel.Services;
using DataModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace APITEST
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);     

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            var config = new AutoMapper.MapperConfiguration(cfg =>
           {
               cfg.AddProfile(new Mappings());
           });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IUnitofWork, UnitofWork>();
            services.AddTransient<ICustomerService, CustomerService>();            
            services.AddDbContext<CustomerDbContext>(opt =>
              {
                opt.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\APITEST\DataModel\App_Data\Database.mdf;Integrated Security=True");
              });
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Customer Info API",
                    Version = "v1",
                    Description = "Customer Info API are meant to provide customer information."
                });
            });            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {           
            app.UseStaticFiles();            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Info API V1");
            });

            app.UseRouting();
            app.UseCors(
            options => options.WithOrigins("http://localhost:4200").AllowAnyMethod()
    );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
