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
using Erebor.Service.Product.Core.Domain;
using Erebor.Service.Product.Core.Interface;
using Erebor.Service.Product.Domain.Repositories;
using Erebor.Service.Product.Infrastructure.Context;
using Erebor.Service.Product.Infrastructure.Repository;
using Erebor.Service.Product.SharedKernel;
using Erebor.Service.Product.SharedKernel.Interfaces;
using MongoDB.Driver;

namespace Erebor.Service.Product.Api
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
            services.AddScoped<ICourier,Courier>();
            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoDbSettings:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoDbSettings:Database").Value;
            });
            services.AddScoped<IApplicationContext, ApplicationContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            
            services.AddTransient<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
            services.AddTransient<ICommandHandler<CreateCategoryCommand>, CreateCategoryCommandHandler>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Erebor.Service.Product.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Erebor.Service.Product.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
