using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace StudentManaging.Application.Queries.Student
{
	public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, bool>
	{
		public Task<bool> Handle(GetStudentQuery request, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}
	}
}
