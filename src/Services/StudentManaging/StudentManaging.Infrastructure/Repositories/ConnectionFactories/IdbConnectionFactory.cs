using System.Data;

namespace StudentManaging.Infrastructure.Repositories.ConnectionFactories
{
	public interface IdbConnectionFactory
	{
		IDbConnection GetDefaultServerConnectionString();
	}
}
