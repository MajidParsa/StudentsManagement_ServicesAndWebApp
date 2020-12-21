using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using StudentManaging.Infrastructure.Exceptions;
using StudentManaging.Infrastructure.Repositories.ConnectionProvider;
using StudentManaging.Infrastructure.Repositories.DTOs.Student;

namespace StudentManaging.Infrastructure.Repositories.DapperRepositories.Student
{
	public class StudentDapperRepository: IStudentDapperRepository
	{
		private readonly IQueryDataServer _queryDataServer;

		public StudentDapperRepository(IQueryDataServer queryDataServer)
		{
			_queryDataServer = 
				queryDataServer ?? throw new StudentManagingInfrastructureException(nameof(queryDataServer));
		}

		public async Task<IEnumerable<StudentResultDto>> GetStudentsAsync(int? studentId)
		{
			using IDbConnection connection = _queryDataServer.GetConnectionString();
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@StudentId", studentId);
			IEnumerable<StudentResultDto> students = 
				await connection.QueryAsync<StudentResultDto>("GetStudents", parameters, commandType: CommandType.StoredProcedure);

			return students;
		}
	}
}
