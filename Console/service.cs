using System;
using Microsoft.Owin.Hosting;
using Topshelf;

namespace webapi
{
	public class MyService
	{
		protected IDisposable WebAppHolder { get; set; }

		public bool Start(HostControl hostControl)
		{
			if (WebAppHolder == null)
				WebAppHolder = WebApp.Start<Startup>("http://*:9090");
			return true;
		}

		public bool Stop(HostControl hostControl)
		{
			if (WebAppHolder != null)
			{
				WebAppHolder.Dispose();
				WebAppHolder = null;
			}
			return true;
		}
	}
}