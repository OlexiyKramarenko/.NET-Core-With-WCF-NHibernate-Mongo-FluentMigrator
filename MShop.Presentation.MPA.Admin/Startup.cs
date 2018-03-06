using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MShop.DataLayer.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using MShop.Presentation.MPA.Admin.Infrastructure;

namespace MShop.Presentation.MPA.Admin
{
	public class Startup : AdminSiteBaseStartup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DataBaseContext>(options =>
						   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			this.SetBasicServices(services);
			this.SetAdminSiteServices(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action}/{id?}");

				routes.MapRoute(
					name: "default2",
					template: "{controller}/{action}/{pageIndex}/{pageSize}");

				routes.MapRoute(
					name: "default3",
					template: "{controller}/{action}/{includeActive}/{includeArchived}");
			});
		}
	}
}
