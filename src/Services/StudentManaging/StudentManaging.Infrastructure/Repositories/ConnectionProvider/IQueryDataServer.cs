using System.Data;

namespace StudentManaging.Infrastructure.Repositories.ConnectionProvider
{
	public interface IQueryDataServer
	{
		IDbConnection GetConnectionString();
	}
}
