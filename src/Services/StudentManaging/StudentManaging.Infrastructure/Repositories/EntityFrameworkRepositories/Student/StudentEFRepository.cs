using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManaging.Infrastructure.Repositories.DTOs.Student;

namespace StudentManaging.Infrastructure.Repositories.EntityFrameworkRepositories.Student
{
	public class StudentEFRepository : IStudentEFRepository
	{
		public Task<IEnumerable<StudentResultDto>> GetStudents()
		{
			throw new NotImplementedException();
		}
	}
}
