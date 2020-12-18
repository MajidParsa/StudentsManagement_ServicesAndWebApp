using System;
using StudentManaging.Infrastructure.Repositories.ConnectionFactories;

namespace StudentManaging.Infrastructure.Repositories
{
	public abstract class RepositoryContext
	{
		protected readonly IdbConnectionFactory _dbConnectionFactory;

		public RepositoryContext(IdbConnectionFactory dbConnectionFactory) => 
			_dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
	}
}
