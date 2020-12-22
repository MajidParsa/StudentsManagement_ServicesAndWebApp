using System;
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
using StudentManaging.Application.Commands.Student;
using StudentManaging.Infrastructure.Repositories;
using StudentManaging.Infrastructure.Repositories.ConnectionProvider;
using StudentManaging.Infrastructure.Repositories.DapperRepositories.Student;
using StudentManaging.Infrastructure.Repositories.EntityFrameworkRepositories.Student;

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
			//services
			//	.AddDbContext<StudentContext>
			//	(options =>
			//		options.UseSqlServer(configuration.GetConnectionString("QueryDataServer"))
			//	);

			services.AddEntityFrameworkSqlServer()
				.AddDbContext<StudentContext>(options =>
					{
						options.UseSqlServer(configuration["QueryDataServer"],
							sqlServerOptionsAction: sqlOptions =>
							{
								sqlOptions.MigrationsAssembly(typeof(StudentContext).GetTypeInfo().Assembly.GetName().Name);
								sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
							});
					},
					ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
				);


			return services;
		}

		public static IServiceCollection AddMediatR(this IServiceCollection services)
		{
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddMediatR(typeof(AddStudentCommand).GetTypeInfo().Assembly);

			return services;
		}

		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
			services.AddSingleton<IQueryDataServer, QueryDataServer>();
			services.AddSingleton<IStudentDapperRepository, StudentDapperRepository>();
			services.AddSingleton<IStudentEFRepository, StudentEFRepository>();

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
