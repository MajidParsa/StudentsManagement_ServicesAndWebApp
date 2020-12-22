using System;
using System.Data.Entity;

namespace StudentManaging.Infrastructure.Repositories.ConnectionProvider
{
	public class CommandDataServer : ICommandDataServer
	{
		public DbContext GetDbContext()
		{
			throw new NotImplementedException();
		}
	}
}
