using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MShop.DataLayer.Repositories;
using MShop.DataLayer.EF.Entities.Articles;
using MShop.DataLayer.EF.Providers.Articles;
using Microsoft.EntityFrameworkCore;

namespace MShop.DataLayer.EF.Repositories
{
	public class ArticlesRepository : IArticlesRepository<Article, Category, Comment, ArticleProvider, CommentProvider, Guid>
	{
		private readonly EfUnitOfWork _unitOfWork;

		public ArticlesRepository(EfUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		#region Public Methods
		public void ApproveArticle(Guid articleId)
		{
			Article article = this.GetArticleById(articleId);
			if (article != null)
				article.Approved = true;
		}

		public void DeleteArticle(Guid articleId)
		{
			Article article = _unitOfWork.Context.Articles.Find(articleId);
			if (article != null)
				_unitOfWork.Context.Articles.Remove(article);
		}

		public void DeleteCategory(Guid categoryId)
		{
			Category category = this.GetCategoryById(categoryId);
			if (category != null)
				_unitOfWork.Context.Categories.Remove(category);
		}

		public void DeleteComment(Guid commentId)
		{
			Comment comment = this._unitOfWork.Context.Comments.Find(commentId);
			if (comment != null)
				_unitOfWork.Context.Comments.Remove(comment);
		}

		public string GetArticleBody(Guid articleId)
		{
			Article article = this.GetArticleById(articleId);
			if (article != null)
				return article.Body;

			return null;
		}

		public ArticleProvider GetArticleById(Guid articleId)
		{
			ArticleProvider articleProvider = this.GetArticlesQuery()
												  .AsNoTracking()
												  .SingleOrDefault(a => a.Id == articleId);
			return articleProvider;
		}

		public int GetArticleCount()
		{
			int count = _unitOfWork.Context.Articles.AsNoTracking().Count();
			return count;
		}

		public int GetArticleCount(Guid categoryId)
		{
			int count = _unitOfWork.Context
								   .Articles
								   .AsNoTracking()
								   .Count(a => a.CategoryId == categoryId);
			return count;
		}

		public IList<ArticleProvider> GetArticles(int pageIndex, int pageSize)
		{
			IList<ArticleProvider> articleProviders = this.GetArticlesQuery(pageIndex, pageSize)
														 .AsNoTracking()
														 .ToList();
			return articleProviders;
		}

		public IList<ArticleProvider> GetArticles(Guid categoryId, int pageIndex, int pageSize)
		{
			IList<ArticleProvider> articleProviders = this.GetArticlesQuery(pageIndex, pageSize)
														 .Where(obj => obj.CategoryId == categoryId)
														 .AsNoTracking()
														 .ToList();
			return articleProviders;
		}

		public IList<Category> GetCategories()
		{
			IList<Category> categories = _unitOfWork.Context
												   .Categories
												   .OrderByDescending(a => a.Importance)
												   .ThenBy(a => a.Title)
												   .AsNoTracking()
												   .ToList();
			return categories;
		}

		public Category GetCategoryById(Guid categoryId)
		{
			Category category = _unitOfWork.Context
										   .Categories
										   .AsNoTracking()
										   .SingleOrDefault(a => a.Id == categoryId);
			return category;
		}



		public CommentProvider GetCommentById(Guid commentId)
		{
			CommentProvider commentPovider = this.GetCommentsQuery()
												 .AsNoTracking()
												 .SingleOrDefault(com => com.Id == commentId);
			return commentPovider;
		}

		public int GetCommentCount()
		{
			int count = _unitOfWork.Context
								   .Comments
								   .AsNoTracking()
								   .Count();
			return count;
		}

		public int GetCommentCount(Guid articleId)
		{
			int count = _unitOfWork.Context
								   .Comments
								   .AsNoTracking()
								   .Count(a => a.ArticleId == articleId);
			return count;
		}


		public IList<CommentProvider> GetComments(int pageIndex, int pageSize)
		{
			IList<CommentProvider> comments = this.GetCommentsQuery(pageIndex, pageSize)
												 
												 .ToList();
			return comments;
		}

		public IList<CommentProvider> GetComments(Guid articleId, int pageIndex, int pageSize)
		{
			IList<CommentProvider> comments = this.GetCommentsQuery(pageIndex, pageSize)
												 .Where(com => com.ArticleId == articleId)
												 .AsNoTracking()
												 .ToList();
			return comments;
		}

		public int GetPublishedArticleCount(DateTime currentDate)
		{
			var expression = this.GetPublishedArticleFilter<Article>(currentDate);
			int count = _unitOfWork.Context
								   .Articles
								   .AsNoTracking()
								   .Count(expression);
			return count;
		}

		public int GetPublishedArticleCount(Guid categoryId, DateTime currentDate)
		{
			var expression = this.GetPublishedArticleFilter<Article>(currentDate);
			int count = _unitOfWork.Context
								   .Articles
								   .Where(a => a.CategoryId == categoryId)
								   .AsNoTracking()
								   .Count(expression);
			return count;
		}



		public IList<ArticleProvider> GetPublishedArticles(DateTime currentDate, int pageIndex, int pageSize)
		{
			IList<ArticleProvider> articles = this.GetPublishedArticlesQuery(currentDate, pageIndex, pageSize)
												  .AsNoTracking()
												  .ToList();
			return articles;
		}

		public IList<ArticleProvider> GetPublishedArticles(Guid categoryId, DateTime currentDate, int pageIndex, int pageSize)
		{
			IList<ArticleProvider> articles = this.GetPublishedArticlesQuery(currentDate, pageIndex, pageSize)
												 .Where(a => a.CategoryId == categoryId)
												 .AsNoTracking()
												 .ToList();
			return articles;
		}

		public void IncrementArticleViewCount(Guid articleId)
		{
			Article article = this.GetArticleById(articleId);
			if (article != null)
				article.ViewCount++;
		}

		public void InsertArticle(Article article)
		{
			_unitOfWork.Context.Articles.Add(article);
		}

		public void InsertCategory(Category category)
		{
			_unitOfWork.Context.Categories.Add(category);
		}

		public void InsertComment(Comment comment)
		{
			_unitOfWork.Context.Comments.Add(comment);
		}

		public void RateArticle(Guid articleId, int rating)
		{
			Article article = this.GetArticleById(articleId);
			if (article != null)
			{
				article.Votes++;
				article.TotalRating = article.TotalRating + rating;
			}
		}

		public void UpdateArticle(Article article)
		{
			Article ctxArticle = this._unitOfWork.Context.Articles.Find(article.Id);
			if (ctxArticle != null)
			{
				ctxArticle.CategoryId = article.CategoryId;
				ctxArticle.Title = article.Title;
				ctxArticle.Abstract = article.Abstract;
				ctxArticle.Body = article.Body;
				ctxArticle.Country = article.Country;
				ctxArticle.State = article.State;
				ctxArticle.City = article.City;
				ctxArticle.ReleaseDate = article.ReleaseDate;
				ctxArticle.ExpireDate = article.ExpireDate;
				ctxArticle.Approved = article.Approved;
				ctxArticle.Listed = article.Listed;
				ctxArticle.CommentsEnabled = article.CommentsEnabled;
				ctxArticle.OnlyForMembers = article.OnlyForMembers;
			}
		}

		public void UpdateCategory(Category category)
		{
			Category ctxCategory = this.GetCategoryById(category.Id);
			if (ctxCategory != null)
			{
				ctxCategory.Title = category.Title;
				ctxCategory.Importance = category.Importance;
				ctxCategory.Description = category.Description;
				ctxCategory.ImageUrl = category.ImageUrl;
			}
		}

		public void UpdateComment(Comment comment)
		{
			Comment ctxComment = this.GetCommentById(comment.Id);
			if (ctxComment != null)
			{
				ctxComment.Body = comment.Body;
			}
		}
		#endregion

		#region Private Methods

		private IQueryable<ArticleProvider> GetArticlesQuery(int pageIndex, int pageSize)
		{
			int skipCount = (pageIndex - 1) * pageSize;

			IQueryable<ArticleProvider> query = this.GetArticlesQuery()
													.OrderByDescending(a => a.ReleaseDate)
													.Skip(skipCount)
													.Take(pageSize);
			return query;
		}
		private IQueryable<ArticleProvider> GetArticlesQuery()
		{
			IQueryable<ArticleProvider> query = from article in _unitOfWork.Context.Articles
												join category in _unitOfWork.Context.Categories
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
												};
			return query;
		}

