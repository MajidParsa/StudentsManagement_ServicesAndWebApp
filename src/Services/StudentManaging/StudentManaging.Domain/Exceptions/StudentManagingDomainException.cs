using System;

namespace StudentManaging.Domain.Exceptions
{
	public class StudentManagingDomainException : Exception
	{
		public StudentManagingDomainException()
		{
		}

		public StudentManagingDomainException(string message) : base(message)
		{
		}

		public StudentManagingDomainException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
