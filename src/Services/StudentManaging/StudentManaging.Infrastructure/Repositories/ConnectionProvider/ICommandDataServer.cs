using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace StudentManaging.Infrastructure.Repositories.ConnectionProvider
{
	public interface ICommandDataServer
	{
		DbContext GetDbContext();
	}
}
