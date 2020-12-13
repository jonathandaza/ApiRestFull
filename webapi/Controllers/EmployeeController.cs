using System.Web.Http;
using webapi.Models;

namespace webapi.Controllers
{
		[RoutePrefix("api/v1")]
    public class EmployeeController : ApiController
    {
			[HttpPost]
			[Route("employee")]
			public IHttpActionResult Post([FromBody] EmployeeModel employeeModel)
			{
				return null;
			}

			[HttpPut]
			[Route("employee")]
			public IHttpActionResult Put([FromBody] EmployeeModel employeeModel)
			{
				return null;
			}

    }
}
