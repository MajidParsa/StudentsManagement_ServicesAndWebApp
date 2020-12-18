using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManaging.Infrastructure.Exceptions
{
	public class StudentManagingInfrastructureException : Exception
	{
		public StudentManagingInfrastructureException()
		{
		}

		public StudentManagingInfrastructureException(string message) : base(message)
		{
		}

		public StudentManagingInfrastructureException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