		private IQueryable<CommentProvider> GetCommentsQuery()
		{
			IQueryable<CommentProvider> query = from comment in _unitOfWork.Context.Comments
												join article in _unitOfWork.Context.Articles
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
												};

			return query;
		}

		private IQueryable<CommentProvider> GetCommentsQuery(int pageIndex, int pageSize)
		{
			int scipCount = (pageIndex - 1) * pageSize;

			IQueryable<CommentProvider> query = this.GetCommentsQuery()
													.OrderByDescending(o => o.AddedDate)
													.Skip(scipCount)
													.Take(pageSize);
			return query;
		}

		private IQueryable<ArticleProvider> GetPublishedArticlesQuery(DateTime currentDate, int pageIndex, int pageSize)
		{
			var expression = this.GetPublishedArticleFilter<ArticleProvider>(currentDate);

			IQueryable<ArticleProvider> query = this.GetArticlesQuery(pageIndex, pageSize)
													.Where(expression);

			return query;
		}

		private Expression<Func<T, bool>> GetPublishedArticleFilter<T>(DateTime currentDate) where T : Article
		{
			Expression<Func<T, bool>> expression = (article) =>

				article.Approved &&
				article.Listed &&
				article.ReleaseDate <= currentDate &&
				article.ExpireDate > currentDate;

			return expression;
		}


		#endregion
	}
}
