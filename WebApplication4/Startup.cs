using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MShop.DataLayer;
using MShop.DataLayer.EF;
using MShop.DataLayer.EF.Entities.Articles;
using MShop.DataLayer.EF.Providers.Articles;
using MShop.DataLayer.EF.Repositories;
using MShop.DataLayer.Entities.Articles;
using MShop.DataLayer.Entities.Forums;
using MShop.DataLayer.Entities.Newsletters;
using MShop.DataLayer.Entities.Polls;
using MShop.DataLayer.Entities.Store;
using MShop.DataLayer.Entities.Users;
using MShop.DataLayer.Providers.Articles;
using MShop.DataLayer.Providers.Forum;
using MShop.DataLayer.Providers.Store;
using MShop.DataLayer.Repositories;

namespace WebApplication4
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
			services.AddTransient<DataBaseContext, DataBaseContext>();

			services.AddTransient(
				typeof(IArticlesRepository<Article, Category, Comment, ArticleProvider, CommentProvider>),
				typeof(ArticlesRepository));

			services.AddTransient(
				typeof(IPollsRepository<IPoll, IPollOption>),
				typeof(PollsRepository));

			services.AddTransient<EfUnitOfWork, EfUnitOfWork>();
			services.AddTransient(
				typeof(IForumsRepository<IForum, IPost, IPostProvider>),
				typeof(ForumsRepository));

			services.AddTransient(
				typeof(IUsersRepository<IApplicationUser>),
				typeof(UsersRepository));

			services.AddTransient(
				typeof(INewslettersRepository<INewsletter>),
				typeof(NewslettersRepository));

			services.AddTransient(
				typeof(IStoreRepository<IDepartment, IOrderStatus, IShippingMethod, IProduct, IOrder, IOrderItem, IOrderProvider, IProductProvider>),
				typeof(StoreRepository));

			services.AddTransient<IUnitOfWork, EfUnitOfWork>();
			//services.AddAutoMapper();
			services.AddMvc();
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
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
