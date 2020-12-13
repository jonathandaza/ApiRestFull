using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using app;
using Console.Controllers.Validators;
using Console.Filters;
using Console.Models.Validators;
using FluentValidation;
using FluentValidation.WebApi;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using webapi.Controllers.Validators;
using webapi.Models;

namespace webapi
{
	public class Startup
	{
		private UnityContainer _container;

		public void Configuration(IAppBuilder appBuilder)
		{
			var config = new HttpConfiguration();
			_container = new UnityContainer();

			UnityResolver();

			var json = config.Formatters.JsonFormatter;
			var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();

			jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			json.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;

			SettingConfig(config);

			appBuilder.UseWebApi(config);
		}

		private void SettingConfig(HttpConfiguration config)
		{
			config.DependencyResolver = new UnityResolver(_container);
			//config.Services.Replace(typeof(IExceptionHandler), new ApiExceptionHandler());
			config.Filters.Add(new RestfulModelStateFilterAttribute());
			FluentValidationModelValidatorProvider.Configure(config, p=> p.ValidatorFactory = new UnityValidatorFactory(_container));


			config.MapHttpAttributeRoutes();
		}

		private void UnityResolver()
		{
			ConfigureApplicationServices();
			ConfigureValidators();
		}

		private void ConfigureApplicationServices()
		{
			_container.RegisterType<IApp, App>();
		}

		private void ConfigureValidators()
		{
			_container.RegisterType<IValidator<IEnumerable<Employee>>, EmployeeListValidator>();
			_container.RegisterType(typeof(IValidator<>), typeof(EmployeeValidator));
			_container.RegisterType<IValidator<Employee>, EmployeeValidator>();
		}
		
	}
}