using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace StudentManaging.Application.Commands.Student
{
	public class AddStudentCommand : IRequest<bool>
	{
		public int Id { get; private set; }
		public string FullName { get; private set; }
		public string NationalCode { get; private set; }
		public string StudentNumber { get; private set; }
	}
}
