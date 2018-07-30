using FluentMigrator;

namespace MShop.DataLayer.NHibernate.Migrations.Migrations
{
	[Migration(1)]
	public class _1_CreateTables : Migration
	{
		public override void Up()
		{
            this.CreateCategories();
            this.CreateArticles();
            this.CreateComments();

            this.CreateForums();
            this.CreatePost();

            this.CreateNewsletters();

            this.CreatePolls();
            this.CreatePollOptions();

            this.CreateDepartments();
            this.CreateOrderStatuses();
            this.CreateOrders();
            this.CreateProducts();
            this.CreateOrderItems();

            this.CreateShippingMethods();
        }

		public override void Down()
		{
            Delete.Table("Categories");
            Delete.Table("Articles");
            Delete.Table("Comments");
            Delete.Table("Forums");
            Delete.Table("Posts");
            Delete.Table("Newsletters");
            Delete.Table("Polls");
            Delete.Table("PollOptions");
            Delete.Table("Departments");
            Delete.Table("Products");
            Delete.Table("OrderStatuses");
            Delete.Table("Orders");
            Delete.Table("OrderItems");
            Delete.Table("ShippingMethods");
        }

		private void CreateCategories()
		{
			Create.Table("Categories")
				.WithColumn("Id").AsGuid().PrimaryKey().NotNullable().Indexed()
				.WithColumn("AddedDate").AsDateTime().NotNullable()
				.WithColumn("AddedBy").AsString()
				.WithColumn("Title").AsString()
				.WithColumn("Importance").AsInt32()
				.WithColumn("Description").AsString()
				.WithColumn("ImageUrl").AsString();
		}
		private void CreateArticles()
		{
			Create.Table("Articles")
				.WithColumn("Id").AsGuid().PrimaryKey().NotNullable().Indexed()
				.WithColumn("AddedDate").AsDateTime().NotNullable()
				.WithColumn("AddedBy").AsString()
				.WithColumn("CategoryId").AsGuid().ForeignKey("Categories", "Id").NotNullable().Indexed()
				.WithColumn("Abstract").AsString()
				.WithColumn("Body").AsString()
				.WithColumn("Country").AsString()
				.WithColumn("State").AsString()
				.WithColumn("City").AsString()
				.WithColumn("ReleaseDate").AsDateTime()
				.WithColumn("ExpireDate").AsDateTime()
				.WithColumn("Approved").AsBoolean()
				.WithColumn("Listed").AsBoolean()
				.WithColumn("CommentsEnabled").AsBoolean()
				.WithColumn("OnlyForMembers").AsBoolean()
				.WithColumn("ViewCount").AsInt32()
				.WithColumn("Votes").AsInt32()
				.WithColumn("TotalRating").AsInt32();
		}
		private void CreateComments()
		{
			Create.Table("Comments")
				.WithColumn("Id").AsGuid().PrimaryKey().NotNullable().Indexed()
				.WithColumn("AddedDate").AsDateTime().NotNullable()
				.WithColumn("AddedBy").AsString()
				.WithColumn("AddedByEmail").AsString()
				.WithColumn("AddedByIp").AsString()
				.WithColumn("Body").AsString()
				.WithColumn("ArticleId").AsGuid().ForeignKey("Articles", "Id").NotNullable().Indexed();
		}

		private void CreateForums()
		{
			Create.Table("Forums")
			.WithColumn("Id").AsGuid().PrimaryKey().NotNullable().Indexed()
			.WithColumn("AddedDate").AsDateTime().NotNullable()
			.WithColumn("AddedBy").AsString()
			.WithColumn("Title").AsString()
			.WithColumn("Moderated").AsBoolean()
			.WithColumn("Importance").AsInt32()
			.WithColumn("Description").AsString()
			.WithColumn("ImageUrl").AsString();
		}
		private void CreatePost()
		{
			Create.Table("Posts")
			.WithColumn("Id").AsGuid().PrimaryKey().NotNullable().Indexed()
			.WithColumn("AddedDate").AsDateTime().NotNullable()
			.WithColumn("AddedBy").AsString()
			.WithColumn("AddedByIp").AsString()
			.WithColumn("ForumId").AsGuid().ForeignKey("Forums", "Id")
			.WithColumn("ParentPostId").AsGuid()
			.WithColumn("Title").AsString()
			.WithColumn("Body").AsString()
			.WithColumn("Approved").AsBoolean()
			.WithColumn("Closed").AsBoolean()
			.WithColumn("ViewCount").AsInt32()
			.WithColumn("ReplyCount").AsInt32()
			.WithColumn("LastPostDate").AsDateTime().NotNullable()
			.WithColumn("LastPostBy").AsString()
			.WithColumn("IsThreadPost").AsBoolean()
			;
		}

		private void CreateNewsletters()
		{
			Create.Table("Newsletters")
				.WithColumn("Id").AsGuid().PrimaryKey().NotNullable().Indexed()
				.WithColumn("AddedDate").AsDateTime().NotNullable()
				.WithColumn("AddedBy").AsString()
				.WithColumn("Subject").AsString()
				.WithColumn("PlainTextBody").AsString()
				.WithColumn("HtmlBody").AsString();
		}

