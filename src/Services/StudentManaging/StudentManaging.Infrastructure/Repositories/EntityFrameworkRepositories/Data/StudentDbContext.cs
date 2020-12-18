using Microsoft.EntityFrameworkCore;

namespace StudentManaging.Infrastructure.Repositories.EntityFrameworkRepositories.Data
{
	public class StudentDbContext : DbContext
	{
		public StudentDbContext(DbContextOptions<StudentDbContext> options) 
			: base(options){ }
	}
}
