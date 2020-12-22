using System;
using System.Threading.Tasks;
using StudentManaging.Domain.SeedWork;
using StudentManaging.Infrastructure.Exceptions;

namespace StudentManaging.Infrastructure.Repositories.EntityFrameworkRepositories.Student
{
	public class StudentEFRepository : IStudentEFRepository
	{
		private readonly StudentContext _context;

		public IUnitOfWork UnitOfWork => _context;

		public StudentEFRepository(StudentContext context)
		{
			_context = context ?? throw new StudentManagingInfrastructureException(nameof(context));
		}

		public async Task<Domain.AggregatesModel.Student.Student> Add(Domain.AggregatesModel.Student.Student student)
		{
			return _context.Students.Add(student).Entity;
		}

		public async Task<bool> Update(Domain.AggregatesModel.Student.Student student)
		{
			throw new NotImplementedException();
		}
	}
}
