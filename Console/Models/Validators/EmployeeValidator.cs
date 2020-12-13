using System.Collections.Generic;
using System.Data;
using FluentValidation;
using webapi.Models;

namespace webapi.Controllers.Validators
{
	public class EmployeeValidator : AbstractValidator<Employee>
	{
		public EmployeeValidator()
		{

			RuleFor(p => p.Age).NotNull().NotEmpty().WithMessage("Age mut not be empty").InclusiveBetween(20, 50);
			RuleFor(p => p.Salary).GreaterThan(0);
			RuleFor(p => p.Name).NotNull();
			RuleFor(p => p.Email).EmailAddress();
		}
	}
}