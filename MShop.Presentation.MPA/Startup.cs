﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MShop.DataLayer;
using MShop.DataLayer.EF;
using MShop.DataLayer.EF.Entities.Articles;
using MShop.DataLayer.EF.Entities.Forums;
using MShop.DataLayer.EF.Entities.Newsletters;
using MShop.DataLayer.EF.Entities.Polls;
using MShop.DataLayer.EF.Entities.Store;
using MShop.DataLayer.EF.Entities.Users;
using MShop.DataLayer.EF.Providers.Articles;
using MShop.DataLayer.EF.Providers.Forum;
using MShop.DataLayer.EF.Providers.Store;
using MShop.DataLayer.EF.Repositories;
using MShop.DataLayer.Providers.Store;
using MShop.DataLayer.Repositories;
using System;

namespace MShop.Presentation.MPA.Public
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
			
			services.AddTransient(
				typeof(IArticlesRepository<Article, Category, Comment, ArticleProvider, CommentProvider, Guid>),
				typeof(ArticlesRepository));

			services.AddTransient(
				typeof(IPollsRepository<Poll, PollOption, Guid>),
				typeof(PollsRepository));

			services.AddTransient<EfUnitOfWork, EfUnitOfWork>();
			services.AddTransient(
				typeof(IForumsRepository<Forum, Post, PostProvider, Guid>),
				typeof(ForumsRepository));

			//services.AddTransient(
			//	typeof(IUsersRepository<ApplicationUser>),
			//	typeof(UsersRepository));

			services.AddTransient(
				typeof(INewslettersRepository<Newsletter, Guid>),
				typeof(NewslettersRepository));

			services.AddTransient(
				typeof(IStoreRepository<Department, OrderStatus, ShippingMethod, Product, Order, OrderItem, OrderProvider, ProductProvider, Guid>),
				typeof(StoreRepository));

			services.AddTransient<IUnitOfWork, EfUnitOfWork>();
			services.AddAutoMapper();
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