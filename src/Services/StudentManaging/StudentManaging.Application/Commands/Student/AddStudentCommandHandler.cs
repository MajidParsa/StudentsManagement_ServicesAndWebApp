using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StudentManaging.Application.Exceptions;
using StudentManaging.Infrastructure.Repositories.EntityFrameworkRepositories.Student;

namespace StudentManaging.Application.Commands.Student
{
	public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, Domain.AggregatesModel.Student.Student>
	{
		private readonly IStudentEFRepository _studentEfRepository;

		public AddStudentCommandHandler(IStudentEFRepository studentEfRepository)
		{
			_studentEfRepository = studentEfRepository ?? throw new StudentManagingApplicationException(nameof(studentEfRepository));
		}

		public async Task<Domain.AggregatesModel.Student.Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
		{
			var student = Domain.AggregatesModel.Student.Student.CreateStudent(
				request.FullName,
				request.NationalCode,
				request.StudentNumber
			);

			return await _studentEfRepository.Add(student);
		}
	}
}
