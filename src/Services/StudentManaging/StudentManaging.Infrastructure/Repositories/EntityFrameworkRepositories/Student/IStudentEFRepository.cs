using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentManaging.Infrastructure.Repositories.DTOs.Student;

namespace StudentManaging.Infrastructure.Repositories.EntityFrameworkRepositories.Student
{
	public interface IStudentEFRepository
	{
		Task<IEnumerable<StudentResultDto>> GetStudents();
	}
}
