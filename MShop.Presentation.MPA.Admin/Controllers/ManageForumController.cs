using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer;
using MShop.DataLayer.EF.Entities.Forums;
using MShop.DataLayer.EF.Providers.Forum;
using MShop.Presentation.MPA.Admin.Models.Forums;
using IForumsRepository =
	MShop.DataLayer.Repositories.IForumsRepository<
		MShop.DataLayer.EF.Entities.Forums.Forum,
		MShop.DataLayer.EF.Entities.Forums.Post,
		MShop.DataLayer.EF.Providers.Forum.PostProvider, System.Guid>;

namespace MShop.Presentation.MPA.Admin.Controllers
{
	public class ManageForumController : Controller
	{
		private readonly IForumsRepository _forumsRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ManageForumController(IForumsRepository forumsRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_forumsRepository = forumsRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		#region Forums
		[HttpGet]
		public IActionResult ManageForums()
		{
			try
			{
				List<Forum> forums = _forumsRepository.GetForums();
				var model = _mapper.Map<List<ManageForumItemViewModel>>(forums);
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult DeleteForum(Guid id)
		{
			try
			{
				_forumsRepository.DeleteForum(id);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageForums));
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult AddForum()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddForum(AddForumViewModel model)
		{
			try
			{
				var forum = _mapper.Map<Forum>(model);
				_forumsRepository.InsertForum(forum);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageForums));
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult EditForum(Guid id)
		{
			try
			{
				Forum forum = _forumsRepository.GetForumById(id);
				var model = _mapper.Map<EditForumViewModel>(forum);
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpPut]
		public IActionResult EditForum(EditForumViewModel model)
		{
			try
			{
				var forum = _mapper.Map<Forum>(model);
				_forumsRepository.UpdateForum(forum);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageForums));
			}
			catch
			{
				return View();
			}
		}
		#endregion

		#region Threads

		[HttpGet]
		public IActionResult ManageThreads(Guid id, string orderBy, int pageIndex, int pageSize)
		{
			try
			{
				List<PostProvider> threads = _forumsRepository.GetThreads(id, this.GetSortExpession(orderBy), pageIndex, pageSize);
				var model = _mapper.Map<IEnumerable<ThreadViewModel>>(threads);
				return View(model);
			}
			catch
			{
				return View();
			}
		}


		[HttpGet]
		public IActionResult MoveThread(Guid id)
		{
			try
			{
				PostProvider thread = _forumsRepository.GetPostById(id);
				var model = _mapper.Map<MoveThreadViewModel>(thread);
				return View(model);
			}
			catch
			{
				return View();
			}
		}
		[HttpPut]
		public IActionResult MoveThread(MoveThreadViewModel model)
		{
			try
			{
				_forumsRepository.MoveThread(model.ThreadPostId, model.ForumId);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageThreads));
			}
			catch
			{
				return View();
			}

		}
		#endregion

		#region Posts
		[HttpGet]
		public IActionResult GetPost(Guid id)
		{
			try
			{
				PostProvider post = _forumsRepository.GetPostById(id);
				var model = _mapper.Map<PostViewModel>(post);
				return View("_PostDetails", model);
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult DeletePost(Guid id)
		{
			try
			{
				_forumsRepository.DeletePost(id);
				_unitOfWork.Commit();
				return View(nameof(this.ManageForums));
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult ManageUnapprovedPosts()
		{
			try
			{
				List<PostProvider> posts = _forumsRepository.GetUnapprovedPosts();
				var model = _mapper.Map<IEnumerable<UnapprovedPostItemViewModel>>(posts);
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpPut]
		public IActionResult ApprovePost(Guid id)
		{
			try
			{
				_forumsRepository.ApprovePost(id);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageUnapprovedPosts));
			}
			catch
			{
				return View();
			}
		}

		#endregion

		#region Private methods
		private Expression<Func<PostProvider, dynamic>> GetSortExpession(string orderBy)
		{
			Expression<Func<PostProvider, dynamic>> expression = null;
			switch (orderBy)
			{
				case (nameof(PostProvider.AddedBy)):
					expression = p => p.AddedBy;
					break;
				case (nameof(PostProvider.ReplyCount)):
					expression = p => p.ReplyCount;
					break;
				case (nameof(PostProvider.AddedDate)):
					expression = p => p.AddedDate;
					break;
				case (nameof(PostProvider.Approved)):
					expression = p => p.Approved;
					break;
				case (nameof(PostProvider.LastPostDate)):
					expression = p => p.LastPostDate;
					break;
				default:
					expression = p => p.AddedDate;
					break;
			}
			return expression;
		}
		#endregion
	}
}
