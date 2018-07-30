using Microsoft.AspNetCore.Mvc;
using MShop.Presentation.MPA.Public.Models.Home;
using System.Net.Mail;
using IArticlesRepository = MShop.DataLayer.Repositories.IArticlesRepository<
MShop.DataLayer.EF.Entities.Articles.Article,
MShop.DataLayer.EF.Entities.Articles.Category,
MShop.DataLayer.EF.Entities.Articles.Comment,
MShop.DataLayer.EF.Providers.Articles.ArticleProvider,
MShop.DataLayer.EF.Providers.Articles.CommentProvider, System.Guid>;

namespace MShop.Presentation.MPA.Public.Controllers
{
	public class HomeController : Controller
	{
		private readonly IArticlesRepository repo;
		public HomeController(IArticlesRepository repo)
		{
			this.repo = repo;
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Contact()
		{
			return View();
		}
        [HttpPost]
		public IActionResult Contact(ContactsViewModel model)
		{
            using (var message = new MailMessage(model.Email, "me@mydomain.com"))
            {
                message.To.Add(new MailAddress("me@mydomain.com"));
                message.From = new MailAddress(model.Email);              
                message.Body = model.Body;
                message.Subject = model.Subject;
                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Send(message);
                }
            }
            return View();
		}
		
	}
}
