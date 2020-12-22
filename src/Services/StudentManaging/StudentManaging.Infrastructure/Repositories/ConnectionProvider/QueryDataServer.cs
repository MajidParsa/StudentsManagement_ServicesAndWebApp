using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace StudentManaging.Infrastructure.Repositories.ConnectionProvider
{
	public class QueryDataServer: IQueryDataServer
	{
		private readonly IDbConnectionFactory _dbConnectionFactory;

		public QueryDataServer(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}

		public IDbConnection GetConnectionString()
		{
			return _dbConnectionFactory.Create("QueryDataServer");
		}
	}
}
