using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Console.Filters
{
	public class RestfulModelStateFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			if (!actionContext.ModelState.IsValid)
			{
				actionContext.Response = actionContext.Request.CreateResponse(
						HttpStatusCode.BadRequest, new ApiResourceValidationErrorWrapper(actionContext.ModelState));
			}
		}
	}
}
