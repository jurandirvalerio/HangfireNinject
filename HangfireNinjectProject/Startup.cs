using Hangfire;
using Ninject;
using Owin;

namespace HangfireNinjectProject
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var standardKernel = new StandardKernel();
			GlobalConfiguration.Configuration.UseNinjectActivator(standardKernel);
			GlobalConfiguration.Configuration.UseSqlServerStorage("HangfireDb");

			app.UseHangfireDashboard();
			app.UseHangfireServer();
		}
	}
}