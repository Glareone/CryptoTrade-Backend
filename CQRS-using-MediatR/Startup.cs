﻿using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using CQRS_using_MediatR.DAL.Repository;
using CQRS_using_MediatR.Infrastructure.BrokerClients;
using CQRS_using_MediatR.Infrastructure.BrokerClients.BtcBrokerClient;
using CQRS_using_MediatR.Infrastructure.Mapper;
using CQRS_using_MediatR.Infrastructure.Services;

namespace CQRS_using_MediatR
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
            services.AddControllers().
                AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "CryptoTrade Backend API", Version = "v1" });
            });
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddScoped<IBrokerService, BrokerService>();
            services.AddScoped<IBtcBrokerClient, BtcBrokerClient>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "CryptoTrade Backend API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}