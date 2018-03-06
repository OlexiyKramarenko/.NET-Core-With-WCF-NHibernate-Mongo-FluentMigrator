
using MShop.DataLayer.NHibernate;
using MShop.DataLayer.NHibernate.Repositories;
using System;
using System.Configuration;

namespace WebApplication3
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["nhconstring"].ConnectionString;
			var uow = new NHUnitOfWork(connectionString);
			
			DbInitializer.Initialize(uow);
			

			ArticlesRepository repo = new ArticlesRepository(uow);

			var result = repo.GetArticleCount();//.GetArticlesQuery(1, 10);

			//string connectionString = "mongodb://localhost:27017";
			//MongoClient client = new MongoClient(connectionString);
			//ArticlesRepository repo = new ArticlesRepository(client);
			//repo.InsertCategory(new Category { AddedBy = "Lesha", Description = "ihoho", Title = "title123" });
			//var categories = repo.GetCategories();
		}
	}
}