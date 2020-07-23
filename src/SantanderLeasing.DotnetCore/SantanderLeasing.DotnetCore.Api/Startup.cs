using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SantanderLeasing.DotnetCore.DbServices;
using SantanderLeasing.DotnetCore.DbServices.Model;
using SantanderLeasing.DotnetCore.FakeServices;
using SantanderLeasing.DotnetCore.FakeServices.Fakers;
using SantanderLeasing.DotnetCore.IServices;
using SantanderLeasing.DotnetCore.Models;

namespace SantanderLeasing.DotnetCore.Api
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

            services.AddSingleton<ICustomerService, FakeCustomerService>();
            services.AddScoped<IOrderService, DbOrderService>();

            services.AddSingleton<IServices.IProductService, FakeProductService>();
            services.AddSingleton<Faker<Models.Product>, ProductFaker>();


            string connectionString = Configuration.GetConnectionString("MyConnection");

            services.AddDbContext<AdventureWorksLT2016Context>(
                options => options.UseSqlServer(connectionString));

            services.Configure<CustomerOptions>(Configuration.GetSection("CustomerOptions"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            int customerCount = int.Parse(Configuration["CustomerCount"]);

            string url = Configuration["CustomerModule:Uri"];

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapGet("/hello", )
                endpoints.MapControllers();
            });
        }
    }
}
