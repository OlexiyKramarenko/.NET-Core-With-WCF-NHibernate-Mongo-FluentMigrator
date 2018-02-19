
//using MShop.DataLayer.NHibernate;
//using MShop.DataLayer.NHibernate.Entities.Articles;
//using MShop.DataLayer.NHibernate.Repositories;
using MongoDB.Driver;
using MShop.DataLayer.Mongo.Entities.Articles;
using MShop.DataLayer.Mongo.Repositories;
using System;

namespace WebApplication3
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//var uow = new NHUnitOfWork();
			//ArticlesRepository repo = new ArticlesRepository(uow);
			//uow.BeginTransaction();
			//var result = repo.GetArticlesQuery(1, 10);

			string connectionString = "mongodb://localhost:27017";
			MongoClient client = new MongoClient(connectionString);
			ArticlesRepository repo = new ArticlesRepository(client);
			repo.InsertCategory(new Category { AddedBy = "Lesha", Description = "ihoho", Title = "title123" });
			var categories = repo.GetCategories();
		}
	}
}