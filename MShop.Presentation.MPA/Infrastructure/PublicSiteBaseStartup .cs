using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using MShop.DataLayer;
using MShop.DataLayer.EF;
using MShop.DataLayer.EF.Entities.Articles;
using MShop.DataLayer.EF.Entities.Forums;
using MShop.DataLayer.EF.Entities.Newsletters;
using MShop.DataLayer.EF.Entities.Polls;
using MShop.DataLayer.EF.Entities.Store;
using MShop.DataLayer.EF.Providers.Articles;
using MShop.DataLayer.EF.Providers.Forum;
using MShop.DataLayer.EF.Providers.Store;
using MShop.DataLayer.EF.Repositories;
using MShop.DataLayer.Providers.Store;
using MShop.DataLayer.Repositories;
using System;
using System.Reflection;
using AutoMapper;

namespace MShop.Presentation.MPA.Public.Infrastructure
{
	public class PublicSiteBaseStartup
	{
		public void SetPublicSiteServices(IServiceCollection services)
		{
			services.AddMvc().AddSessionStateTempDataProvider();
			services.AddSession();
		}

		public void SetBasicServices(IServiceCollection services)
		{
			services.AddTransient<EfUnitOfWork, EfUnitOfWork>();

			services.AddTransient<IUnitOfWork, EfUnitOfWork>();

			services.AddTransient(
				typeof(IArticlesRepository<Article, Category, Comment, ArticleProvider, CommentProvider, Guid>),
				typeof(ArticlesRepository));

			services.AddTransient(
				typeof(IPollsRepository<Poll, PollOption, Guid>),
				typeof(PollsRepository));

			services.AddTransient(
				typeof(IForumsRepository<Forum, Post, PostProvider, Guid>),
				typeof(ForumsRepository));

			services.AddTransient(
				typeof(INewslettersRepository<Newsletter, Guid>),
				typeof(NewslettersRepository));

			services.AddTransient(
				typeof(IStoreRepository<Department, OrderStatus, ShippingMethod, Product, Order, OrderItem, OrderProvider, ProductProvider, Guid>),
				typeof(StoreRepository));
			
			//Get a reference to the assembly that contains the view components
			Assembly assembly = typeof(ViewComponents.Components.ArticleListingViewComponent).Assembly;

			//Create an EmbeddedFileProvider for that assembly
			IFileProvider embeddedFileProvider = new EmbeddedFileProvider(assembly, "MShop.ViewComponents");

			//Add the file provider to the Razor view engine
			services.Configure<RazorViewEngineOptions>(options =>
			{
				options.FileProviders.Add(embeddedFileProvider);
			});
			services.AddAutoMapper();
		}
	}
}
