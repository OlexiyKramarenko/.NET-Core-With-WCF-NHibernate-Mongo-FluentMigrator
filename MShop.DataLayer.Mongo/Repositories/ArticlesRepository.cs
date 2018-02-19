using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MShop.DataLayer.Mongo.Entities.Articles;
using MShop.DataLayer.Mongo.Providers.Articles;
using MShop.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MShop.DataLayer.Mongo.Repositories
{
	public class ArticlesRepository : BaseRepository, IArticlesRepository<Article, Category, Comment, ArticleProvider, CommentProvider, String>
	{
		private IMongoCollection<Article> Articles
		{
			get
			{
				return this.GetCollection<Article>(nameof(Article));
			}
		}
		private IMongoCollection<Category> Categories
		{
			get
			{
				return this.GetCollection<Category>(nameof(Category));
			}
		}
		private IMongoCollection<Comment> Comments
		{
			get
			{
				return this.GetCollection<Comment>(nameof(Comment));
			}
		}

		public ArticlesRepository(IMongoClient client, string databaseName)
			: base(client, databaseName) { }

		#region Category

		public void UpdateCategory(Category category)
		{
			var filter = Builders<Category>
				.Filter
				.Eq(c => c.Id, category.Id);

			var update = Builders<Category>
				.Update
				.Set(x => x.Title, category.Title)
				.Set(x => x.Description, category.Description)
			 	.Set(x => x.ImageUrl, category.ImageUrl)
				.Set(x => x.Importance, category.Importance);

			this.Categories.UpdateOneAsync(filter, update);
		}

		public void DeleteCategory(String categoryId)
		{
			this.Categories
				.DeleteOneAsync(a => a.Id.Equals(categoryId));
		}

		public IList<Category> GetCategories()
		{
			List<Category> categories = this.Categories
											.Find(new BsonDocument())
											.ToListAsync()
											.Result;
			return categories;
		}

		public Category GetCategoryById(String categoryId)
		{
			Category category = this.Categories
									.Find(x => x.Id.Equals(categoryId))
									.FirstOrDefaultAsync()
									.Result;
			return category;
		}

		public void InsertCategory(Category category)
		{
			Categories.InsertOneAsync(category);
		}
		#endregion



		#region Articles

		public void ApproveArticle(String articleId)
		{
			var filter = Builders<Article>
				.Filter
				.Eq(a => a.Id, articleId);

			var update = Builders<Article>
				.Update
				.Set(nameof(Article.Approved), true);

			this.Articles
				.UpdateOneAsync(filter, update);
		}

		public void DeleteArticle(String articleId)
		{
			this.Articles
				.DeleteOneAsync(a => a.Id.Equals(articleId));
		}

		public string GetArticleBody(String articleId)
		{
			string body = this.Articles
							  .Find(x => x.Id.Equals(articleId))
							  .FirstOrDefaultAsync()
							  .Result
							  .Body;
			return body;
		}

		public ArticleProvider GetArticleById(String articleId)
		{
			ArticleProvider articleProvider =
				(from article in this.Articles
									 .Find(new BsonDocument())
									 .ToListAsync()
									 .Result
									 .Where(a => a.Id.Equals(articleId))
				 join category in this.Categories
									  .Find(new BsonDocument())
									  .ToListAsync()
									  .Result
				 on article.CategoryId equals category.Id
				 select new ArticleProvider
				 {
					 Id = article.Id,
					 AddedDate = article.AddedDate,
					 AddedBy = article.AddedBy,
					 CategoryId = article.CategoryId,
					 Title = article.Title,
					 Abstract = article.Abstract,
					 Body = article.Body,
					 Country = article.Country,
					 State = article.State,
					 City = article.City,
					 ReleaseDate = article.ReleaseDate,
					 ExpireDate = article.ExpireDate,
					 Approved = article.Approved,
					 Listed = article.Listed,
					 CommentsEnabled = article.CommentsEnabled,
					 OnlyForMembers = article.OnlyForMembers,
					 ViewCount = article.ViewCount,
					 Votes = article.Votes,
					 TotalRating = article.TotalRating,
					 CategoryTitle = category.Title
				 }).SingleOrDefault();

			return articleProvider;
		}

		public int GetArticleCount()
		{
			return (int)Articles.Count(new BsonDocument());
		}

		public int GetArticleCount(String categoryId)
		{
			var filter = Builders<Article>
				   .Filter
				   .Eq(c => c.CategoryId, categoryId);

			int count = (int)this.Articles
								 .Count(filter);
			return count;
		}

		public IList<ArticleProvider> GetArticles(int pageIndex, int pageSize)
		{
			List<ArticleProvider> articles = (from article in this.Articles.Find(new BsonDocument()).ToListAsync().Result
											  join category in this.Categories.Find(new BsonDocument()).ToListAsync().Result
											  on article.CategoryId equals category.Id
											  select new ArticleProvider
											  {
												  Id = article.Id,
												  AddedDate = article.AddedDate,
												  AddedBy = article.AddedBy,
												  CategoryId = article.CategoryId,
												  Title = article.Title,
												  Abstract = article.Abstract,
												  Body = article.Body,
												  Country = article.Country,
												  State = article.State,
												  City = article.City,
												  ReleaseDate = article.ReleaseDate,
												  ExpireDate = article.ExpireDate,
												  Approved = article.Approved,
												  Listed = article.Listed,
												  CommentsEnabled = article.CommentsEnabled,
												  OnlyForMembers = article.OnlyForMembers,
												  ViewCount = article.ViewCount,
												  Votes = article.Votes,
												  TotalRating = article.TotalRating,
												  CategoryTitle = category.Title
											  })
										 .Skip((pageIndex - 1) * pageSize)
										 .Take(pageSize)
										 .ToList();
			return articles;
		}

		public IList<ArticleProvider> GetArticles(String categoryId, int pageIndex, int pageSize)
		{
			var articleFilter = Builders<Article>
				   .Filter
				   .Eq(c => c.CategoryId, categoryId);

			List<Article> articles = this.Articles
										 .Find(articleFilter)
										 .Skip((pageIndex - 1) * pageSize)
										 .Limit(pageSize)
										 .ToListAsync()
										 .Result;

			Category category = this.GetCategoryById(categoryId);

			IList<ArticleProvider> articleProviders = articles.Select(article => new ArticleProvider
			{
				Id = article.Id,
				AddedDate = article.AddedDate,
				AddedBy = article.AddedBy,
				CategoryId = article.CategoryId,
				Title = article.Title,
				Abstract = article.Abstract,
				Body = article.Body,
				Country = article.Country,
				State = article.State,
				City = article.City,
				ReleaseDate = article.ReleaseDate,
				ExpireDate = article.ExpireDate,
				Approved = article.Approved,
				Listed = article.Listed,
				CommentsEnabled = article.CommentsEnabled,
				OnlyForMembers = article.OnlyForMembers,
				ViewCount = article.ViewCount,
				Votes = article.Votes,
				TotalRating = article.TotalRating,
				CategoryTitle = category.Title
			}).ToList();

			return articleProviders;
		}

		public int GetPublishedArticleCount(DateTime currentDate)
		{
			var filter = this.GetPublishedArticleFilter<Article>(currentDate);
			return (int)Articles.Count(filter);
		}

		public int GetPublishedArticleCount(String categoryId, DateTime currentDate)
		{
			var articleFilter = Builders<Article>.Filter.Eq(c => c.CategoryId, categoryId);
			var filter = this.GetPublishedArticleFilter<Article>(currentDate) & articleFilter;

			return (int)Articles.Count(filter);
		}

		public IList<ArticleProvider> GetPublishedArticles(
			DateTime currentDate,
			int pageIndex,
			int pageSize)
		{
			var filter = this.GetPublishedArticleFilter<Article>(currentDate);

			List<ArticleProvider> articles = (from article in Articles.Find(filter).ToListAsync().Result
											  join category in Categories.Find(new BsonDocument()).ToListAsync().Result
											  on article.CategoryId equals category.Id
											  select new ArticleProvider
											  {
												  Id = article.Id,
												  AddedDate = article.AddedDate,
												  AddedBy = article.AddedBy,
												  CategoryId = article.CategoryId,
												  Title = article.Title,
												  Abstract = article.Abstract,
												  Body = article.Body,
												  Country = article.Country,
												  State = article.State,
												  City = article.City,
												  ReleaseDate = article.ReleaseDate,
												  ExpireDate = article.ExpireDate,
												  Approved = article.Approved,
												  Listed = article.Listed,
												  CommentsEnabled = article.CommentsEnabled,
												  OnlyForMembers = article.OnlyForMembers,
												  ViewCount = article.ViewCount,
												  Votes = article.Votes,
												  TotalRating = article.TotalRating,
												  CategoryTitle = category.Title
											  }).Skip((pageIndex - 1) * pageSize)
										 .Take(pageSize)
										 .ToList();
			return articles;
		}

		public IList<ArticleProvider> GetPublishedArticles(
			String categoryId,
			DateTime currentDate,
			int pageIndex,
			int pageSize)
		{
			throw new NotImplementedException();
		}

		public void IncrementArticleViewCount(String articleId)
		{
			var filter = Builders<Article>.Filter.Eq(a => a.Id, articleId);
			var update = new BsonDocument("$inc", new BsonDocument(nameof(Article.ViewCount), 1));

			this.Articles.UpdateOneAsync(filter, update);
		}

		public void InsertArticle(Article article)
		{
			Articles.InsertOneAsync(article);
		}

		public void RateArticle(String articleId, int rating)
		{
			var filter = Builders<BsonDocument>
				.Filter
				.Eq("_id", articleId);

			var update = Builders<BsonDocument>
				.Update
				.Set("$inc", new BsonDocument(nameof(Article.Votes), 1))
				.Set("$inc", new BsonDocument(nameof(Article.TotalRating), rating));

			this.GetBsonCollection<Article>()
				.UpdateOneAsync(filter, update);
		}

		public void UpdateArticle(Article article)
		{
			var filter = Builders<Article>
				.Filter
				.Eq(c => c.Id, article.Id);

			var update = Builders<Article>
				.Update
				.Set(x => x.CategoryId, article.CategoryId)
				.Set(x => x.Title, article.Title)
				.Set(x => x.Abstract, article.Abstract)
				.Set(x => x.Body, article.Body)
				.Set(x => x.Country, article.Country)
				.Set(x => x.City, article.City)
				.Set(x => x.ReleaseDate, article.ReleaseDate)
				.Set(x => x.ExpireDate, article.ExpireDate)
				.Set(x => x.Approved, article.Approved)
				.Set(x => x.Listed, article.Listed)
				.Set(x => x.CommentsEnabled, article.CommentsEnabled)
				.Set(x => x.OnlyForMembers, article.OnlyForMembers);

			this.Articles.UpdateOneAsync(filter, update);
		}
		#endregion


		#region Comment

		public void InsertComment(Comment comment)
		{
			Comments.InsertOneAsync(comment);
		}

		public void UpdateComment(Comment comment)
		{
			var filter = Builders<Comment>
				.Filter
				.Eq(c => c.Id, comment.Id);

			var update = Builders<Comment>
				.Update
				.Set(x => x.Body, comment.Body);

			this.Comments.UpdateOneAsync(filter, update);
		}

		public void DeleteComment(String commentId)
		{
			this.Comments.DeleteOneAsync(a => a.Id.Equals(commentId));
		}

		public CommentProvider GetCommentById(String commentId)
		{
			var filter = Builders<Comment>
				   .Filter
				   .Eq(c => c.Id, commentId);

			Comment comment = Comments.Find(filter).FirstOrDefault();
			if (comment != null)
			{
				var articleFilter = Builders<Article>
				   .Filter
				   .Eq(c => c.Id, comment.ArticleId);

				Article article = Articles.Find(articleFilter).SingleOrDefault();
				if (article != null)
				{
					var provider = new CommentProvider
					{
						Id = comment.Id,
						AddedDate = comment.AddedDate,
						AddedBy = comment.AddedBy,
						AddedByEmail = comment.AddedByEmail,
						AddedByIp = comment.AddedByIp,
						ArticleId = comment.ArticleId,
						Body = comment.Body,
						ArticleTitle = article.Title
					};
					return provider;
				}
			}
			return null;
		}

		public int GetCommentCount()
		{
			return (int)Comments.Count(new BsonDocument());
		}

		public int GetCommentCount(String articleId)
		{
			var filter = Builders<Comment>
				   .Filter
				   .Eq(c => c.ArticleId, articleId);

			int count = (int)this.Comments
								 .Count(filter);
			return count;
		}

		public IList<CommentProvider> GetComments(int pageIndex, int pageSize)
		{
			List<CommentProvider> articles = (from comment in this.Comments.Find(new BsonDocument()).ToListAsync().Result
											  join article in this.Articles.Find(new BsonDocument()).ToListAsync().Result
											  on comment.ArticleId equals article.Id
											  select new CommentProvider
											  {
												  Id = comment.Id,
												  AddedDate = comment.AddedDate,
												  AddedBy = comment.AddedBy,
												  AddedByEmail = comment.AddedByEmail,
												  AddedByIp = comment.AddedByIp,
												  ArticleId = comment.ArticleId,
												  Body = comment.Body,
												  ArticleTitle = article.Title
											  })
										 .Skip((pageIndex - 1) * pageSize)
										 .Take(pageSize)
										 .ToList();
			return articles;
		}

		public IList<CommentProvider> GetComments(String articleId, int pageIndex, int pageSize)
		{
			var commentFilter = Builders<Comment>
				   .Filter
				   .Eq(c => c.ArticleId, articleId);

			List<Comment> articles = this.Comments
										 .Find(commentFilter)
										 .Skip((pageIndex - 1) * pageSize)
										 .Limit(pageSize)
										 .ToListAsync()
										 .Result;

			Article article = this.GetArticleById(articleId);

			IList<CommentProvider> commentProviders = articles.Select(comment => new CommentProvider
			{
				Id = comment.Id,
				AddedDate = comment.AddedDate,
				AddedBy = comment.AddedBy,
				AddedByEmail = comment.AddedByEmail,
				AddedByIp = comment.AddedByIp,
				ArticleId = comment.ArticleId,
				Body = comment.Body,
				ArticleTitle = article.Title
			}).ToList();

			return commentProviders;
		}

		#endregion


		#region Private Methods

		private FilterDefinition<T> GetPublishedArticleFilter<T>(DateTime currentDate) where T : Article
		{
			var approved = Builders<T>.Filter.Eq(a => a.Approved, true);
			var listed = Builders<T>.Filter.Eq(a => a.Listed, true);
			var expireDate = Builders<T>.Filter.Lte(a => a.ReleaseDate, currentDate);
			var releaseDate = Builders<T>.Filter.Gt(a => a.ExpireDate, currentDate);
			FilterDefinition<T> filter = approved & listed & expireDate & releaseDate;
			return filter;
		}

		#endregion
	}
}
