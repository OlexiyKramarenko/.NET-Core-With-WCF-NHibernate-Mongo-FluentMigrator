using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MShop.DataLayer.EF.Entities.Forums;
using MShop.DataLayer.EF.Providers.Forum;
using MShop.DataLayer.Repositories;

namespace MShop.DataLayer.EF.Repositories
{
	public class ForumsRepository : IForumsRepository<Forum, Post, PostProvider, Guid>
	{
		private readonly EfUnitOfWork _unitOfWork;

		public ForumsRepository(EfUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		#region Public Methods
		public List<Forum> GetForums()
		{
			List<Forum> forums = _unitOfWork.Context
											.Forums
											.OrderByDescending(a => a.Importance)
											.ThenBy(a => a.Title)
											.AsNoTracking()
											.ToList();
			return forums;
		}
		public Forum GetForumById(Guid forumId)
		{
			Forum forum = _unitOfWork.Context
									 .Forums
									 .Find(forumId);
			return forum;
		}
		public void DeleteForum(Guid forumId)
		{
			Forum forum = _unitOfWork.Context
									 .Forums
									 .Find(forumId);
			if (forum != null)
				_unitOfWork.Context.Forums.Remove(forum);
		}
		public void UpdateForum(Forum forum)
		{
			Forum ctxForum = _unitOfWork.Context
										.Forums
										.Find(forum.Id);
			if (ctxForum != null)
			{
				ctxForum.Title = forum.Title;
				ctxForum.Moderated = forum.Moderated;
				ctxForum.Importance = forum.Importance;
				ctxForum.Description = forum.Description;
				ctxForum.ImageUrl = forum.ImageUrl;
			}
		}

		public void InsertForum(Forum forum)
		{
			Expression<Func<Forum, bool>> expression = (forumObj) =>
			forumObj.Title.ToLower() == forumObj.Title.ToLower();

			Forum ctxForum = _unitOfWork.Context
										.Forums
										.AsNoTracking()
										.SingleOrDefault(expression);
			if (ctxForum != null)
			{
				throw new Exception();
			}

			_unitOfWork.Context.Forums.Add(forum);
		}

		public List<PostProvider> GetThreads(Guid forumId,
											 Expression<Func<PostProvider, dynamic>> sortExpression,
											 int pageIndex,
											 int pageSize)
		{
			int skipCount = (pageIndex - 1) * pageSize;
			List<PostProvider> posts = this.GetPostProviderQuery()
											  .Where(p => p.ForumId == forumId 
											        && p.ParentPostId == Guid.Empty
													//&&	  p.Approved
													)
											  .OrderBy(sortExpression)
											  .Skip(skipCount)
											  .Take(pageSize)
											  .AsNoTracking()
											  .ToList();
			return posts;
		}
		public int GetThreadCount(Guid forumId)
		{
			Expression<Func<Post, bool>> expression = (post) =>
			post.ParentPostId == null &&
			post.Approved &&
			post.ForumId == forumId;

			int count = _unitOfWork.Context
								   .Posts
								   .AsNoTracking()
								   .Count(expression);
			return count;
		}

		public int GetThreadCount()
		{
			int count = _unitOfWork.Context.Posts.Count();
			return count;
		}


		public List<PostProvider> GetThreadById(Guid threadPostId)
		{
			List<PostProvider> posts = this.GetPostProviderQuery()
										   .Where(p => p.Id == threadPostId)
										   .OrderBy(a => a.AddedDate)
										   .AsNoTracking()
										   .ToList();
			return posts;
		}

		public int GetPostCountByThread(Guid threadPostId)
		{
			Expression<Func<Post, bool>> expression = post =>

			(post.Id == threadPostId || post.ParentPostId == threadPostId) &&
			post.Approved;

			int count = _unitOfWork.Context.Posts.AsNoTracking().Count(expression);
			return count;
		}

		public List<PostProvider> GetUnapprovedPosts()
		{
			List<PostProvider> posts = this.GetPostProviderQuery()
										   .Where(p => !p.Approved)
										   .OrderByDescending(a => a.IsThreadPost)
										   .ThenBy(a => a.AddedDate)
										   .AsNoTracking()
										   .ToList();
			return posts;
		}


		public PostProvider GetPostById(Guid postId)
		{
			PostProvider post = this.GetPostProviderQuery()
									.AsNoTracking()
									.SingleOrDefault(p => p.Id == postId);

			return post;
		}
		public void DeletePost(Guid postId)
		{
			Post post = _unitOfWork.Context
								   .Posts
								   .Find(postId);
			if (post != null)
			{
				_unitOfWork.Context.Posts.Remove(post);
			}
		}
		public void UpdatePost(Post post)
		{
			Post ctxPost = _unitOfWork.Context
									  .Posts
									  .Find(post.Id);
			if (ctxPost != null)
			{
				ctxPost.Title = post.Title;
				ctxPost.Body = post.Body;
			}
		}
		public void InsertPost(Post post)
		{
			_unitOfWork.Context.Posts.Add(post);
			if (post.Approved && post.ParentPostId !=null)
			{
				Post ctxPost = _unitOfWork.Context
										  .Posts
										  .SingleOrDefault(a => a.Id == post.ParentPostId);
				if (ctxPost != null)
				{
					ctxPost.ReplyCount++;
					ctxPost.LastPostDate = post.AddedDate;
					ctxPost.LastPostBy = post.AddedBy;
				}
			}
		}
		public void ApprovePost(Guid postId)
		{
			Post childPost = _unitOfWork.Context
										.Posts
										.Find(postId);
			if (childPost != null)
			{
				childPost.Approved = true;
				if (childPost.ParentPostId != null)
				{
					Post parentPost = _unitOfWork.Context
												 .Posts
												 .Find(childPost.ParentPostId);
					if (parentPost != null)
					{
						parentPost.ReplyCount++;
						parentPost.LastPostBy = childPost.AddedBy;
						parentPost.LastPostDate = childPost.AddedDate;
					}
				}
			}
		}
		public void CloseThread(Guid threadPostId)
		{
			Post post = _unitOfWork.Context
								   .Posts
								   .Find(threadPostId);
			if (post != null)
			{
				post.Closed = true;
			}
		}
		public void MoveThread(Guid threadPostId, Guid forumId)
		{
			Post post = _unitOfWork.Context
								   .Posts
								   .Find(threadPostId);
			if (post != null)
			{
				post.ForumId = forumId;
			}
			Post childPost = _unitOfWork.Context
										.Posts
										.SingleOrDefault(a => a.ParentPostId == threadPostId);
			if (childPost != null)
			{
				childPost.ForumId = forumId;
			}
		}
		public void IncrementPostViewCount(Guid postId)
		{
			Post post = _unitOfWork.Context
								   .Posts
								   .Find(postId);
			if (post != null)
			{
				post.ViewCount++;
			}
		}
		public string GetPostBody(Guid postId)
		{
			string body = _unitOfWork.Context
									 .Posts
									 .Find(postId)?
									 .Body;
			return body;
		}
		#endregion

		#region Private Methods
		private IQueryable<PostProvider> GetPostProviderQuery()
		{
			IQueryable<PostProvider> query = from post in _unitOfWork.Context.Posts
											 join forum in _unitOfWork.Context.Forums
											 on post.ForumId equals forum.Id
											 select new PostProvider
											 {
												 Id = post.Id,
												 AddedBy = post.AddedBy,
												 AddedByIP = post.AddedByIP,
												 AddedDate = post.AddedDate,
												 Approved = post.Approved,
												 Body = post.Body,
												 Closed = post.Closed,
												 ForumId = post.ForumId,
												 ParentPostId = post.ParentPostId,
												 Title = post.Title,
												 ViewCount = post.ViewCount,
												 ReplyCount = post.ReplyCount,
												 LastPostBy = post.LastPostBy,
												 LastPostDate = post.LastPostDate,
												 ForumTitle = forum.Title
											 };
			return query;
		}
		#endregion
	}
}
