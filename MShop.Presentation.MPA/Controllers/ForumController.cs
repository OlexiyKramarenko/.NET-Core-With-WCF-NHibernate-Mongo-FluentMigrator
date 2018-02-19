
using System;
using System.Collections.Generic;
using System.Linq;
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
		public IActionResult BrowseThreads(Guid id, int pageIndex, int pageSize)
		{
			List<PostProvider> threads = _forumsRepository.GetThreads(id, null, pageIndex, pageSize);
			List<ThreadItemViewModel> threadItems = _mapper.Map<List<PostProvider>, List<ThreadItemViewModel>>(threads);
			var forums = _forumsRepository.GetForums().Select(f => new SelectListItem { Text = f.Title, Value = f.Id.ToString() });
			var model = new BrowseThreadsViewModel
			{
				ForumId = id,
				ThreadItems = threadItems,
				Forums = new SelectList(forums)
			};
			return View(model);
		}

		[HttpGet]
		public IActionResult ShowForums()
		{
			List<Forum> forums = _forumsRepository.GetForums();
			List<ForumItemViewModel> model = _mapper.Map<List<Forum>, List<ForumItemViewModel>>(forums);
			return View(model);
		}

		[HttpGet]
		public IActionResult ShowThread(Guid id)
		{
			List<PostProvider> forums = _forumsRepository.GetThreadById(id);
			List<PostItemViewModel> model = _mapper.Map<List<PostProvider>, List<PostItemViewModel>>(forums);
			return View(model);
		}
		[HttpGet]
		public IActionResult AddPost()
		{

			return View();
		}
		[HttpPost]
		public IActionResult AddPost(AddPostViewModel model)
		{
			try
			{
				Post post = _mapper.Map<AddPostViewModel, Post>(model);
				_forumsRepository.InsertPost(post);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.BrowseThreads));
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
