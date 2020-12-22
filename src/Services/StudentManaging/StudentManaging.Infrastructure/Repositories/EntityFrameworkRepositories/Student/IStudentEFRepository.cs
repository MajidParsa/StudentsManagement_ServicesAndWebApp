using System.Threading.Tasks;
using StudentManaging.Domain.SeedWork;

namespace StudentManaging.Infrastructure.Repositories.EntityFrameworkRepositories.Student
{
	public interface IStudentEFRepository : IRepository<Domain.AggregatesModel.Student.Student>
	{
		Task<bool> Add(Domain.AggregatesModel.Student.Student student);
		Task<bool> Update(Domain.AggregatesModel.Student.Student student);

	}
}
