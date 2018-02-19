using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer.EF.Entities.Users;
using MShop.Presentation.MPA.Auth.Models;
using MShop.Presentation.MPA.Auth.Services;

namespace MShop.Presentation.MPA.Auth.Controllers
{
    public class UserController:Controller
    {
        //private readonly IMapper _mapper;
	    private readonly UserManager<ApplicationUser> _userManager;
	    private readonly SignInManager<ApplicationUser> _signInManager;

	    public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
	    {
		    _userManager = userManager;
		    _signInManager = signInManager;
	    }

	    [HttpGet]
	    public IActionResult Register()
	    {
		    return View(null);
	    }

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					var callbackUrl = Url.Action(
						"ConfirmEmail",
						"Account",
						new { userId = user.Id, code = code },
						protocol: HttpContext.Request.Scheme);
					EmailService emailService = new EmailService();
					await emailService.SendEmailAsync(model.Email, "Confirm your account",
						$"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");

					// await _signInManager.SignInAsync(user, isPersistent: false);
					//return RedirectToLocal(returnUrl);
				}
				//AddErrors(result);
			}
			return View(model);
		}
		[HttpGet]
	    public IActionResult Login(string returnUrl = null)
	    {
		    return View(new LoginViewModel { ReturnUrl = returnUrl });
	    }

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByNameAsync(model.Email);
				if (user != null)
				{
					// проверяем, подтвержден ли email
					if (!await _userManager.IsEmailConfirmedAsync(user))
					{
						ModelState.AddModelError(string.Empty, "Вы не подтвердили свой email");
						return View(model);
					}
				}

				var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password,
													model.RememberMe, lockoutOnFailure: false);
				if (result.Succeeded)
				{
					//return RedirectToLocal(returnUrl);
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Invalid login attempt.");
					return View(model);
				}
			}

			return View(model);
		}

		[HttpPost]
	    [ValidateAntiForgeryToken]
	    public async Task<IActionResult> LogOff()
	    {
		    // удаляем аутентификационные куки
		    await _signInManager.SignOutAsync();
		    return RedirectToAction("Index", "Home");
	    }
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> ConfirmEmail(string userId, string code)
		{
			if (userId == null || code == null)
			{
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return View("Error");
			}
			var result = await _userManager.ConfirmEmailAsync(user, code);
			return View(result.Succeeded ? "ConfirmEmail" : "Error");
		}
		[HttpGet]
		[AllowAnonymous]
		public IActionResult ForgotPassword()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByNameAsync(model.Email);
				if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
				{
					return View("ForgotPasswordConfirmation");
				}

				var code = await _userManager.GeneratePasswordResetTokenAsync(user);
				var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
				EmailService emailService = new EmailService();
				await emailService.SendEmailAsync(model.Email, "Reset Password",
					$"Для сброса пароля пройдите по ссылке: <a href='{callbackUrl}'>link</a>");
				return View("ForgotPasswordConfirmation");
			}
			return View(model);
		}
		[HttpGet]
		[AllowAnonymous]
		public IActionResult ResetPassword(string code = null)
		{
			return code == null ? View("Error") : View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var user = await _userManager.FindByNameAsync(model.Email);
			if (user == null)
			{
				return RedirectToAction(nameof(UserController.ResetPasswordConfirmation), "Users");
			}
			var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
			if (result.Succeeded)
			{
				return RedirectToAction(nameof(UserController.ResetPasswordConfirmation), "Users");
			}
			AddErrors(result);
			return View();
		}

		private void AddErrors(IdentityResult result)
		{
			throw new NotImplementedException();
		}

		private static object ResetPasswordConfirmation()
		{
			throw new NotImplementedException();
		}
	}
}
