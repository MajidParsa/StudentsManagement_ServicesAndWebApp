using MediatR;

namespace StudentManaging.Application.Queries.Student
{
	public class GetStudentQuery : IRequest<bool>
	{
		public int Id { get; set; }
	}
}
