using AutoMapper;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;

using Api.Services;
using Api.Entities;
using Api.DbContexts;
using Api.Repositories;

namespace Api
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
            services.AddHealthChecks()
                    .AddDbContextCheck<TravelContext>("DB", HealthStatus.Unhealthy);

            services
                .AddControllers()
                .AddXmlDataContractSerializerFormatters()
                .ConfigureApiBehaviorOptions(setupAction =>
                {
                    setupAction.InvalidModelStateResponseFactory = context =>
                    {
                        // create a problem details object
                        var problemDetailsFactory = context.HttpContext.RequestServices
                             .GetRequiredService<ProblemDetailsFactory>();

                        var problemDetails = problemDetailsFactory.CreateValidationProblemDetails(
                                context.HttpContext,
                                context.ModelState);

                        if (context.ModelState.ErrorCount > 0 && problemDetails.Status.Equals(StatusCodes.Status400BadRequest))
                        {
                            List<String> errors = new List<string>();
                            foreach (var (key, value) in context.ModelState)
                            {
                                if (value.Errors.Any() && value.Errors[0] != null)
                                {
                                    if (value.Errors[0].ErrorMessage.StartsWith("Could not convert") ||
                                        value.Errors[0].ErrorMessage.StartsWith("Error converting value") ||
                                        value.Errors[0].ErrorMessage.StartsWith("The JSON value could not be converted"))
                                    {
                                        errors.Add($"{key.Replace("$.", "")} tipo de informação inválida");
                                    }
                                    else
                                    {
                                        errors.Add(value.Errors[0].ErrorMessage);
                                    }
                                }
                            }
                            return new BadRequestObjectResult(string.Join("; ", errors.Reverse<string>().ToList()));

                        }

                        return new StatusCodeResult(500);
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Travel Service",
                        Version = "v1",
                        Description = "The purpose of this service is to register my trips"
                    });
            });

            services.AddCors(c =>
                            {
                                c.AddPolicy("AllowOrigin",
                                options =>
                                options.WithOrigins("http://localhost:4200")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                );
                            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IValidateQueryService, ValidateQueryService>();

            services.AddScoped<IPageService<Travel>, PageService<Travel>>();
            services.AddScoped<ITravelRepository, TravelRepository>();

            services.AddDbContext<TravelContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DB"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(c => c.WithOrigins("http://localhost:4200"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Travel Service");
            });

            app.UseEndpoints(endpoints =>
            {
                var healthStatusCodes = new Dictionary<HealthStatus, int>()
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status200OK,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                };

                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    AllowCachingResponses = false,
                    ResultStatusCodes = healthStatusCodes,
                    ResponseWriter = WriteResponse,
                    Predicate = (_) => false
                });

                endpoints.MapHealthChecks("/health/details", new HealthCheckOptions()
                {
                    AllowCachingResponses = false,
                    ResultStatusCodes = healthStatusCodes,
                    ResponseWriter = WriteResponse
                });
            });

        }

        private static Task WriteResponse(HttpContext context, HealthReport result)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            var options = new JsonWriterOptions
            {
                Indented = true
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new Utf8JsonWriter(stream, options))
                {
                    writer.WriteStartObject();
                    writer.WriteString("status", result.Status.ToString());
                    writer.WriteStartObject("results");
                    foreach (var entry in result.Entries)
                    {
                        writer.WriteStartObject(entry.Key);
                        writer.WriteString("status", entry.Value.Status.ToString());
                        writer.WriteString("description", entry.Value.Description);
                        writer.WriteStartObject("data");
                        foreach (var item in entry.Value.Data)
                        {
                            writer.WritePropertyName(item.Key);
                            JsonSerializer.Serialize(
                                writer, item.Value, item.Value?.GetType() ??
                                typeof(object));
                        }
                        writer.WriteEndObject();
                        writer.WriteEndObject();
                    }
                    writer.WriteEndObject();
                    writer.WriteEndObject();
                }

                var json = Encoding.UTF8.GetString(stream.ToArray());

                return context.Response.WriteAsync(json);
            }
        }
    }
}
