
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MShop.DataLayer;
using MShop.DataLayer.EF.Entities.Forums;
using MShop.DataLayer.EF.Providers.Forum;
using MShop.Presentation.MPA.Public.Models.Forums;
using IForumsRepository =
	MShop.DataLayer.Repositories.IForumsRepository<
		MShop.DataLayer.EF.Entities.Forums.Forum,
		MShop.DataLayer.EF.Entities.Forums.Post,
		MShop.DataLayer.EF.Providers.Forum.PostProvider, System.Guid>;

namespace MShop.Presentation.MPA.Public.Controllers
{
	public class ForumController : Controller
	{
		private readonly IForumsRepository _forumsRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public ForumController(IForumsRepository forumsRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_forumsRepository = forumsRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult BrowseThreads(Guid forumId, int pageIndex, int pageSize)
		{ 
			List<PostProvider> threads = _forumsRepository.GetThreads(forumId, p => p.AddedBy, pageIndex, pageSize);
			var threadItems = _mapper.Map<List<ThreadItemViewModel>>(threads);
			var forums = _forumsRepository.GetForums();
			var model = new BrowseThreadsViewModel
			{
				ForumId = forumId,
				ThreadItems = threadItems,
				Forums = new SelectList(forums, nameof(Forum.Id), nameof(Forum.Title))
			};
			return View(model);
		}
		
		[HttpGet]
		public IActionResult ShowForums()
		{
			List<Forum> forums = _forumsRepository.GetForums();
			var model = _mapper.Map<List<ForumItemViewModel>>(forums);
			return View(model);
		}

		[HttpGet]
		public IActionResult ShowThread(Guid threadId, Guid forumId)
		{
			List<PostProvider> posts = _forumsRepository.GetThreadById(threadId);
			var model = new ShowThreadViewModel
			{
				ThreadId = threadId,
				ForumId = forumId,
				Posts = _mapper.Map<List<PostItemViewModel>>(posts)
			};
			return View(model);
		}

		[HttpGet]
		public IActionResult AddPost(Guid forumId, Guid threadId)
		{
			var model = new AddPostViewModel
			{
				ThreadId = threadId,
				ForumId = forumId
			};
			return View(model);
		}

		[HttpPost]
		public IActionResult AddPost(AddPostViewModel model)
		{
			try
			{
				var post = _mapper.Map<Post>(model);
				_forumsRepository.InsertPost(post);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.BrowseThreads), 
					new { forumId = model.ForumId, pageIndex = 1, pageSize = 5 });
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult EditPost(Guid id)
		{
			try
			{
				Post post = _forumsRepository.GetPostById(id);
				EditPostViewModel model = _mapper.Map<Post, EditPostViewModel>(post);
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpPut]
		public IActionResult EditPost(EditPostViewModel model)
		{
			try
			{
				Post post = _mapper.Map<EditPostViewModel, Post>(model);
				_forumsRepository.UpdatePost(post);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.BrowseThreads));
			}
			catch
			{
				return View();
			}
		}

		[HttpDelete]
		public IActionResult DeletePost(Guid id)
		{
			try
			{
				_forumsRepository.DeletePost(id);
				_unitOfWork.Commit();
				return View(nameof(this.BrowseThreads));
			}
			catch
			{
				return View();
			}
		}
		
		 
	}
}
