using FluentValidation.Attributes;
using webapi.Controllers.Validators;

namespace webapi.Models
{
	public class EmployeeModel
	{
		public string Name { get; set; }
		public double Salary { get; set; }
		public int Age { get; set; }
	}
}