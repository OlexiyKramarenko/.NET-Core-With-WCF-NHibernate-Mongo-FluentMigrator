
using System;
using System.Collections.Generic;
using MShop.DataLayer.Entities.Newsletters;

namespace MShop.DataLayer.Repositories
{
	public interface INewslettersRepository<T, IdType> where T : INewsletter
	{
		List<T> GetNewsletters(DateTime toDate);
		T GetNewsletterById(IdType newsletterId);
		void DeleteNewsletter(IdType newsletterId);
		void UpdateNewsletter(T newsletter);
		void InsertNewsletter(T newsletter); 
	}
}
