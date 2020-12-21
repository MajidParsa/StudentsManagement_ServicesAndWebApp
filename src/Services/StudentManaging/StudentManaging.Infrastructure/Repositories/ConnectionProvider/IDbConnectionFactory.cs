using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace StudentManaging.Infrastructure.Repositories.ConnectionProvider
{
	public interface IDbConnectionFactory
	{
		IDbConnection Create(string connectionStringKey);
	}
}
