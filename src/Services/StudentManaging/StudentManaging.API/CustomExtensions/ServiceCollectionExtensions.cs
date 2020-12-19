using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using StudentManaging.API.Infrastructure.Filters;
using StudentManaging.Infrastructure.Repositories.ConnectionFactories;
using StudentManaging.Infrastructure.Repositories.EntityFrameworkRepositories.Data;

namespace StudentManaging.API.CustomExtensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
		{
			// Register the Swagger generator
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "StudentManaging.API",
					Version = "v1",
					Description = "The Student Managing Service HTTP API",
				});
			});

			return services;
		}

		public static IServiceCollection AddCustomMvc(this IServiceCollection services)
		{
			// Add framework services.
			services.AddMvc(options =>
				{
					options.Filters.Add(typeof(HttpGlobalExceptionFilter));
				})
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
				.AddFluentValidation()
				//.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
				.AddControllersAsServices();

			return services;
		}

		public static IServiceCollection AddCustomCors(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder
						.SetIsOriginAllowed((host) => true)
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials());
			});

			return services;
		}

		public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddDbContext<StudentDbContext>
				(options =>
					options.UseSqlServer(configuration.GetConnectionString("DefaultServer"))
				);

			return services;
		}

		public static IServiceCollection AddMediatR(this IServiceCollection services)
		{
			services.AddMediatR(Assembly.GetExecutingAssembly());

			return services;
		}

		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddSingleton<IdbConnectionFactory, DbConnectionFactory>();

			return services;
		}

		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			//services.AddSingleton<IMerchantService, MerchantService>();

			return services;
		}

		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
		{
			services.AddSingleton<JsonSerializer>();

			return services;
		}
	}
}
