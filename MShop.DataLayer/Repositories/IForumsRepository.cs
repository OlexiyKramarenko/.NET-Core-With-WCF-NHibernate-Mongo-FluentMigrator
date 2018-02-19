using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MShop.DataLayer.Entities.Forums;
using MShop.DataLayer.Providers.Forum;

namespace MShop.DataLayer.Repositories
{
	public interface IForumsRepository<Forum, Post, PostProvider, IdType> 
		where Forum : IForum
		where Post : IPost
		where PostProvider : IPostProvider
	{
		// methods that work with forums
		List<Forum> GetForums();
		Forum GetForumById(IdType forumId);
		void DeleteForum(IdType forumId);
		void UpdateForum(Forum forum);
		void InsertForum(Forum forum);

		// methods that work with posts
		List<PostProvider> GetThreads(IdType forumId, Expression<Func<PostProvider, dynamic>> sortExpression, int pageIndex, int pageSize);
		int GetThreadCount(IdType forumId);
		int GetThreadCount();
		List<PostProvider> GetThreadById(IdType threadPostId);
		int GetPostCountByThread(IdType threadPostId);
		List<PostProvider> GetUnapprovedPosts();
		PostProvider GetPostById(IdType postId);
		void DeletePost(IdType postId);
		void UpdatePost(Post post);
		void InsertPost(Post post);
		void ApprovePost(IdType postId);
		void CloseThread(IdType threadPostId);
		void MoveThread(IdType threadPostId, IdType forumId);
		void IncrementPostViewCount(IdType postId);
		string GetPostBody(IdType postId);
	}
}
