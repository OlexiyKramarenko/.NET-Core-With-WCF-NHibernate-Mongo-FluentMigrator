using testData = MShop.DataLayer.TestData<
				MShop.DataLayer.EF.Entities.Polls.Poll,
				MShop.DataLayer.EF.Entities.Polls.PollOption,
				MShop.DataLayer.EF.Entities.Store.Department,
				MShop.DataLayer.EF.Entities.Store.Product,
				MShop.DataLayer.EF.Entities.Store.OrderStatus,
				MShop.DataLayer.EF.Entities.Store.Order,
				MShop.DataLayer.EF.Entities.Store.OrderItem,
				MShop.DataLayer.EF.Entities.Store.ShippingMethod,
				MShop.DataLayer.EF.Entities.Newsletters.Newsletter,
				MShop.DataLayer.EF.Entities.Forums.Forum,
				MShop.DataLayer.EF.Entities.Forums.Post,
				MShop.DataLayer.EF.Entities.Articles.Category,
				MShop.DataLayer.EF.Entities.Articles.Article,
				MShop.DataLayer.EF.Entities.Articles.Comment>;

namespace MShop.DataLayer.EF
{
	public static class DbInitializer
	{
		public static void Initialize(DataBaseContext db)
		{
			try
			{
				db.Polls.AddRange(testData.polls);
				int result = db.SaveChanges();
				db.Departments.AddRange(testData.departments);
				result = db.SaveChanges();
				db.OrderStatuses.AddRange(testData.orderStatuses);
				result = db.SaveChanges();
				//db.Orders.AddRange(testData.orders);
				//result = db.SaveChanges();
				
				db.ShippingMethods.AddRange(testData.shippingMethods);
				result = db.SaveChanges();
				db.Newsletters.AddRange(testData.newsletters);
				result = db.SaveChanges();
				db.Forums.AddRange(testData.forums);
				result = db.SaveChanges();
				db.Categories.AddRange(testData.categories);
				result = db.SaveChanges();
			}
			catch (System.Exception exc)
			{ 
				throw;
			} 
		}
	}
}
