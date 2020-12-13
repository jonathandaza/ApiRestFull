using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Console.Models.Validators
{
	public static class FluentValidationExtensions
	{
		/// <summary>
		/// Converts the Fluent Validation result to the type the both mvc and ef expect
		/// </summary>
		/// <param name="validationResult">The validation result.</param>
		/// <returns></returns>
		public static IEnumerable<ValidationResult> ToValidationResult(
				this FluentValidation.Results.ValidationResult validationResult)
		{
			var results = validationResult.Errors.Select(item => new ValidationResult(new List<ValidationFailure> { item }));
			return results;
		}
	}
}
