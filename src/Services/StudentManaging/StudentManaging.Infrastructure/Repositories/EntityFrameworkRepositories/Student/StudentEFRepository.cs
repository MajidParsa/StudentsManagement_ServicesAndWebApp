using System;
using System.Threading.Tasks;
using StudentManaging.Domain.SeedWork;

namespace StudentManaging.Infrastructure.Repositories.EntityFrameworkRepositories.Student
{
	public class StudentEFRepository : IStudentEFRepository
	{
		public IUnitOfWork UnitOfWork { get; }
		public async Task<bool> Add(Domain.AggregatesModel.Student.Student student)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> Update(Domain.AggregatesModel.Student.Student student)
		{
			throw new NotImplementedException();
		}
	}
}
