using System;
using StudentManaging.Domain.Exceptions;
using StudentManaging.Domain.SeedWork;

namespace StudentManaging.Domain.AggregatesModel.Student
{
	public class Student : Entity, IAggregateRoot
	{
		public int Id { get; private set; }
		public string FullName { get; private set; }
		public string NationalCode { get; private set; }
		public string StudentNumber { get; private set; }

		private Student(int id, string fullName, string nationalCode, string studentNumber)
		{
			if (id < 1)
				throw new StudentManagingDomainException("شناسه دانشجو صحیح نمیباشد",
					new ArgumentOutOfRangeException("شناسه دانشجو کوچکتر از 1 است"));

			if (string.IsNullOrWhiteSpace(NationalCode))
				throw new StudentManagingDomainException("کدملی دانشجو صحیح نمیباشد",
					new ArgumentOutOfRangeException("کدملی دانشجو خالی است"));

			if (string.IsNullOrWhiteSpace(StudentNumber))
				throw new StudentManagingDomainException("شماره دانشجویی صحیح نمیباشد",
					new ArgumentOutOfRangeException("شماره دانشجویی خالی است"));


			this.Id = id;
			this.NationalCode = nationalCode;
			this.FullName = fullName;
			this.StudentNumber = studentNumber;
		}


		public static Student CreateStudent(string fullName, string nationalCode, string studentNumber)
		{
			return new Student(0, fullName, nationalCode, studentNumber);
		}

		public static Student CreateExistingStudent(int id, string fullName, string nationalCode, string studentNumber)
		{
			return new Student(id, fullName, nationalCode, studentNumber);
		}

	}
}
