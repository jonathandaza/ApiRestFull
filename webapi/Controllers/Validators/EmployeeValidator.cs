using FluentValidation;
using webapi.Models;

namespace webapi.Controllers.Validators
{
	public class EmployeeValidator : AbstractValidator<EmployeeModel>
	{
		public EmployeeValidator()
		{
			RuleFor(p => p.Age).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty().WithMessage("Age mut not be empty");
			RuleFor(p => p.Salary).Cascade(CascadeMode.StopOnFirstFailure).GreaterThan(0);
			RuleFor(p => p.Name).Cascade(CascadeMode.StopOnFirstFailure).NotNull();
		}
	}
}