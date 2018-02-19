using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer;
using MShop.DataLayer.EF.Entities.Users;
using MShop.Presentation.MPA.Admin.Models.Users;
//using IUsersRepository = MShop.DataLayer.Repositories.IUsersRepository<MShop.DataLayer.EF.Entities.Users.ApplicationUser>;

namespace MShop.Presentation.MPA.Admin.Controllers
{
	public class ManageUsersController : Controller
	{
		private readonly IMapper _mapper;
		//private readonly IUsersRepository _usersRepository;
		//private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<ApplicationUser> _userManager;

		public ManageUsersController(IMapper mapper,  UserManager<ApplicationUser> userManager)
		{
			_mapper = mapper;			
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult ManageUsers()
		{
			return View(_userManager.Users.ToList());
		}
		[HttpGet]
		public IActionResult CreateUser() => View();

		[HttpPost]
		public async Task<IActionResult> CreateUser(CreateUserViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser { Email = model.Email, UserName = model.Email };
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					return RedirectToAction(nameof(this.ManageUsers));
				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
			}
			return View(model);
		}

		public async Task<IActionResult> EditUser(string id)
		{
			IdentityUser user = await _userManager.FindByIdAsync(id);
			if (user == null)
			{
				return NotFound();
			}
			var model = new EditUserViewModel { Id = user.Id, Email = user.Email };
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditUser(EditUserViewModel model)
		{
			if (ModelState.IsValid)
			{
				ApplicationUser user = await _userManager.FindByIdAsync(model.Id);
				if (user != null)
				{
					user.Email = model.Email;
					user.UserName = model.Email;

					var result = await _userManager.UpdateAsync(user);
					if (result.Succeeded)
					{
						return RedirectToAction(nameof(this.ManageUsers));
					}
					else
					{
						foreach (var error in result.Errors)
						{
							ModelState.AddModelError(string.Empty, error.Description);
						}
					}
				}
			}
			return View(model);
		}

		[HttpPost]
		public async Task<ActionResult> Delete(string id)
		{
			ApplicationUser user = await _userManager.FindByIdAsync(id);
			if (user != null)
			{
				IdentityResult result = await _userManager.DeleteAsync(user);
			}
			return RedirectToAction(nameof(this.ManageUsers));
		}
		public async Task<IActionResult> ChangePassword(string id)
		{
			IdentityUser user = await _userManager.FindByIdAsync(id);
			if (user == null)
			{
				return NotFound();
			}
			var model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				ApplicationUser user = await _userManager.FindByIdAsync(model.Id);
				if (user != null)
				{
					var _passwordValidator =
						HttpContext.RequestServices.GetService(typeof(IPasswordValidator<ApplicationUser>)) as IPasswordValidator<ApplicationUser>;
					var _passwordHasher =
						HttpContext.RequestServices.GetService(typeof(IPasswordHasher<ApplicationUser>)) as IPasswordHasher<ApplicationUser>;

					IdentityResult result =
						await _passwordValidator.ValidateAsync(_userManager, user, model.NewPassword);
					if (result.Succeeded)
					{
						user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
						await _userManager.UpdateAsync(user);
						return RedirectToAction(nameof(this.ManageUsers));
					}
					else
					{
						foreach (var error in result.Errors)
						{
							ModelState.AddModelError(string.Empty, error.Description);
						}
					}
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Пользователь не найден");
				}
			}
			return View(model);
		}
	}
}
