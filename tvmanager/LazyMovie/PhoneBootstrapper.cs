using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using LazyMovie.ViewModels;
using Microsoft.Phone.Controls;

namespace LazyMovie
{
	public class Bootstrapper : PhoneBootstrapperBase
	{
		private PhoneContainer _container;

		public Bootstrapper()
		{
			Initialize();
		}

		protected override PhoneApplicationFrame CreatePhoneApplicationFrame()
		{
			return new TransitionFrame();
		}

		protected virtual void RegisterIoCServices()
		{
			_container.PerRequest<MainPageViewModel>();
		}

		protected override void Configure()
		{
			_container = new PhoneContainer();

			_container.RegisterPhoneServices(RootFrame);

			RegisterIoCServices();
		}

		protected override object GetInstance(Type service, string key)
		{
			return _container.GetInstance(service, key);
		}

		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return _container.GetAllInstances(service);
		}

		protected override void BuildUp(object instance)
		{
			_container.BuildUp(instance);
		}
	}
}
