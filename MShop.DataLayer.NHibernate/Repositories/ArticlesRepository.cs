using MShop.DataLayer.NHibernate.Entities.Articles;
using MShop.DataLayer.NHibernate.Providers.Articles;
using MShop.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MShop.DataLayer.NHibernate.Repositories
{
	public class ArticlesRepository : IArticlesRepository<Article, Category, Comment, ArticleProvider, CommentProvider, Guid>
	{
		private readonly NHUnitOfWork _unitOfWork;

		public ArticlesRepository(NHUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_unitOfWork.BeginTransaction();
		}

		#region Articles

		public void ApproveArticle(Guid articleId)
		{
			Article article = this.GetArticleById(articleId);
			if (article != null)
			{
				article.Approved = true;
			}
			_unitOfWork.Session.Flush();
		}

		public void DeleteArticle(Guid articleId)
		{
			Article article = this.GetArticleById(articleId);
			if (article != null)
			{
				_unitOfWork.Session.Delete(article);
			}
		}

		public string GetArticleBody(Guid articleId)
		{
			Article article = this.GetArticleById(articleId);
			if (article != null)
			{
				return article.Body;
			}
			return null;
		}

		public ArticleProvider GetArticleById(Guid articleId)
		{
			Category tblCategory = null;
			Article tblArticle = null;

			object[] obj =
				_unitOfWork.Session
						   .QueryOver(() => tblArticle)
						   .JoinQueryOver(a => a.Category, () => tblCategory)
						   .SelectList(list => list
								.Select(() => tblArticle.Id)
								.Select(() => tblArticle.AddedDate)
								.Select(() => tblArticle.AddedBy)
								.Select(() => ((Category)tblArticle.Category).Id)
								.Select(() => tblArticle.Title)
								.Select(() => tblArticle.Abstract)
								.Select(() => tblArticle.Body)
								.Select(() => tblArticle.Country)
								.Select(() => tblArticle.State)
								.Select(() => tblArticle.City)
								.Select(() => tblArticle.ReleaseDate)
								.Select(() => tblArticle.ExpireDate)
								.Select(() => tblArticle.Approved)
								.Select(() => tblArticle.Listed)
								.Select(() => tblArticle.CommentsEnabled)
								.Select(() => tblArticle.OnlyForMembers)
								.Select(() => tblArticle.ViewCount)
								.Select(() => tblArticle.Votes)
								.Select(() => tblArticle.TotalRating)
								.Select(() => tblCategory.Title))
								.Where(() => tblArticle.Id == articleId)
							.List<object[]>()
							.SingleOrDefault();

			ArticleProvider article = ConvertToArticleProvider(obj);
			return article;
		}

		public int GetArticleCount()
		{
			int count = _unitOfWork.Session
								   .QueryOver<Article>()
								   .RowCount();
			return count;
		}

		public int GetArticleCount(Guid categoryId)
		{
			int count = _unitOfWork.Session
								   .QueryOver<Article>()
								   .Where(a => ((Category)a.Category).Id == categoryId)
								   .RowCount();
			return count;
		}

		private ArticleProvider ConvertToArticleProvider(object[] obj)
		{
			return new ArticleProvider
			{
				Id = Guid.Parse(Convert.ToString(obj[0])),
				AddedDate = Convert.ToDateTime(obj[1]),
				AddedBy = Convert.ToString(obj[2]),
				//CategoryId = Guid.Parse(obj[3].ToString()),
				Title = Convert.ToString(obj[4]),
				Abstract = Convert.ToString(obj[5]),
				Body = Convert.ToString(obj[6]),
				Country = Convert.ToString(obj[7]),
				State = Convert.ToString(obj[8]),
				City = Convert.ToString(obj[9]),
				ReleaseDate = Convert.ToDateTime(obj[10]),
				ExpireDate = Convert.ToDateTime(obj[11]),
				Approved = Convert.ToBoolean(obj[12]),
				Listed = Convert.ToBoolean(obj[13]),
				CommentsEnabled = Convert.ToBoolean(obj[14]),
				OnlyForMembers = Convert.ToBoolean(obj[15]),
				ViewCount = Convert.ToInt32(obj[16]),
				Votes = Convert.ToInt32(obj[17]),
				TotalRating = Convert.ToInt32(obj[18]),
				CategoryTitle = Convert.ToString(obj[19]),
			};
		}

		public IList<ArticleProvider> GetArticles(int pageIndex, int pageSize)
		{
			int skipCount = (pageIndex - 1) * pageSize;
			Category tblCategory = null;
			Article tblArticle = null;

			List<ArticleProvider> articles =
				_unitOfWork.Session
						   .QueryOver(() => tblArticle)
						   .JoinQueryOver(a => a.Category, () => tblCategory)
						   .OrderBy(() => tblArticle.ReleaseDate).Desc
						   .SelectList(list => list
								.Select(() => tblArticle.Id)
								.Select(() => tblArticle.AddedDate)
								.Select(() => tblArticle.AddedBy)
								.Select(() => ((Category)tblArticle.Category).Id)
								.Select(() => tblArticle.Title)
								.Select(() => tblArticle.Abstract)
								.Select(() => tblArticle.Body)
								.Select(() => tblArticle.Country)
								.Select(() => tblArticle.State)
								.Select(() => tblArticle.City)
								.Select(() => tblArticle.ReleaseDate)
								.Select(() => tblArticle.ExpireDate)
								.Select(() => tblArticle.Approved)
								.Select(() => tblArticle.Listed)
								.Select(() => tblArticle.CommentsEnabled)
								.Select(() => tblArticle.OnlyForMembers)
								.Select(() => tblArticle.ViewCount)
								.Select(() => tblArticle.Votes)
								.Select(() => tblArticle.TotalRating)
								.Select(() => tblCategory.Title))
							.Skip(skipCount)
							.Take(pageSize)
							.List<object[]>()
							.Select(a => this.ConvertToArticleProvider(a))
							.ToList();

			return articles;
		}

		public IList<ArticleProvider> GetArticles(Guid categoryId, int pageIndex, int pageSize)
		{
			int skipCount = (pageIndex - 1) * pageSize;
			Category tblCategory = null;
			Article tblArticle = null;

			List<ArticleProvider> articles =
				_unitOfWork.Session
						   .QueryOver(() => tblArticle)
						   .JoinQueryOver(a => a.Category, () => tblCategory)
						   .Where(() => ((Category)tblArticle.Category).Id == categoryId)
						   .OrderBy(() => tblArticle.ReleaseDate).Desc
						   .SelectList(list => list
								.Select(() => tblArticle.Id)
								.Select(() => tblArticle.AddedDate)
								.Select(() => tblArticle.AddedBy)
								.Select(() => ((Category)tblArticle.Category).Id)
								.Select(() => tblArticle.Title)
								.Select(() => tblArticle.Abstract)
								.Select(() => tblArticle.Body)
								.Select(() => tblArticle.Country)
								.Select(() => tblArticle.State)
								.Select(() => tblArticle.City)
								.Select(() => tblArticle.ReleaseDate)
								.Select(() => tblArticle.ExpireDate)
								.Select(() => tblArticle.Approved)
								.Select(() => tblArticle.Listed)
								.Select(() => tblArticle.CommentsEnabled)
								.Select(() => tblArticle.OnlyForMembers)
								.Select(() => tblArticle.ViewCount)
								.Select(() => tblArticle.Votes)
								.Select(() => tblArticle.TotalRating)
								.Select(() => tblCategory.Title))
							.Skip(skipCount)
							.Take(pageSize)
							.List<object[]>()
							.Select(a => this.ConvertToArticleProvider(a))
							.ToList();

			return articles;
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
		public int GetPublishedArticleCount(DateTime currentDate)
		{
			var expression = this.GetPublishedArticleFilter<Article>(currentDate);
			int count = _unitOfWork.Session
								   .QueryOver<Article>()
								   .Where(expression)
								   .RowCount();
			return count;
		}

		public int GetPublishedArticleCount(Guid categoryId, DateTime currentDate)
		{
			var expression = this.GetPublishedArticleFilter<Article>(currentDate);
			int count = _unitOfWork.Session
								   .QueryOver<Article>()
								   .Where(expression)
								   .Where(a => ((Category)a.Category).Id == categoryId)
								   .RowCount();
			return count;
		}

		public IList<ArticleProvider> GetPublishedArticles(DateTime currentDate, int pageIndex, int pageSize)
		{
			throw new NotImplementedException();
		}

		public IList<ArticleProvider> GetPublishedArticles(Guid categoryId, DateTime currentDate, int pageIndex, int pageSize)
		{
			throw new NotImplementedException();
		}

		public void IncrementArticleViewCount(Guid articleId)
		{
			Article article = this.GetArticleById(articleId);
			if (article != null)
			{
				article.ViewCount++;
			}
			_unitOfWork.Session.Flush();
		}

		public void InsertArticle(Article article)
		{
			_unitOfWork.Session.Save(article);
		}

		public void RateArticle(Guid articleId, int rating)
		{
			Article article = this.GetArticleById(articleId);
			if (article != null)
			{
				article.Votes++;
				article.TotalRating = article.TotalRating + rating;
			}
			_unitOfWork.Session.Flush();
		}

		public void UpdateArticle(Article article)
		{
			_unitOfWork.Session.Update(article);
		}

		#endregion

		#region Categories

		public void DeleteCategory(Guid categoryId)
		{
			Category category = this.GetCategoryById(categoryId);
			if (category != null)
			{
				_unitOfWork.Session.Delete(category);
			}
		}

		public IList<Category> GetCategories()
		{
			IList<Category> categories = _unitOfWork.Session
													.QueryOver<Category>()
													.List<Category>();
			return categories;
		}

		public Category GetCategoryById(Guid categoryId)
		{
			Category category = _unitOfWork.Session
										   .QueryOver<Category>()
										   .Where(c => c.Id == categoryId)
										   .SingleOrDefault();
			return category;
		}

		public void InsertCategory(Category category)
		{
			_unitOfWork.Session.Save(category);
		}

		public void UpdateCategory(Category category)
		{
			_unitOfWork.Session.Update(category);
		}

		#endregion

		#region Comments

		public void DeleteComment(Guid commentId)
		{
			Comment comment = this.GetCommentById(commentId);
			if (comment != null)
			{
				_unitOfWork.Session.Delete(comment);
			}
		}

		public CommentProvider GetCommentById(Guid commentId)
		{
			//Comment comment = _unitOfWork.Session
			//							   .QueryOver<Comment>()
			//							   .Where(c => c.Id == commentId)
			//							   .SingleOrDefault();
			//return comment;
			return null;
		}

		public int GetCommentCount()
		{
			int count = _unitOfWork.Session
								   .QueryOver<Comment>()
								   .RowCount();
			return count;
		}

		public int GetCommentCount(Guid articleId)
		{
			int count = _unitOfWork.Session
								   .QueryOver<Comment>()
								   .Where(c => c.Id == articleId)
								   .RowCount();
			return count;
		}

		public IList<CommentProvider> GetComments(int pageIndex, int pageSize)
		{
			throw new NotImplementedException();
		}

		public IList<CommentProvider> GetComments(Guid articleId, int pageIndex, int pageSize)
		{
			throw new NotImplementedException();
		}

		public void InsertComment(Comment comment)
		{
			_unitOfWork.Session.Save(comment);
		}

		public void UpdateComment(Comment comment)
		{
			_unitOfWork.Session.Update(comment);
		}

		public IList<Category> GetCategories(int pageSize, int pageIndex)
		{
			throw new NotImplementedException();
		}
		#endregion

	}
}
