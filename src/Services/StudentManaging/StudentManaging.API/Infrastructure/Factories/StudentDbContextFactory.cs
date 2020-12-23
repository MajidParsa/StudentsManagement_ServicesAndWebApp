using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StudentManaging.Infrastructure.Repositories;

namespace StudentManaging.API.Infrastructure.Factories
{
	public class StudentDbContextFactory : IDesignTimeDbContextFactory<StudentContext>
	{
		public StudentContext CreateDbContext(string[] args)
		{
			var config = new ConfigurationBuilder()
				.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
				.AddJsonFile("appsettings.json")
				.AddEnvironmentVariables()
				.Build();

			var optionsBuilder = new DbContextOptionsBuilder<StudentContext>();

			optionsBuilder.UseSqlServer(config["QueryDataServer"], sqlServerOptionsAction: o => o.MigrationsAssembly("StudentManaging.Infrastructure"));

			return new StudentContext(optionsBuilder.Options);
		}
    }
}
