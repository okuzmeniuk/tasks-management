using TasksManagement.Core.Exceptions;

namespace TasksManagement.API.Middleware
{
	public class ExceptionHandlingMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
		{
			try
			{
				await next(httpContext);
			}
			catch (NotFoundException ex)
			{
				httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				httpContext.Response.ContentType = "application/json";
				await httpContext.Response.WriteAsync("{" + $"\"error\": \"{ex.Message}\"" + "}");
			}
			catch (Exception ex)
			{
				httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
				httpContext.Response.ContentType = "application/json";
				await httpContext.Response.WriteAsync("{" + $"\"error\": \"{ex.Message}\"" + "}");
			}
		}
	}

	public static class ExceptionHandlingMiddlewareExtensions
	{
		public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<ExceptionHandlingMiddleware>();
		}
	}
}