		private void CreatePolls()
		{
			Create.Table("Polls")
			.WithColumn("Id").AsGuid().PrimaryKey().NotNullable().Indexed()
			.WithColumn("AddedDate").AsDateTime().NotNullable()
			.WithColumn("AddedBy").AsString()
			.WithColumn("QuestionText").AsString()
			.WithColumn("IsCurrent").AsBoolean()
			.WithColumn("IsArchived").AsBoolean()
			.WithColumn("Votes").AsInt32()
			.WithColumn("ArchivedDate").AsDateTime().NotNullable()
			;
		}
		private void CreatePollOptions()
		{
			Create.Table("PollOptions")
			.WithColumn("Id").AsGuid().PrimaryKey().NotNullable().Indexed()
			.WithColumn("AddedDate").AsDateTime().NotNullable()
			.WithColumn("AddedBy").AsString()
			.WithColumn("PollId").AsGuid().ForeignKey("Polls", "Id")
			.WithColumn("OptionText").AsString()
			.WithColumn("Votes").AsInt32()
			.WithColumn("Percentage").AsDouble()
			;
		}

		private void CreateDepartments()
		{
			Create.Table("Departments")
			.WithColumn("Id").AsGuid().PrimaryKey().NotNullable().Indexed()
			.WithColumn("AddedDate").AsDateTime().NotNullable()
			.WithColumn("AddedBy").AsString()
			.WithColumn("Title").AsString()
			.WithColumn("Importance").AsInt32()
			.WithColumn("Description").AsString()
			.WithColumn("ImageUrl").AsString()
			;
		}
		private void CreateProducts()
		{
			Create.Table("Products")
			.WithColumn("Id").AsGuid().PrimaryKey().NotNullable().Indexed()
			.WithColumn("AddedDate").AsDateTime().NotNullable()
			.WithColumn("AddedBy").AsString()
			.WithColumn("DepartmentId").AsGuid().ForeignKey("Departments", "Id")
			.WithColumn("Title").AsString()
			 .WithColumn("Description").AsString()
			 .WithColumn("SKU").AsString()
			 .WithColumn("UnitPrice").AsDecimal()
			 .WithColumn("DiscountPercentage").AsInt32()
			 .WithColumn("UnitsInStock").AsInt32()
			 .WithColumn("SmallImageUrl").AsString()
			 .WithColumn("FullImageUrl").AsString()
			 .WithColumn("Votes").AsInt32()
			 .WithColumn("TotalRating").AsInt32()
			;
		}
		private void CreateOrderStatuses()
		{
			Create.Table("OrderStatuses")
			.WithColumn("Id").AsGuid().PrimaryKey().NotNullable().Indexed()
			.WithColumn("AddedDate").AsDateTime().NotNullable()
			.WithColumn("AddedBy").AsString()
			.WithColumn("Title").AsString();
		}
		private void CreateOrders()
		{
			Create.Table("Orders")
				.WithColumn("Id").AsGuid().PrimaryKey().NotNullable().Indexed()
				.WithColumn("AddedDate").AsDateTime().NotNullable()
				.WithColumn("AddedBy").AsString()
				.WithColumn("StatusId").AsGuid().ForeignKey("OrderStatuses", "Id")
				.WithColumn("ShippingMethod").AsString()
				.WithColumn("SubTotal").AsDecimal()
				.WithColumn("Shipping").AsDecimal()
				.WithColumn("ShippingFirstName").AsString()
				.WithColumn("ShippingLastName").AsString()
				.WithColumn("ShippingStreet").AsString()
				.WithColumn("ShippingPostalCode").AsString()
				.WithColumn("ShippingCity").AsString()
				.WithColumn("ShippingState").AsString()
				.WithColumn("ShippingCountry").AsString()
				.WithColumn("CustomerEmail").AsString()
				.WithColumn("CustomerPhone").AsString()
				.WithColumn("CustomerFax").AsString()
				.WithColumn("TransactionId").AsString()
				.WithColumn("ShippedDate").AsDateTime()
				.WithColumn("TrackingId").AsString();
		}
		private void CreateOrderItems()
		{
			Create.Table("OrderItems")
			.WithColumn("Id").AsGuid().PrimaryKey().NotNullable().Indexed()
			.WithColumn("AddedDate").AsDateTime().NotNullable()
			.WithColumn("AddedBy").AsString()
			.WithColumn("OrderId").AsGuid().ForeignKey("Orders", "Id")
			.WithColumn("ProductId").AsGuid().ForeignKey("Products", "Id")
			.WithColumn("Title").AsString()
			.WithColumn("SKU").AsString()
			.WithColumn("UnitPrice").AsDecimal()
			.WithColumn("Quantity").AsInt32();
		}

		private void CreateShippingMethods()
		{
			Create.Table("ShippingMethods")
				.WithColumn("Id").AsGuid().PrimaryKey().NotNullable().Indexed()
				.WithColumn("AddedDate").AsDateTime().NotNullable()
				.WithColumn("AddedBy").AsString()
				.WithColumn("Title").AsString()
				.WithColumn("Price").AsDecimal()
				.WithColumn("Description").AsString();
		}
	}
}
