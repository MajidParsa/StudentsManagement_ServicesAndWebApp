using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManaging.Domain.AggregatesModel.Student;
using StudentManaging.Domain.SeedWork;

namespace StudentManaging.Infrastructure.Repositories
{
	public class StudentContext : DbContext, IUnitOfWork
	{
		public DbSet<Student> Students { get; set; }

		public StudentContext(DbContextOptions<StudentContext> options) : base(options){ }

		public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			var result = await base.SaveChangesAsync(cancellationToken);

			return true;
		}
	}
}
