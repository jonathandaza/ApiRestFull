using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

namespace webapi
{
	public class Startup
	{
		private UnityContainer _container;

		public void Configuration(IAppBuilder appBuilder)
		{
			var config = new HttpConfiguration();
			_container = new UnityContainer();

			var json = config.Formatters.JsonFormatter;
			var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();

			jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			json.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;


			appBuilder.UseWebApi(config);
		}
	}
}