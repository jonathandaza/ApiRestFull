using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Practices.Unity;

namespace Console.Controllers.Validators
{
	public class UnityValidatorFactory : ValidatorFactoryBase
	{
		private readonly IUnityContainer _container;

		public UnityValidatorFactory(IUnityContainer container)
		{
			_container = container;
		}

		public override IValidator CreateInstance(Type validatorType)
		{

			return _container.Resolve(validatorType) as IValidator;
		}
		
	}
}
