using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace StudentManaging.Infrastructure.Repositories.ConnectionProvider
{
	public class QueryDataServer: IQueryDataServer
	{
		private readonly DbConnectionFactory _connectionFactory;

		public QueryDataServer(DbConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		public IDbConnection GetConnectionString()
		{
			return _connectionFactory.Create("QueryDataServer");
		}
	}
}
