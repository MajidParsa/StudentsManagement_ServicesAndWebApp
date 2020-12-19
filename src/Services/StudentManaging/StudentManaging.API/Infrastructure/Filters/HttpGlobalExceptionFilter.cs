using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace StudentManaging.API.Infrastructure.Filters
{
	public class HttpGlobalExceptionFilter : IExceptionFilter
	{
		private readonly IHostingEnvironment env;
		private readonly ILogger<HttpGlobalExceptionFilter> logger;

		public HttpGlobalExceptionFilter(IHostingEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
		{
			this.env = env;
			this.logger = logger;
		}

		public void OnException(ExceptionContext context)
		{
			logger.LogError(new EventId(context.Exception.HResult),
				context.Exception,
				context.Exception.Message);

			var problemDetails = new ValidationProblemDetails()
			{
				Title = context.Exception.Message,
				Instance = context.HttpContext.Request.Path,
				Status = StatusCodes.Status400BadRequest,
				Detail = "لطفا به ویژگی خطاها برای توضیحات بیشتر مراجعه نمایید."
			};
			context.Result = new BadRequestObjectResult(problemDetails);

			context.ExceptionHandled = true;
		}
	}
}
