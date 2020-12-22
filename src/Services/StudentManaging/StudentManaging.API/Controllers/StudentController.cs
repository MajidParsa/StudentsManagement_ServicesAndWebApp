using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using StudentManaging.API.Infrastructure.DTOs;
using StudentManaging.Application.Commands.Student;
using StudentManaging.Application.Queries.Student;
using StudentManaging.Infrastructure.Repositories.DTOs.Student;

namespace StudentManaging.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class StudentController : ControllerBase
	{
		private readonly IMediator _mediator;

		public StudentController(IMediator iMediator) => 
			_mediator = iMediator ?? throw new ArgumentNullException(nameof(iMediator));

		[Route("getStudentsAsync")]
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<StudentResultDto>> GetStudentsAsync(int id)
		{
			var studentResultDto = await _mediator.Send(new GetStudentQuery() { Id = id });
			if (studentResultDto is null)
			{
				return NotFound(id > 0 
					? new {Message = $"دانشجویی با شناسه  {id} پیدا نشد."} 
					: new { Message = $"هیچ اطلاعاتی جهت نمایش یافت نشد" });
			}

			return Ok(studentResultDto);
		}

		[Route("defineStudentsAsync")]
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> DefineStudentsAsync([FromBody] DefineRequestStudentDto defineRequestStudentDto)
		{
			await _mediator.Send(new AddStudentCommand()
			{
				FullName = defineRequestStudentDto.FullName,
				NationalCode = defineRequestStudentDto.NationalCode,
				StudentNumber = defineRequestStudentDto.StudentNumber
			});

			return Ok();
		}

	}
}
