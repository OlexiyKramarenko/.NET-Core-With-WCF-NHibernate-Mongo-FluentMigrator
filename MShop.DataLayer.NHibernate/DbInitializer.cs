using System;
using MShop.DataLayer.NHibernate.Entities.Articles;
using MShop.DataLayer.NHibernate.Entities.Forums;
using MShop.DataLayer.NHibernate.Entities.Polls;
using MShop.DataLayer.NHibernate.Entities.Store;
using testData = MShop.DataLayer.TestData<
                MShop.DataLayer.NHibernate.Entities.Polls.Poll,
                MShop.DataLayer.NHibernate.Entities.Polls.PollOption,
                MShop.DataLayer.NHibernate.Entities.Store.Department,
                MShop.DataLayer.NHibernate.Entities.Store.Product,
                MShop.DataLayer.NHibernate.Entities.Store.OrderStatus,
                MShop.DataLayer.NHibernate.Entities.Store.Order,
                MShop.DataLayer.NHibernate.Entities.Store.OrderItem,
                MShop.DataLayer.NHibernate.Entities.Store.ShippingMethod,
                MShop.DataLayer.NHibernate.Entities.Newsletters.Newsletter,
                MShop.DataLayer.NHibernate.Entities.Forums.Forum,
                MShop.DataLayer.NHibernate.Entities.Forums.Post,
                MShop.DataLayer.NHibernate.Entities.Articles.Category,
                MShop.DataLayer.NHibernate.Entities.Articles.Article,
                MShop.DataLayer.NHibernate.Entities.Articles.Comment>;

namespace MShop.DataLayer.NHibernate
{
    public static class DbInitializer
	{
		public static void Initialize(NHUnitOfWork unitOfWork)
		{
			try
			{
				unitOfWork.BeginTransaction();

				foreach (var poll in testData.polls)
				{
					unitOfWork.Session.SaveOrUpdate(poll);
					foreach (var option in poll.PollOptions)
					{
						unitOfWork.Session.SaveOrUpdate((PollOption)option);
					}
				}
				unitOfWork.Commit();
				unitOfWork.BeginTransaction();
				foreach (var department in testData.departments)
				{
					unitOfWork.Session.SaveOrUpdate(department);
					foreach (var product in department.Products)
					{
						unitOfWork.Session.SaveOrUpdate((Product)product);
					}
				}
				unitOfWork.Commit();
				unitOfWork.BeginTransaction();
				foreach (var orderStatus in testData.orderStatuses)
				{
					unitOfWork.Session.SaveOrUpdate(orderStatus);
					if (orderStatus.Orders != null)
						foreach (var order in orderStatus.Orders)
						{
							unitOfWork.Session.SaveOrUpdate((Order)order);
							foreach (var orderItem in order.OrderItems)
							{
								unitOfWork.Session.SaveOrUpdate((OrderItem)orderItem);
							}
						}
				}
				unitOfWork.Commit();
				unitOfWork.BeginTransaction();
				foreach (var shippingMethod in testData.shippingMethods)
				{
					unitOfWork.Session.Save(shippingMethod);
				}
				unitOfWork.Commit();
				unitOfWork.BeginTransaction();
				foreach (var newsletter in testData.newsletters)
				{
					unitOfWork.Session.Save(newsletter);
				}
				unitOfWork.Commit();

				unitOfWork.BeginTransaction();
				foreach (var category in testData.categories)
				{
					unitOfWork.Session.SaveOrUpdate(category);
					foreach (var article in category.Articles)
					{
						unitOfWork.Session.SaveOrUpdate((Article)article);
						foreach (var comment in article.Comments)
						{
							unitOfWork.Session.SaveOrUpdate((Comment)comment);
						}
					}
				}
				unitOfWork.Commit();

				unitOfWork.BeginTransaction();
				foreach (var forum in testData.forums)
				{
					unitOfWork.Session.Save(forum);
					foreach (var post in forum.Posts)
					{
						unitOfWork.Session.Save((Post)post);
					}
				}
				unitOfWork.Commit();
			}
			catch (System.Exception exc)
			{
				throw;
			}
		}
	}
}
