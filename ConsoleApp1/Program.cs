
using MongoDB.Bson;
using MongoDB.Driver;
using MShop.DataLayer.Mongo.Entities.Articles;
using MShop.DataLayer.Mongo.Repositories;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			MongoClient client = new MongoClient("mongodb://localhost:27017/");
			ArticlesRepository repo = new ArticlesRepository(client, "shop");
			var cat = new Category { Id = ObjectId.GenerateNewId().ToString(), AddedBy = "Lesha", Description = "ihoho", Title = "title123" };
			repo.InsertCategory(cat);
			var article = new Article { Id = ObjectId.GenerateNewId().ToString(), Title = "new article", CategoryId = cat.Id };
			for (int i = 0; i < 10; i++)
			{
				repo.InsertArticle(new Article { Title = "article" + i.ToString(), CategoryId = cat.Id });
			}
			var categories = repo.GetCategories();
			var art = repo.GetArticleById(article.Id);
		}
	}
}
