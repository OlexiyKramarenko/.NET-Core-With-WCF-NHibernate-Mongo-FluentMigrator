using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MShop.DataLayer.EF;
using MShop.Presentation.MPA.Admin.Infrastructure;
using MShop.Presentation.MPA.Public.Infrastructure;

namespace MShop.Presentation.MPA.Auth
{
	public class Startup
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

			var publicStartup = new PublicSiteBaseStartup();
			var adminStartup = new AdminSiteBaseStartup();
			adminStartup.SetAdminSiteServices(services); 
			adminStartup.SetBasicServices(services);
			publicStartup.SetPublicSiteServices(services);


			//services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			//services.AddDistributedMemoryCache();
			//services.AddSession();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseSession();
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
					template: "{controller=Users}/{action=Login}/{id?}");
			});
		}
	}
}
