using ShopSnapWebApi.Controllers;
using ShopSnapWebApi.Interfaces;
using ShopSnapWebApi.Repositories;
using ShopSnapWebApi.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ShopSnapWebApi
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();
			
			// register all your components with the container here
			// it is NOT necessary to register your controllers
			
			// e.g. container.RegisterType<ITestService, TestService>();
			container.RegisterType<IReceiptRepository, ReceiptRepository>();
			container.RegisterType<IReceiptItemRepository, ReceiptItemRepository>();
			container.RegisterType<IUserRepository, UserRepository>();
			container.RegisterType<IUserSpendingsRepository, UserSpendingsRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
		}
	}
}