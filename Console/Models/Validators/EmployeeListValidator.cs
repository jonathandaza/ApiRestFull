using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using webapi.Controllers.Validators;
using webapi.Models;

namespace Console.Models.Validators
{
	public class EmployeeListValidator : AbstractValidator<IEnumerable<Employee>>
	{
		public override ValidationResult Validate(IEnumerable<Employee> instance)
		{
			var failures = new List<ValidationFailure>();

			if (instance == null || !instance.Any())
			{
				failures.Add(new ValidationFailure("Employee",
						"invalido en datos."));
			}
			else
			{
				foreach (var employee in instance)
				{
					failures.AddRange(new EmployeeValidator().Validate(employee).Errors);
				}
			}

			return new ValidationResult(failures);


			//return base.Validate(instance);
		}
	}
}
