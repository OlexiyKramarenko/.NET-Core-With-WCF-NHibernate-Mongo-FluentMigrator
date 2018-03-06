using MShop.DataLayer.Entities.Articles;
using MShop.DataLayer.Providers.Articles;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.Repositories
{
	public interface IArticlesRepository<Article, Category, Comment, ArticleProvider, CommentProvider, IdType>
	where Article : class, IArticle
	where Category : class, ICategory
	where Comment : class, IComment
	where ArticleProvider : class, IArticleProvider
	where CommentProvider : class, ICommentProvider

	{
		IList<Category> GetCategories();
		IList<Category> GetCategories(int pageSize, int pageIndex);
		Category GetCategoryById(IdType categoryId);
		void DeleteCategory(IdType categoryId);
		void UpdateCategory(Category category);
		void InsertCategory(Category category);

		// methods that work with articles
		IList<ArticleProvider> GetArticles(int pageIndex, int pageSize);
		IList<ArticleProvider> GetArticles(IdType categoryId, int pageIndex, int pageSize);
		int GetArticleCount();
		int GetArticleCount(IdType categoryId);
		IList<ArticleProvider> GetPublishedArticles(DateTime currentDate, int pageIndex, int pageSize);
		IList<ArticleProvider> GetPublishedArticles(IdType categoryId, DateTime currentDate, int pageIndex, int pageSize);
		int GetPublishedArticleCount(DateTime currentDate);
		int GetPublishedArticleCount(IdType categoryId, DateTime currentDate);
		ArticleProvider GetArticleById(IdType articleId);
		void DeleteArticle(IdType articleId);
		void UpdateArticle(Article article);
		void InsertArticle(Article article);
		void ApproveArticle(IdType articleId);
		void IncrementArticleViewCount(IdType articleId);
		void RateArticle(IdType articleId, int rating);
		string GetArticleBody(IdType articleId);

		// methods that work with comments
		IList<CommentProvider> GetComments(int pageIndex, int pageSize);
		IList<CommentProvider> GetComments(IdType articleId, int pageIndex, int pageSize);
		int GetCommentCount();
		int GetCommentCount(IdType articleId);
		CommentProvider GetCommentById(IdType commentId);
		void DeleteComment(IdType commentId);
		void UpdateComment(Comment article);
		void InsertComment(Comment comment);
	}
}
