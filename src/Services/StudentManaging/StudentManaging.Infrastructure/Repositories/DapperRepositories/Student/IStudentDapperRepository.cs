using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManaging.Domain.SeedWork;
using StudentManaging.Infrastructure.Repositories.DTOs.Student;

namespace StudentManaging.Infrastructure.Repositories.DapperRepositories.Student
{
	public interface IStudentDapperRepository //: IRepository<Domain.AggregatesModel.Student.Student>
	{
		Task<IEnumerable<StudentResultDto>> GetStudentsAsync(int? studentId);
	}
}
