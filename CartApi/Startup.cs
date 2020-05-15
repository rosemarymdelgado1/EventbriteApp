
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using Autofac;
using MassTransit;
using CartApi.Messaging.Consumers;
using Autofac.Extensions.DependencyInjection;
using MassTransit.Util;
using RabbitMQ.Client;
namespace CartApi

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
            services.AddControllers().AddNewtonsoftJson();
            services.AddTransient<ICartRepository, RedisCartRepository>();
            services.AddSingleton<ConnectionMultiplexer>(cm =>
            {
                var configuration = ConfigurationOptions.Parse(Configuration["ConnectionString"], true);
                configuration.ResolveDns = true;
                configuration.AbortOnConnectFail = false;
                return ConnectionMultiplexer.Connect(configuration);
            });

            ConfigureAuthService(services);

            services.AddSwaggerGen(options =>

            {
                //options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Eventbrite - Basket API",
                    Version = "v1",
                    Description = "Basket service API"
                });
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{Configuration["IdentityUrl"]}/connect/authorize"),
                            TokenUrl = new Uri($"{Configuration["IdentityUrl"]}/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {"basket", "Basket Api" }
                            }
                        }
                    }
                });
            });

            //for registring RabbitMQ
            services.AddMassTransit(cfg =>
            {
                //here add event consumer because cart will be consuming the msg
                cfg.AddConsumer<OrderCompletedEventConsumer>();
                cfg.AddBus(provider =>
                {
                    return Bus.Factory.CreateUsingRabbitMq(rmq =>
                    {
                        rmq.Host(new Uri("rabbitmq://rabbitmq"), "/", h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });
                        //this is queue name for cartapi. can have multiple queues
                        rmq.ReceiveEndpoint("EventscartApr20", e =>
                        {
                            e.ConfigureConsumer<OrderCompletedEventConsumer>(provider);

                        });
                    });

                });
            });

            services.AddMassTransitHostedService();
        }
        


        private void ConfigureAuthService(IServiceCollection services)

        {

            // prevent from mapping "sub" claim to nameidentifier.

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            var identityUrl = Configuration["IdentityUrl"];

            services.AddAuthentication(options =>

            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>

            {
                options.Authority = identityUrl;
                options.RequireHttpsMetadata = false;
                options.Audience = "basket";
            });

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)

        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger()

                .UseSwaggerUI(e =>

                {
                    e.SwaggerEndpoint("/swagger/v1/swagger.json", "BasketAPI V1");
                });

            app.UseEndpoints(endpoints =>

            {
                endpoints.MapControllers();
            });

        }

    }

}