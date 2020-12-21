using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StudentManaging.Application.Exceptions;
using StudentManaging.Infrastructure.Repositories.DapperRepositories.Student;
using StudentManaging.Infrastructure.Repositories.DTOs.Student;

namespace StudentManaging.Application.Queries.Student
{
	public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, IEnumerable<StudentResultDto>>
	{
		private readonly IStudentDapperRepository _studentDapperRepository;

		public GetStudentQueryHandler(IStudentDapperRepository studentDapperRepository)
		{
			_studentDapperRepository = 
				studentDapperRepository?? throw new StudentManagingApplicationException(nameof(studentDapperRepository));
		}

		public async Task<IEnumerable<StudentResultDto>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
		{
			return await _studentDapperRepository.GetStudentsAsync(request.Id);
		}
	}
}
