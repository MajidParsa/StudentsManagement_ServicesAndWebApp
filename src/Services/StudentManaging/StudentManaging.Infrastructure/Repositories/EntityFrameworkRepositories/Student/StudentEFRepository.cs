using System;
using StudentManaging.Domain.SeedWork;

namespace StudentManaging.Infrastructure.Repositories.EntityFrameworkRepositories.Student
{
	public class StudentEFRepository : IStudentEFRepository
	{
		public IUnitOfWork UnitOfWork { get; }
		public Domain.AggregatesModel.Student.Student Add(Domain.AggregatesModel.Student.Student student)
		{
			throw new NotImplementedException();
		}

		public void Update(Domain.AggregatesModel.Student.Student student)
		{
			throw new NotImplementedException();
		}
	}
}
