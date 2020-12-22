using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace StudentManaging.Application.Commands.Student
{
	public class AddStudentCommand : IRequest<bool>
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string NationalCode { get; set; }
		public string StudentNumber { get; set; }
	}
}
