using System.Collections.Generic;
using MediatR;
using StudentManaging.Infrastructure.Repositories.DTOs.Student;

namespace StudentManaging.Application.Queries.Student
{
	public class GetStudentQuery : IRequest<IEnumerable<StudentResultDto>>
	{
		public int Id { get; set; }
	}
}
