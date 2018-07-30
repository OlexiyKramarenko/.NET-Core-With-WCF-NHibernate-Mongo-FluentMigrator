using FluentMigrator;
using MShop.DataLayer.NHibernate.Entities.Articles;
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

namespace MShop.DataLayer.NHibernate.Migrations.Migrations
{
	[Migration(2)]
	public class _2_InsertDataToTables : Migration
	{
		public override void Up()
		{
			//foreach (Category item in testData.categories)
			//{
			//	var category = new {
			//		item.AddedBy,
			//		item.AddedDate,
			//		item.Description,
			//		item.
			//	};

			//	Insert.IntoTable("Categories").Row(category);
			//}
			////foreach (Category item in testData.art)
			////{
			////	Insert.IntoTable("Categories").Row(item);
			////}
		}

		public override void Down()
		{
		}
	}
}
