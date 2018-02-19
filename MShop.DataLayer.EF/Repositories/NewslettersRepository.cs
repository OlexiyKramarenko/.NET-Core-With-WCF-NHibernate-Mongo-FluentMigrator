
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MShop.DataLayer.EF.Entities.Newsletters;
using MShop.DataLayer.Repositories;

namespace MShop.DataLayer.EF.Repositories
{
	public class NewslettersRepository : INewslettersRepository<Newsletter, Guid>
	{
		private readonly EfUnitOfWork _unitOfWork;

		public NewslettersRepository(EfUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		#region Public Methods
		public List<Newsletter> GetNewsletters(DateTime toDate)
		{
			List<Newsletter> newsletters = _unitOfWork.Context
													  .Newsletters
													  .Where(a => a.AddedDate <= toDate)
													  .OrderByDescending(a => a.AddedDate)
													  .AsNoTracking()
													  .ToList();
			return newsletters;
		}

		public Newsletter GetNewsletterById(Guid newsletterId)
		{
			return _unitOfWork.Context
							  .Newsletters
							  .Find(newsletterId);
		}
		public void DeleteNewsletter(Guid newsletterId)
		{
			Newsletter newsletter = _unitOfWork.Context
											   .Newsletters
											   .Find(newsletterId);
			if (newsletter != null)
			{
				_unitOfWork.Context.Newsletters.Remove(newsletter);
			}
		}

		public void UpdateNewsletter(Newsletter newsletter)
		{
			Newsletter ctxNewsletter = _unitOfWork.Context
												  .Newsletters
												  .Find(newsletter.Id);
			if (ctxNewsletter != null)
			{
				ctxNewsletter.AddedDate = newsletter.AddedDate;
				ctxNewsletter.AddedBy = newsletter.AddedBy;
				ctxNewsletter.HtmlBody = newsletter.HtmlBody;
				ctxNewsletter.PlainTextBody = newsletter.PlainTextBody;
				ctxNewsletter.Subject = newsletter.Subject;
			}
		}
		public void InsertNewsletter(Newsletter newsletter)
		{
			_unitOfWork.Context.Newsletters.Add(newsletter);
		}
		#endregion
	}
}
