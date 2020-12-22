using MediatR;

namespace StudentManaging.Application.Commands.Student
{
	public class AddStudentCommand : IRequest<Domain.AggregatesModel.Student.Student>
	{
		public string FullName { get; set; }
		public string NationalCode { get; set; }
		public string StudentNumber { get; set; }
	}
}
