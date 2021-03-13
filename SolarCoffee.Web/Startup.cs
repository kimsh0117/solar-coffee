using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using SolarCoffee.Data;
using SolarCoffee.Services.Customer;
using SolarCoffee.Services.Inventory;
using SolarCoffee.Services.Order;
using SolarCoffee.Services.Product;

namespace SolarCoffee.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(opts => {
              opts.SerializerSettings.ContractResolver = new DefaultContractResolver {
                NamingStrategy = new CamelCaseNamingStrategy()
              };
            });
            services.AddDbContext<SolarDbContext>(opts =>
            {
              opts.EnableDetailedErrors();
              opts.UseNpgsql(Configuration.GetConnectionString("solar.dev"));
            });
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IInventoryService, InventoryService>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SolarCoffee.Web", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SolarCoffee.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder =>
              builder
                .WithOrigins(
                  "http://localhost:8080",
                  "http://localhost:8081",
                  "http://localhost:8082")
                .AllowAnyMethod() // POST, PUT, DELETE 와 같은 메소드를 처리
                .AllowAnyHeader()
                .AllowCredentials()
              );
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
