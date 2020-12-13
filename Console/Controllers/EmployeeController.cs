using System.Collections.Generic;
using System.Web.Http;
using app;
using app.DTO;
using AutoMapper;
using webapi.Models;

namespace webapi.Controllers
{
		[RoutePrefix("api/v1")]
    public class EmployeeController : ApiController
		{
			private readonly IApp _app;

			public EmployeeController(IApp app)
			{
				_app = app;
			}

			[HttpPost]
			[Route("employees")]
			public IHttpActionResult Post([FromBody] IEnumerable<Employee> employee)
			{
				if (ModelState.IsValid)
				{
					Mapper.CreateMap<Employee, EmployeeDTO>();
					var newEmployee = _app.Add(Mapper.Map<EmployeeDTO>(employee));
					
					return Ok(newEmployee);
				}

				return BadRequest();

			}

			[HttpPut]
			[Route("employees")]
			public IHttpActionResult Put([FromBody] Employee employee)
			{
				return null;
			}

    }
}
