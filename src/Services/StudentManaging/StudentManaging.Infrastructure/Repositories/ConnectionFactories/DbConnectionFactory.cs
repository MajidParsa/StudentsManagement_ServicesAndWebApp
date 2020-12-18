using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using StudentManaging.Infrastructure.Exceptions;

namespace StudentManaging.Infrastructure.Repositories.ConnectionFactories
{
	public class DbConnectionFactory : IdbConnectionFactory
	{
		private readonly IConfiguration _configuration;

		public DbConnectionFactory(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IDbConnection GetDefaultServerConnectionString() => Create("DefaultServer");

		private IDbConnection Create(string connectionStringKey)
		{
			SqlConnection sqlConnection = GetSqlConnection(connectionStringKey);
			sqlConnection.Open();

			return sqlConnection;
		}

		private SqlConnection GetSqlConnection(string connectionStringKey)
		{
			string connectionString = string.IsNullOrWhiteSpace(connectionStringKey) ? throw new StudentManagingInfrastructureException() : _configuration.GetConnectionString(connectionStringKey);
			if (string.IsNullOrWhiteSpace(connectionString)) throw new StudentManagingInfrastructureException($"There is any connection string named {connectionStringKey}.");

			return new SqlConnection(connectionString);
		}

	}
}
