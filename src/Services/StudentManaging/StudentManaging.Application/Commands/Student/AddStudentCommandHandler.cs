using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace StudentManaging.Application.Commands.Student
{
	public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, bool>
	{
		public Task<bool> Handle(AddStudentCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
