using System;

namespace StudentManaging.Infrastructure.Repositories
{
	public abstract class RepositoryContext
	{
		protected readonly IdbConnectionProvider _dbConnectionFactory;

		public RepositoryContext(IdbConnectionProvider dbConnectionFactory) => 
			_dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
	}
}
