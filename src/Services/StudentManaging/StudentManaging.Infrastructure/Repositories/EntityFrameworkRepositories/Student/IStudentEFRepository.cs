using StudentManaging.Domain.SeedWork;

namespace StudentManaging.Infrastructure.Repositories.EntityFrameworkRepositories.Student
{
	public interface IStudentEFRepository : IRepository<Domain.AggregatesModel.Student.Student>
	{
		Domain.AggregatesModel.Student.Student Add(Domain.AggregatesModel.Student.Student student);
		void Update(Domain.AggregatesModel.Student.Student student);

	}
}
