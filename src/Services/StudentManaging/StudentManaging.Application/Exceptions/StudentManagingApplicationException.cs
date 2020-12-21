using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManaging.Application.Exceptions
{
	public class StudentManagingApplicationException : Exception
	{
		public StudentManagingApplicationException()
		{
		}

		public StudentManagingApplicationException(string message) : base(message)
		{
		}

		public StudentManagingApplicationException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
