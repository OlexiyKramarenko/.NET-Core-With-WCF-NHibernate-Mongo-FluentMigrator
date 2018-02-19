using Microsoft.EntityFrameworkCore;
using MShop.DataLayer.EF.Entities.Articles;
using MShop.DataLayer.EF.Entities.Forums;
using MShop.DataLayer.EF.Entities.Newsletters;
using MShop.DataLayer.EF.Entities.Polls;
using MShop.DataLayer.EF.Entities.Store;
using System;
using System.Linq;

namespace MShop.DataLayer.EF
{
	public static class DbInitializer
	{
		public static void Initialize(DataBaseContext db)
		{
			var poll11 = new Poll
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				QuestionText = "What do you like to eat with your beer?",
				IsCurrent = true,
				IsArchived = false,
				ArchivedDate = null
			};
			var poll12 = new Poll
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2009, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				QuestionText = "What d+++++++++++++++h your beer?",
				IsCurrent = true,
				IsArchived = false,
				ArchivedDate = null
			};
			var poll13 = new Poll
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2025, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				QuestionText = "What--------------er?",
				IsCurrent = true,
				IsArchived = false,
				ArchivedDate = null
			};
			db.Polls.Add(poll11);
			db.Polls.Add(poll12);
			db.Polls.Add(poll13);
			db.SaveChanges();
			var pollOption11 = new PollOption
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				PollId = poll11.Id,
				OptionText = "Sandwiches",
				Votes = 4
			};
			var pollOption111 = new PollOption
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				PollId = poll11.Id,
				OptionText = "Ahahhaha",
				Votes = 4
			};
			db.PollOptions.Add(pollOption11);
			db.PollOptions.Add(pollOption111);
			db.SaveChanges();
			var orderItem2 = new OrderItem
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				OrderId = Guid.Parse("158e350d-c007-41f5-9cf2-52c3c6659a8f"),
				//ProductId
				Title = "Key Chain",
				SKU = "KEY1",
				UnitPrice = 9.11M,
				Quantity = 3
			};
			db.OrderItems.Add(orderItem2);
			int res = db.SaveChanges();

			//if (db.ShippingMethods.Any())
			//{
			//	return;
			//}
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[ShippingMethods] ON");
			#region ShippingMethods
			var shippingMethod1 = new ShippingMethod
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				Title = "Standard",
				Price = 6.0M
			};
			var shippingMethod2 = new ShippingMethod
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				Title = "Next Business Day",
				Price = 10.0M
			};
			var shippingMethod3 = new ShippingMethod
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				Title = "Overnight",
				Price = 15.0M
			};
			db.ShippingMethods.Add(shippingMethod1);
			db.ShippingMethods.Add(shippingMethod2);
			db.ShippingMethods.Add(shippingMethod3);
			db.SaveChanges();
			#endregion
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[ShippingMethods] OFF");

			//if (db.OrderStatuses.Any())
			//{
			//	return;
			//}
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[OrderStatuses] ON");
			#region OrderStatuses
			var orderStatus1 = new OrderStatus
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				Title = "Waiting for payment"
			};
			db.OrderStatuses.Add(orderStatus1);
			db.SaveChanges();

			#endregion
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[OrderStatuses] OFF");

			//if (db.Orders.Any())
			//{
			//	return;
			//}
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Orders] ON");
			#region Orders
			var order1 = new Order
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				StatusId = orderStatus1.Id,
				ShippingMethod = "Next Business Day ",
				SubTotal = 75.03M,
				Shipping = 10.00M,
				ShippingFirstName = "Marco",
				ShippingLastName = "Bellinaso",
				ShippingStreet = "Somewhere Street",
				ShippingPostalCode = "12345",
				ShippingCity = "Bologna",
				ShippingState = "BO",
				ShippingCountry = "Italy",
				CustomerEmail = "mbellinaso@wrox.com",
				CustomerPhone = "12345678",
				ShippedDate = null
			};
			db.Orders.Add(order1);
			db.SaveChanges();
			#endregion
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Orders] OFF");

			//if (db.OrderItems.Any())
			//{
			//	return;
			//}
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[OrderItems] ON");
			//#region OrderItems
			//var orderItem1 = new OrderItem
			//{
			//	Id = Guid.NewGuid(),
			//	AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
			//	AddedBy = "Marco",
			//	OrderId = Guid.Parse("b0fd2980-69cf-454c-bc82-414a5bc469ad"),
			//	ProductId = Guid.Parse("31643c5e-78db-49c3-ad19-2c86c5126d45"),
			//	Title = "Key Chain",
			//	SKU = "KEY1",
			//	UnitPrice = 9.11M,
			//	Quantity = 3
			//};
			//db.OrderItems.Add(orderItem1);
			//db.SaveChanges();
			//#endregion
			////db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[OrderItems] OFF");

			//var product1 = new Product
			//{
			//	Id = Guid.NewGuid(),
			//	AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
			//	AddedBy = "Marco",
			//	DepartmentId = Guid.Parse("c447b931-96d1-4fbb-7d35-08d56b1dd8ae"),
			//	Title = "Beer Cap",
			//	Description = "<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin a tortor non dolor pulvinar adipiscing. Ut sagittis aliquet felis. In et eros id leo pulvinar suscipit. Curabitur euismod mauris ut sapien. Nam odio arcu, suscipit vitae, adipiscing eu, vestibulum sed, ligula. Maecenas orci nunc, dictum a, pretium in, luctus ac, mauris. Vestibulum ut risus et nisi venenatis porta. Donec vestibulum, quam non hendrerit auctor, felis nulla hendrerit nibh, sit amet scelerisque leo neque id turpis. Donec gravida. Cras accumsan viverra velit. Maecenas enim sem, facilisis vel, imperdiet et, placerat a, quam. Proin id est. Etiam condimentum. In mollis, ligula eget sollicitudin euismod, lorem arcu ultricies velit, nec adipiscing libero diam ac leo. In eu velit. Phasellus tristique sem vitae pede. Nam est nisl, volutpat non, pellentesque vitae, volutpat nec, nulla. </p>",
			//	SKU = "CAP1",
			//	UnitPrice = 12.50M,
			//	DiscountPercentage = 0,
			//	UnitsInStock = 1000000,
			//	SmallImageUrl = "~/Images/Store/cap1_small.jpg",
			//	Votes = 1,
			//	TotalRating = 3
			//};
			//var product2 = new Product
			//{
			//	Id = Guid.NewGuid(),
			//	AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
			//	AddedBy = "Marco",
			//	DepartmentId = Guid.Parse("c447b931-96d1-4fbb-7d35-08d56b1dd8ae"),
			//	Title = "Beer Cap",
			//	Description = "<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin a tortor non dolor pulvinar adipiscing. Ut sagittis aliquet felis. In et eros id leo pulvinar suscipit. Curabitur euismod mauris ut sapien. Nam odio arcu, suscipit vitae, adipiscing eu, vestibulum sed, ligula. Maecenas orci nunc, dictum a, pretium in, luctus ac, mauris. Vestibulum ut risus et nisi venenatis porta. Donec vestibulum, quam non hendrerit auctor, felis nulla hendrerit nibh, sit amet scelerisque leo neque id turpis. Donec gravida. Cras accumsan viverra velit. Maecenas enim sem, facilisis vel, imperdiet et, placerat a, quam. Proin id est. Etiam condimentum. In mollis, ligula eget sollicitudin euismod, lorem arcu ultricies velit, nec adipiscing libero diam ac leo. In eu velit. Phasellus tristique sem vitae pede. Nam est nisl, volutpat non, pellentesque vitae, volutpat nec, nulla. </p>",
			//	SKU = "CAP1",
			//	UnitPrice = 12.50M,
			//	DiscountPercentage = 0,
			//	UnitsInStock = 1000000,
			//	SmallImageUrl = "~/Images/Store/cap1_small.jpg",
			//	Votes = 1,
			//	TotalRating = 3
			//};
			//var product3 = new Product
			//{
			//	Id = Guid.NewGuid(),
			//	AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
			//	AddedBy = "Marco",
			//	DepartmentId = Guid.Parse("c447b931-96d1-4fbb-7d35-08d56b1dd8ae"),
			//	Title = "Beer Cap",
			//	Description = "<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin a tortor non dolor pulvinar adipiscing. Ut sagittis aliquet felis. In et eros id leo pulvinar suscipit. Curabitur euismod mauris ut sapien. Nam odio arcu, suscipit vitae, adipiscing eu, vestibulum sed, ligula. Maecenas orci nunc, dictum a, pretium in, luctus ac, mauris. Vestibulum ut risus et nisi venenatis porta. Donec vestibulum, quam non hendrerit auctor, felis nulla hendrerit nibh, sit amet scelerisque leo neque id turpis. Donec gravida. Cras accumsan viverra velit. Maecenas enim sem, facilisis vel, imperdiet et, placerat a, quam. Proin id est. Etiam condimentum. In mollis, ligula eget sollicitudin euismod, lorem arcu ultricies velit, nec adipiscing libero diam ac leo. In eu velit. Phasellus tristique sem vitae pede. Nam est nisl, volutpat non, pellentesque vitae, volutpat nec, nulla. </p>",
			//	SKU = "CAP1",
			//	UnitPrice = 12.50M,
			//	DiscountPercentage = 0,
			//	UnitsInStock = 1000000,
			//	SmallImageUrl = "~/Images/Store/cap1_small.jpg",
			//	Votes = 1,
			//	TotalRating = 3
			//};
			//db.Products.Add(product1);
			//db.Products.Add(product2);
			//db.Products.Add(product3);
			//db.SaveChanges();
			if (db.Forums.Any())
			{
				return;
			}
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Forums] ON");
			#region Forums
			var forum1 = new Forum
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 11, 27, 15, 25, 25),
				AddedBy = "Marco",
				Title = "Beer-related discussions",
				Moderated = false,
				Importance = 100,
				Description = "Everything you want to say and ask about your favorite beverage: beer!",
				ImageUrl = "~/Images/Beers.gif"
			};
			var forum2 = new Forum
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 11, 27, 15, 25, 25),
				AddedBy = "Marco",
				Title = "Beer-related discussions",
				Moderated = false,
				Importance = 100,
				Description = "AHAHAHHA about your favorite beverage: beer!",
				ImageUrl = "~/Images/Beers.gif"
			};
			db.Forums.Add(forum1);
			db.Forums.Add(forum2);
			db.SaveChanges();
			#endregion
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Forums] OFF");

			if (db.Posts.Any())
			{
				return;
			}
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Products] ON");
			#region Posts
			var post1 = new Post
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				AddedByIP = "127.0.0.1",
				ForumId = forum1.Id,
				Title = "Personal how-to to brewing great beer",
				Body = "<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nulla justo. Nam varius aliquam elit. Suspendisse nonummy, arcu vitae lacinia auctor, nisi mi posuere arcu, fermentum pellentesque sapien enim at elit. Sed porttitor dictum purus. Ut porttitor nonummy nunc. Morbi vitae nulla ac metus semper auctor. Ut justo. Curabitur fermentum, augue quis ultrices rutrum, justo lorem ullamcorper orci, vel condimentum nibh lorem at sapien. Pellentesque facilisis ipsum a est. Nullam convallis, dolor id facilisis porta, ipsum dui fermentum lectus, in tincidunt arcu libero ut neque. Sed pellentesque odio sit amet mi. Nulla congue mauris et lacus. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. In et odio nec justo feugiat vulputate. Nullam lobortis congue lectus. </p>< p > Pellentesque sed nisl.Maecenas fringilla nonummy felis.Sed ullamcorper.Nullam est nulla,lacus.Nulla congue nisl non neque.Pellentesque vel dolor quis erat sollicitudin feugiat.Ut semper venenatis diam. </ p > ",
				Approved = true,
				Closed = false,
				ViewCount = 4,
				ReplyCount = 1,
				LastPostBy = "Homer",
				LastPostDate = new DateTime(2006, 1, 16, 17, 14, 11)
			};

			db.Posts.Add(post1);
			db.SaveChanges();
			var post2 = new Post
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				AddedByIP = "127.0.0.1",
				ForumId = forum1.Id,
				ParentPostId = post1.Id,
				Title = "Personal how-to to brewing great beer",
				Body = "<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nulla justo. Nam varius aliquam elit. Suspendisse nonummy, arcu vitae lacinia auctor, nisi mi posuere arcu, fermentum pellentesque sapien enim at elit. Sed porttitor dictum purus. Ut porttitor nonummy nunc. Morbi vitae nulla ac metus semper auctor. Ut justo. Curabitur fermentum, augue quis ultrices rutrum, justo lorem ullamcorper orci, vel condimentum nibh lorem at sapien. Pellentesque facilisis ipsum a est. Nullam convallis, dolor id facilisis porta, ipsum dui fermentum lectus, in tincidunt arcu libero ut neque. Sed pellentesque odio sit amet mi. Nulla congue mauris et lacus. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. In et odio nec justo feugiat vulputate. Nullam lobortis congue lectus. </p>< p > Pellentesque sed nisl.Maecenas fringilla nonummy felis.Sed ullamcorper.Nullam est nulla,lacus.Nulla congue nisl non neque.Pellentesque vel dolor quis erat sollicitudin feugiat.Ut semper venenatis diam. </ p > ",
				Approved = false,
				Closed = false,
				ViewCount = 4,
				ReplyCount = 1,
				LastPostBy = "Homer",
				LastPostDate = new DateTime(2006, 1, 16, 17, 14, 11)
			};
			db.Posts.Add(post2);
			db.SaveChanges();
			#endregion
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Products] OFF");

			db.Database.OpenConnection();
			if (db.Categories.Any())
			{
				return;
			}
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Categories] ON");
			#region Categories
			var category1 = new Category
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 8, 24, 18, 36, 0),
				AddedBy = "Marco",
				Title = "Beer-related articles",
				Importance = 0,
				Description = "Everything you want to know about your favorite beverage: beer! Find out how the beer is brewed, and how to do it on your own. Discover new recipes and useful tips &amp; tricks.",
				ImageUrl = "~/Images/Beers.gif"
			};
			var category2 = new Category
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 8, 24, 18, 22, 0),
				AddedBy = "Marco",
				Title = "Site staff's blog",
				Importance = 0,
				Description = "Our staff's online diary: find out what they do when not at work in our pub and what they think about anything. You can also get in touch with them by commenting on their posts.",
				ImageUrl = "~/Images/Diary.gif"
			};
			var category3 = new Category
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 8, 24, 18, 33, 0),
				AddedBy = "Marco",
				Title = "General news & articles",
				Importance = 0,
				Description = "General news and announcements about this site and our community of beer fans.",
				ImageUrl = "~/Images/News.gif"
			};
			var category4 = new Category
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 8, 24, 18, 39, 0),
				AddedBy = "Marco",
				Title = "Photo galleries",
				Importance = 0,
				Description = "Galleries of photos taken at events we organized or supported. Can you spot yourself somewhere?",
				ImageUrl = "~/Images/Camera.gif"
			};
			var category5 = new Category
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 8, 24, 18, 22, 0),
				AddedBy = "Marco",
				Title = "Special events, concerts & parties",
				Importance = 0,
				Description = "What's better than having a beer at a near concert, party, or some other special event? Find out what's happening next to you in this period.",
				ImageUrl = "~/Images/Guitar.gif"
			};
			var category6 = new Category
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 8, 24, 18, 21, 0),
				AddedBy = "Marco",
				Title = "Questions & Answers",
				Importance = 0,
				Description = "A collection of answers to the most frequest questions, and a few guides on how to use this site.",
				ImageUrl = "~/Images/Question.gif"
			};
			db.Categories.Add(category1);
			db.Categories.Add(category2);
			db.Categories.Add(category3);
			db.Categories.Add(category4);
			db.Categories.Add(category5);
			db.Categories.Add(category6);
			db.SaveChanges();

			#endregion
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Categories] OFF");

			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Articles] ON");
			if (db.Articles.Any())
			{
				return;
			}
			#region Articles 
			var article1 = new Article
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 0, 0),
				AddedBy = "marco",
				CategoryId = category6.Id,
				Title = "Top 10 of brewing methods",
				Abstract = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec euismod. Donec quis risus malesuada ipsum suscipit euismod. Fusce gravida lectus non arcu. Aenean dignissim luctus nisl. Maecenas metus.",
				Body = @"<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Cras mollis. <u>Praesent euismod diam id mauris.</u> Ut adipiscing, magna quis interdum fermentum, nibh nulla iaculis libero, at ultrices mi lorem eget felis. Quisque sodales vehicula nibh. <strong>Proin sed erat. Quisque pretium. Nullam dignissim.</strong> Nunc non odio. <font style='BACKGROUND - COLOR: #ccffff' color='#ff0000'>Donec gravida, augue id posuere interdum, dui nulla congue lacus, id sagittis tortor diam nec sem.</font> Donec felis quam, vestibulum interdum, lobortis eget, elementum eu, sem. <font color='#000080'>Nullam placerat dignissim lorem.</font> Nulla molestie, augue sed feugiat mattis, libero odio venenatis tellus, sit amet fermentum nisl nisl et lectus. <em>Pellentesque fermentum iaculis libero. Proin fringilla elementum lectus. <strong>Donec mi nulla</strong>, commodo nec, eleifend ac, pretium eu, felis. Integer nec libero non nisi pretium mollis.</em> Donec volutpat justo semper ante. Phasellus faucibus dapibus neque. Ut eu mauris ac nisi suscipit interdum. <img alt='' src='/TheBeerHouse/FCKeditor/editor/images/smiley/msn/wink_smile.gif' /></p>",
				Country = "",
				State = "",
				City = "",
				ReleaseDate = new DateTime(2005, 9, 3, 13, 1, 0),
				ExpireDate = DateTime.MaxValue,
				Approved = true,
				Listed = true,
				CommentsEnabled = true,
				OnlyForMembers = false,
				ViewCount = 23,
				Votes = 1,
				TotalRating = 3
			};
			var article2 = new Article
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 14, 0),
				AddedBy = "marco",
				CategoryId = category1.Id,
				Title = "Drink & Food contest",
				Abstract = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed sed leo vitae odio varius aliquet. Suspendisse potenti. Maecenas nulla ligula, pretium ac posuere. Don't miss it!",
				Body = "<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Ut laoreet tempor enim. Vestibulum purus neque, nonummy vel, eleifend vitae, laoreet sed, dolor. Maecenas adipiscing, ante ut consequat hendrerit, diam dolor malesuada nisi, ut auctor mi massa id nisi. Donec id ligula. Mauris vitae ipsum. Cras vitae enim. Aenean tellus. Maecenas consectetuer, mi id cursus ultrices, pede velit rhoncus metus, non hendrerit nulla orci vel nisi. Nullam adipiscing lacus at metus. Nam lorem. Sed pede ipsum, accumsan a, varius eu, facilisis eget, velit. Ut sit amet sapien. In ut velit. Proin laoreet, nibh at scelerisque pretium, dui velit tristique nulla, nec consectetuer magna ante euismod metus. Sed in eros. Ut magna mi, commodo nec, bibendum eget, suscipit nec, quam. Maecenas in velit. Ut turpis. Nunc sed lacus a risus rhoncus adipiscing. <img src=' / TheBeerHouse / FCKeditor / editor / images / smiley / msn / wink_smile.gif' alt='' /></p>< p >< strong > Ut urna lacus,convallis ut,sodales nec,consequat ac,metus.Nam lacinia.Nunc porta dolor sed quam.</ strong > Suspendisse dictum orci ac augue.Pellentesque ac dui quis urna vehicula commodo.Morbi et libero eu enim interdum dignissim.Nam molestie magna ac eros.Maecenas tincidunt congue < font color = '#ff00ff' > ipsum </ font >.Nulla ac diam.Aenean aliquet,libero luctus sodales tempor,nisi augue ultricies dui,quis sollicitudin mauris nisl ac lacus.Sed nisl urna,ultricies quis,suscipit viverra,pharetra eu,lectus.Ut vel pede id nisi dignissim mattis.Ut gravida.Sed sed mi. </ p >< p > Nam augue orci,laoreet at,tristique in,vehicula eget,nunc.Fusce at pede.Mauris sem velit,blandit at,commodo id,ullamcorper eu,nulla.Duis vel nisl.Nullam dolor metus,luctus venenatis,fermentum in,aliquam ut,ligula.Praesent adipiscing dignissim nisi.Maecenas vehicula.Etiam luctus turpis quis nulla.Integer vel mi.Vestibulum tellus lorem,ultrices vel,faucibus et,tincidunt in,odio.Ut nisi tellus,porta a,feugiat non,porta in,erat.Sed elementum nisl sit amet felis.Suspendisse facilisis viverra lectus.Duis a tortor.Vestibulum erat. </ p >< p >< font color = '#993300' >< em >< u > Duis vitae urna in elit feugiat feugiat.In aliquet accumsan nunc.</ u ></ em ></ font > Cras vestibulum posuere orci.Aenean sit amet mi et nulla posuere posuere.Lorem ipsum dolor sit amet,consectetuer adipiscing elit.Phasellus porttitor pellentesque nibh.Curabitur quis odio.Nulla id mauris quis libero aliquet scelerisque.Maecenas nulla nunc,viverra vitae,semper quis,dictum quis,leo.Proin faucibus sem vitae mi.Morbi egestas sem vel ante. </ p >< p > Lorem ipsum dolor sit amet,consectetuer adipiscing elit.Quisque in erat.Maecenas at eros.Mauris facilisis varius nisl.Cras pulvinar molestie orci.Phasellus sed elit eget augue ultrices consectetuer.Sed sem.Nulla venenatis.Sed malesuada feugiat leo.Maecenas metus sapien,gravida sit amet,varius ac,mollis eget,enim.Aenean orci urna,elementum id,varius quis,suscipit eu,lacus.Curabitur condimentum,est id fermentum imperdiet,odio elit euismod ligula,sed mollis arcu purus at mi.Donec dictum interdum nibh.Nulla eu mi ut felis venenatis cursus.Vivamus lorem.Nam quis tellus.Sed tristique.Cras posuere dolor ac lectus.Nullam vitae lacus nec eros facilisis tincidunt. </ p >< p > Aenean sagittis.Praesent nec arcu.Nulla fringilla lacus a erat.Vestibulum est.Duis rhoncus nonummy eros.Proin ac magna interdum magna tempor bibendum.Suspendisse iaculis congue mauris.Pellentesque vitae purus.Praesent luctus,leo quis dapibus pretium,purus tortor iaculis lectus,aliquet fringilla arcu arcu sed diam.Etiam mauris.Pellentesque dui.Etiam et risus eget purus molestie venenatis.Nulla metus risus,porta vitae,commodo id,aliquet quis,mauris.Vivamus nisi.Nulla lobortis.Suspendisse potenti.Aliquam et enim.Suspendisse elementum imperdiet purus.Vestibulum metus nulla,egestas sed,feugiat interdum,scelerisque ac,augue. </ p >< p > In ligula.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Sed eu enim.Aliquam nonummy, velit id auctor rhoncus, eros lectus accumsan sem, vel fringilla nulla dui ullamcorper mauris.Suspendisse turpis quam, fringilla sed, porttitor quis, consectetuer et, tellus. Sed mattis enim et ligula.Etiam ornare nisl id lorem.Sed euismod molestie velit. Curabitur egestas, turpis fringilla dignissim consequat, turpis eros eleifend tortor, sit amet suscipit risus justo nec dui. Donec hendrerit, ante id dictum malesuada, lorem odio volutpat nunc, sed sagittis urna tellus eget ligula.Nulla venenatis, sem non lobortis fringilla, sem augue posuere nibh, vitae blandit risus enim a dui.Fusce ornare sodales neque. Praesent tincidunt mattis sem. Nulla lobortis tincidunt elit. Morbi justo orci, viverra ut, ultrices vitae, gravida a, nunc. Quisque sit amet sem vel enim molestie lobortis. Morbi tortor nisi, pharetra in, euismod quis, sagittis non, metus.Ut eu nisi.Suspendisse ultricies sapien sit amet nisl. </ p >< p > Nulla imperdiet, neque vel ultrices hendrerit, orci sem nonummy elit, et facilisis felis nibh id nibh. Praesent ante. Vestibulum venenatis. Aliquam eget justo.Cras rutrum sapien nec neque.Morbi lorem nisi, interdum et, eleifend sed, eleifend molestie, diam. Curabitur sem tellus, egestas nec, cursus eu, egestas nec, diam. In hac habitasse platea dictumst.Donec ac dolor.Cras ante. Praesent rutrum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aenean pharetra. </ p >< p > Vivamus nisi est, blandit in, facilisis et, tristique sit amet, magna.Pellentesque tincidunt. Vestibulum eleifend nonummy turpis. Pellentesque consectetuer pretium diam. Mauris ipsum. Aliquam vulputate euismod dolor. Integer a ante ac leo hendrerit adipiscing.Aenean posuere pretium sapien. Sed sagittis. Etiam congue ipsum pretium velit.Vivamus bibendum sodales ligula. Nam consequat euismod leo. Suspendisse arcu. Curabitur in erat.Vestibulum purus orci, ultrices eu, elementum vitae, tristique sed, tortor. Nullam nec tortor porta libero feugiat tempor.Sed ipsum libero, ornare id, consequat dignissim, dapibus ut, dolor. Proin cursus accumsan justo. Nullam leo. Quisque justo. </ p >< p > Nam at dui vitae lorem feugiat congue. Aenean blandit. Vivamus a ante.Quisque tellus. Maecenas ullamcorper pharetra nibh. Curabitur porta lorem vulputate erat.Mauris tempus ante non sem.Integer mauris purus, volutpat id, adipiscing a, pulvinar eget, neque. Donec ac lorem.Fusce gravida posuere nulla. Integer a lorem.Sed tempor, sem id condimentum nonummy, est nulla ultrices erat, vitae lacinia felis neque ut nibh.Quisque et magna nec odio feugiat suscipit.Donec suscipit velit aliquam dolor. </ p >< p > Fusce vitae leo sit amet ligula commodo sollicitudin.Nam condimentum leo tempus neque mollis gravida.Praesent fringilla dictum turpis. Phasellus eget mauris.Donec tincidunt, nulla ac vehicula imperdiet, urna tellus euismod justo, quis viverra quam lorem eget ligula.Duis ac. < br /></ p > ",
				Country = "Italy",
				State = "BO",
				City = "Bologna",
				ReleaseDate = new DateTime(2005, 9, 3, 12, 15, 0),
				ExpireDate = DateTime.MaxValue,
				Approved = true,
				Listed = true,
				CommentsEnabled = true,
				OnlyForMembers = false,
				ViewCount = 8,
				Votes = 1,
				TotalRating = 3
			};
			var article3 = new Article
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 16, 0),
				AddedBy = "marco",
				CategoryId = category2.Id,
				Title = "New skin online",
				Abstract = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Curabitur et turpis. Donec mollis risus non neque. Fusce elementum sem at metus. Vivamus ullamcorper, pede id turpis duis. ",
				Body = "<p>Maecenas lorem. Nulla feugiat. Nam quis sapien. In hac habitasse platea dictumst. Integer velit lectus, interdum non, condimentum nec, luctus non, neque. Proin ante. Proin nec mi quis felis rhoncus consectetuer. Nunc orci quam, fringilla ut, pretium quis, commodo vel, ante. Nullam facilisis dolor sit amet libero. Fusce mauris ante, tincidunt eu, tincidunt vitae, elementum quis, tortor. Nulla adipiscing porta elit. Pellentesque laoreet, dolor id rutrum tincidunt, nunc urna lacinia mauris, sed lobortis nisl nisi ut ligula. Phasellus tincidunt aliquam velit. Praesent euismod, elit a rhoncus sodales, mi neque dapibus justo, congue hendrerit mi enim vel odio. Vivamus arcu leo, mollis sit amet, iaculis vitae, laoreet in, eros. Ut sollicitudin lectus ac neque. </p>< p > Etiam sodales.Praesent dignissim magna.Mauris eget magna.Nulla justo lorem,sollicitudin in,scelerisque quis,iaculis sed,lorem.Lorem ipsum dolor sit amet,consectetuer adipiscing elit.Ut mi.Donec vel erat in nulla sodales fermentum.Suspendisse tortor.In mollis,sapien id eleifend interdum,arcu justo sollicitudin quam,id iaculis elit eros et magna.Phasellus auctor consectetuer erat.Quisque ornare velit quis lacus.Quisque tempus felis sit amet leo.Nullam quis justo.Vivamus varius.Nullam nonummy.Quisque rhoncus hendrerit lorem.Nullam a quam laoreet lectus vulputate dignissim.Suspendisse rutrum,risus a rutrum varius,arcu neque ullamcorper odio,ac scelerisque mi libero at ipsum.Nullam et mi.Integer fermentum blandit felis. </ p >< p > Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Cras at ipsum vitae neque tempus dictum.Nam nunc augue, iaculis a, ornare et, accumsan non, ante. Integer pulvinar. Pellentesque sagittis libero.Aenean libero augue, sodales sed, euismod at, ultricies eu, tellus. Donec turpis. Nullam augue urna, hendrerit eu, vestibulum faucibus, molestie et, lorem. Phasellus et ipsum.Phasellus tincidunt, nulla quis venenatis pulvinar, nisi erat rhoncus est, ut rhoncus tortor justo quis mauris.Nullam ipsum est, ultricies at, aliquam ac, consectetuer sed, dui. Aliquam erat volutpat. </ p >< p > Sed nonummy.Aenean elit. Nunc tempus interdum mauris. Praesent faucibus, magna vel lobortis dapibus, dolor diam suscipit purus, a elementum odio lectus sit amet mauris. Donec mollis, tortor at rutrum sodales, augue felis facilisis magna, vel cursus justo nulla sed eros.Praesent eros augue, pulvinar quis, semper mattis, luctus ut, velit. Quisque turpis risus, semper nec, lobortis sed, suscipit sit amet, sem.Quisque consequat, est eget blandit ultricies, mauris sem porttitor lectus, sit amet condimentum ligula justo a leo. Nullam augue eros, posuere sed, aliquam eget, vestibulum id, eros. Suspendisse sodales lectus ut nunc.Morbi dignissim nibh quis nibh adipiscing dictum.Ut bibendum condimentum est. Aliquam pellentesque, dui quis volutpat tempor, urna neque varius elit, at ullamcorper nulla odio eget pede.Curabitur neque. </ p >< p > Quisque urna.Ut vel nibh.Aenean ut est.Donec sagittis tellus et turpis.Sed eu urna.Integer vitae nisi.Nam nisi odio, placerat eget, tempor id, sagittis ut, ligula. Sed ac sapien.Maecenas et enim.Fusce quis mauris. </ p >< p > Cras sit amet mauris.Aliquam porta aliquam ligula. Curabitur sit amet dui eu tortor feugiat vestibulum. Phasellus et turpis quis quam mollis egestas.Proin pulvinar ligula nec felis.Pellentesque ultrices aliquet elit. Aliquam ut quam sed eros condimentum congue.Nulla egestas hendrerit pede. Nullam metus. Phasellus scelerisque, ligula at condimentum vulputate, turpis velit pellentesque nisi, non aliquet ante nunc et urna.Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. </ p >< p > Etiam id felis. Aliquam in elit posuere lectus accumsan egestas.Vestibulum at enim.In at nunc sit amet leo iaculis consectetuer. Curabitur non tellus at erat viverra tincidunt.Nullam luctus pharetra odio. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.Sed molestie orci vitae odio.Vivamus sit amet nisi. Vivamus eu lacus suscipit leo imperdiet posuere.Etiam a sem in quam consequat tincidunt.Vivamus tempus. Nullam ac mi.Integer vel ipsum nec nibh gravida pellentesque. </ p >< p > Curabitur at ante nec sapien molestie ornare. In suscipit. Vivamus orci orci, eleifend a, cursus non, tempor vel, sapien. Suspendisse pede magna, feugiat ac, ornare eu, sagittis at, turpis. Integer ligula. Fusce varius, massa placerat consequat posuere, ipsum mauris gravida neque, a aliquam pede massa ut enim.Cras tincidunt suscipit purus. Mauris viverra aliquam orci. Morbi eu purus a quam varius adipiscing.Proin at purus non nibh placerat varius. </ p >< p > Cras imperdiet mattis lectus.Praesent pulvinar bibendum enim. Sed congue est.Sed ut libero quis tellus fermentum tristique.Nullam tellus tortor, dapibus nec, ultricies sit amet, condimentum a, purus.Sed felis. Nulla vitae purus.Vestibulum urna diam, tempor a, pharetra id, tristique ut, elit. Praesent pharetra elit at magna.Duis pulvinar libero non nisl.Nulla libero enim, sollicitudin a, interdum a, placerat ac, elit. Nullam placerat diam sed lacus.Proin suscipit porta erat. Duis leo lectus, dapibus eu, viverra id, suscipit in, enim.Integer ultrices ligula vitae nulla rutrum pharetra.Ut orci. Nunc egestas. Aenean erat purus, imperdiet id, tempor quis, volutpat non, felis. Praesent suscipit. In at mi eu. < br /></ p > ",
				Country = "",
				State = "",
				City = "",
				ReleaseDate = new DateTime(2005, 9, 3, 12, 17, 0),
				ExpireDate = DateTime.MaxValue,
				Approved = true,
				Listed = true,
				CommentsEnabled = true,
				OnlyForMembers = true,
				ViewCount = 5,
				Votes = 1,
				TotalRating = 4
			};
			var article4 = new Article
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 18, 0),
				AddedBy = "marco",
				CategoryId = category2.Id,
				Title = "Photos from the Drink & Food contest",
				Abstract = "Vivamus eget massa. Nunc eget massa. Etiam eget erat ac mauris faucibus interdum. Phasellus eu risus consectetuer augue aliquet condimentum. Integer tristique risus sed ipsum. Aliquam laoreet arcu ac orci. Nam gravida. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aenean vestibulum urna ut massa. Quisque congue. Aliquam erat volutpat. Fusce venenatis turpis a lorem. Quisque ultrices, pede eget varius pharetra, orci dolor aliquam metus, sit amet venenatis magna libero eget mauris. In augue leo, rhoncus quis, feugiat in, vehicula sed, lorem. ",
				Body = "<p>Pellentesque eleifend hendrerit neque. Aliquam erat volutpat. Nulla quis ante nec diam ultricies ultricies. Aenean iaculis. In congue rhoncus massa. Quisque elementum libero. Praesent iaculis. Duis non arcu et turpis elementum accumsan. Quisque vitae quam nec velit ultrices scelerisque. Etiam justo odio, sollicitudin quis, laoreet id, tincidunt sed, velit. In hac habitasse platea dictumst. Curabitur vitae felis at leo commodo interdum. Praesent bibendum libero ut mi. Nullam viverra suscipit mi. Nulla malesuada vestibulum sapien. Duis tortor. Fusce in lectus. Aliquam lorem nunc, euismod vel, dapibus vel, fermentum eget, leo. <img src=' / TheBeerHouse / FCKeditor / editor / images / smiley / msn / thumbs_up.gif' alt='' /></p>< p >< font style = 'BACKGROUND-COLOR: #808080' color = '#ffff00' > Etiam tristique orci.In hac habitasse platea dictumst.Ut laoreet,lorem vel accumsan dictum,mauris dui dignissim elit,ut feugiat nulla leo vitae neque.Aliquam imperdiet tempus leo.Aenean ullamcorper sapien et augue fermentum volutpat.Suspendisse massa neque,tincidunt non,laoreet nec,semper vitae,dolor.Maecenas venenatis.Mauris molestie egestas neque.Curabitur egestas est semper dui.Phasellus nec sem vel risus dictum viverra.</ font > </ p >< p > Maecenas accumsan nisi aliquam mi.Etiam velit nibh,bibendum eget,vulputate in,mattis in,ipsum.Suspendisse tincidunt.Phasellus lectus dolor,pretium eget,fringilla vel,consequat non,nibh.Ut tempus tincidunt velit.Duis fringilla,urna ut rhoncus congue,est augue porttitor nibh,eget fringilla ligula nisi non lectus.Sed feugiat urna eu urna.Donec congue pellentesque lectus.In erat metus,scelerisque consectetuer,tincidunt non,tristique sed,lacus.Aenean odio quam,bibendum in,nonummy eget,hendrerit at,justo.Morbi id orci vel odio consectetuer tincidunt.Cras ornare,metus feugiat ultrices vulputate,quam arcu mattis magna,non gravida odio ante eu mauris.Nullam vestibulum.Integer semper dignissim pede.Nunc pede ante,fringilla ac,tempor interdum,suscipit sed,pede. </ p >< p > Vestibulum diam.Curabitur velit lorem,fringilla at,suscipit a,pharetra sit amet,purus.Donec tempor,augue in sagittis malesuada,lacus nibh convallis elit,eget ultrices nibh dolor vel eros.Ut erat tortor,convallis non,condimentum non,semper sit amet,ligula.Cras gravida orci ut dolor.Integer elementum purus vel felis.Cras nonummy felis non odio.In in diam.Ut lobortis dolor at augue.Vivamus lorem dolor,iaculis a,posuere a,sodales a,ligula.Etiam vitae purus ullamcorper libero tincidunt lobortis.Nulla consectetuer neque eu metus.Donec elementum placerat elit.Nulla lorem ante,vehicula vel,imperdiet ac,sollicitudin quis,lorem.Integer ut libero. </ p >< p > &nbsp;</ p > ",
				Country = "Italy",
				State = "BO",
				City = "Bologna",
				ReleaseDate = new DateTime(2005, 9, 3, 12, 19, 0),
				ExpireDate = DateTime.MaxValue,
				Approved = true,
				Listed = true,
				CommentsEnabled = true,
				OnlyForMembers = true,
				ViewCount = 0,
				Votes = 0,
				TotalRating = 0
			};
			var article5 = new Article
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 20, 0),
				AddedBy = "marco",
				CategoryId = category3.Id,
				Title = "I'm going to vacation at last",
				Abstract = "Nulla facilisi. Duis euismod nulla et lorem. Aenean dui. Aenean vel justo eget est tempus ornare. Vivamus et orci vitae urna rhoncus nonummy. Nulla tempor augue. Maecenas tincidunt eros sed nisi. Etiam rutrum ante fermentum orci. Cum sociis natoque penatibus et magnis dis parturient montes volutpat. ",
				Body = "<p>Nunc ultricies, ante ac adipiscing accumsan, est dui aliquet lectus, ut vestibulum tellus elit in augue. Pellentesque tempor mollis odio. Duis rutrum tempus enim. Pellentesque sit amet enim eu dui tempus interdum. Ut tincidunt rutrum urna. Sed auctor ipsum non mauris. Cras tincidunt risus eget velit. Mauris id erat vel enim congue accumsan. Quisque lacus neque, porta posuere, aliquet vitae, dignissim quis, elit. Nam laoreet turpis sed tellus. Etiam bibendum. Proin vitae nunc sodales tellus feugiat luctus. Pellentesque odio. Nam nec turpis sed arcu hendrerit adipiscing. Morbi sodales consequat erat. Vestibulum eu nisl. Proin gravida sollicitudin sem. Sed nec purus ac diam scelerisque semper. Nulla malesuada elementum elit. </p>< p > Morbi euismod mauris eu elit.Suspendisse porta lacinia purus.Integer accumsan.Curabitur luctus nisi et dolor.In hac habitasse platea dictumst.Proin eros libero,hendrerit sit amet,dapibus in,tincidunt vel,mauris.Praesent id dui.Nunc diam.Morbi eros mi,varius eu,pretium interdum,laoreet eu,arcu.Aliquam rhoncus.In hac habitasse platea dictumst.Nullam commodo cursus turpis.Etiam non purus quis justo lacinia condimentum.Donec quis tellus a massa lacinia sollicitudin. </ p >< p > Vivamus tempor massa a nunc.Sed mi.Etiam sed tellus.Nam eget sapien nec tellus sodales vehicula.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Phasellus et diam et mi gravida vulputate.Sed ultricies tortor.Nullam varius feugiat libero. Cras diam est, aliquam vitae, nonummy sed, viverra eleifend, metus. Nulla ut mi.Cras at nulla.Donec convallis. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Praesent feugiat condimentum tellus. </ p >< p > Fusce sit amet arcu sit amet felis porta bibendum. Donec tristique, risus vel malesuada auctor, diam est elementum erat, nec congue enim ligula non turpis.Nullam venenatis aliquam sem. Cras porta, nisl ut varius malesuada, arcu ligula malesuada magna, id malesuada dolor est eleifend sapien.In lobortis posuere mi. Nulla rutrum sem at eros.Duis mauris. Vivamus sed sem.Morbi sapien mi, nonummy a, lobortis sit amet, ornare ornare, elit.Nulla at nunc.Mauris ultricies interdum nulla. Quisque sem. Nam arcu. Suspendisse consectetuer. Nunc ac ligula id nisi dapibus porttitor.Nulla sit amet quam. </ p >< p > Donec sed tellus non ipsum volutpat lobortis. Sed quis velit.Etiam scelerisque facilisis sapien. Nunc a sem.Sed tempus luctus orci. Morbi consectetuer nibh aliquam tortor fermentum ultrices.Nullam gravida scelerisque eros. Suspendisse sed velit.Vestibulum ullamcorper justo et felis.Integer eget pede.Nunc at massa quis justo tempor varius.Sed in turpis sed lorem condimentum iaculis.Vivamus sagittis gravida augue. Duis vitae enim at nulla commodo posuere.Suspendisse mattis. </ p >< p > Fusce in mi non orci condimentum fringilla.Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Phasellus tincidunt quam.Phasellus sit amet eros ac orci iaculis facilisis. Aenean et ligula.Phasellus euismod blandit arcu. Etiam eu metus quis massa vehicula rutrum.Phasellus fringilla neque et leo.Ut nunc. Praesent tempor, tellus sit amet vehicula sodales, dolor augue dignissim velit, sit amet venenatis mi eros non neque.Sed convallis eleifend augue. Morbi neque risus, porta. < br /></ p > ",
				Country = "",
				State = "",
				City = "",
				ReleaseDate = new DateTime(2005, 9, 3, 12, 21, 0),
				ExpireDate = DateTime.MaxValue,
				Approved = true,
				Listed = true,
				CommentsEnabled = true,
				OnlyForMembers = false,
				ViewCount = 3,
				Votes = 0,
				TotalRating = 0
			};
			var article6 = new Article
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 22, 0),
				AddedBy = "marco",
				CategoryId = category4.Id,
				Title = "Tips & Tricks for using the site",
				Abstract = "Pellentesque nibh felis, mollis sed, commodo sed, luctus id, elit. Quisque tincidunt, mi eget varius pharetra, lectus diam sollicitudin sem, non mollis orci nibh a ipsum. Donec non nulla porttitor sapien bibendum scelerisque amet.",
				Body = "<p>Sed ut ligula. Vivamus nec nulla. Aliquam vestibulum, diam consectetuer posuere suscipit, ipsum dui accumsan ipsum, sit amet iaculis nunc eros et nisl. Nunc vitae augue sit amet neque tempor elementum. Fusce molestie, mi eu ultricies fringilla, orci quam ultricies nunc, eu posuere erat odio vitae libero. Fusce eu erat. Aliquam erat volutpat. Nunc neque mi, fermentum eu, eleifend a, porta ac, justo. Donec euismod. Nulla facilisi. </p>< p > Donec nulla.Nulla pellentesque libero sit amet massa.Aliquam erat volutpat.Suspendisse leo mauris,fringilla ut,consequat a,eleifend eget,sem.Phasellus viverra,diam nec rutrum ornare,est purus tincidunt quam,at ultricies augue sem sit amet quam.Morbi eu nulla.Ut mollis nonummy velit.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aenean cursus pede quis neque iaculis tincidunt.Pellentesque nisi lectus, lobortis nec, imperdiet ac, gravida id, nibh. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc posuere, felis quis ultricies tincidunt, ante libero luctus massa, quis accumsan sapien massa vitae velit. </ p >< p > Fusce nec metus et enim placerat interdum. Nunc scelerisque. Maecenas id magna vitae sapien mattis hendrerit.Mauris eget augue at ipsum vehicula imperdiet.Nam lacinia. In porttitor, nisi eu porta ultrices, magna leo suscipit enim, eget viverra quam lorem quis tortor.Morbi sagittis, nibh et vulputate egestas, ipsum neque fermentum orci, nec dictum risus nulla semper ante.Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Fusce est ipsum, bibendum ac, semper sed, varius quis, tellus. Fusce feugiat. Aenean purus pede, rutrum eget, consectetuer vel, interdum nec, felis. Aenean ipsum quam, tincidunt ac, cursus eget, eleifend eget, ligula. Morbi scelerisque, dui non elementum porta, pede leo posuere elit, ut rhoncus quam ante vel est. </ p >< p > Curabitur volutpat lectus ac leo. Etiam placerat ornare nisi. Aliquam eu leo id ligula scelerisque suscipit.Fusce condimentum metus.Fusce sodales, nunc sed placerat gravida, sem nisi condimentum urna, sed tincidunt elit nisi at ante.Nam tortor nisl, pretium et, dapibus consectetuer, pulvinar id, ligula. Proin varius ligula a lorem.Quisque quam orci, elementum nec, tempus egestas, mattis eu, lectus. Quisque quis massa nec nisi vulputate lobortis.Cras sed quam.Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Nam venenatis ullamcorper neque. Morbi non lorem eu mi ultricies iaculis.Cras ac tellus.Mauris eget augue suscipit enim lobortis viverra.Aliquam in leo.Suspendisse potenti. </ p >< p > Mauris mollis risus ut justo. Maecenas vestibulum nisi sit amet ante. Nulla facilisi. Nunc malesuada cursus libero. Morbi in enim sit amet quam egestas suscipit. Sed sollicitudin diam tincidunt velit.Praesent libero. Maecenas elementum. Donec tempus. Nam dignissim. Curabitur mattis metus aliquet tortor.Morbi lacus sem, blandit sed, tempor ac, sagittis eu, sem. </ p >< p > Aliquam pretium.Ut ultrices est faucibus orci.Sed ut leo at magna fermentum luctus.Quisque sollicitudin nunc eget ligula.Maecenas rhoncus quam ac libero.Proin id lectus vitae quam bibendum aliquet.Nunc interdum, libero sed ultricies imperdiet, justo lacus dapibus metus, sit amet feugiat felis odio faucibus ligula. Nulla neque. Pellentesque ac nunc quis lacus mattis viverra.Etiam mollis, ipsum ac condimentum suscipit, quam nibh venenatis nisi, non mollis magna leo et odio.Sed eget magna.Maecenas quis nulla sed elit bibendum tincidunt.Aliquam erat volutpat. </ p >< p > Etiam et ligula in enim pharetra imperdiet.Aliquam diam. Proin sodales nisl ultricies elit.Duis pulvinar mollis enim. Duis posuere sollicitudin diam. Aenean faucibus lobortis nisl. Suspendisse nec velit.Morbi nulla nulla, iaculis at, volutpat at, varius et, dolor. Praesent pretium, diam quis sodales facilisis, justo quam vestibulum nisi, id elementum metus nisi ut quam.Nunc blandit sapien congue neque.Ut et nisl.Proin velit ante, porta at, rhoncus non, pretium nec, leo. Maecenas blandit ullamcorper pede. </ p >< p > Maecenas in diam et elit pharetra pharetra.Aenean luctus semper neque. Praesent sit amet augue. Duis tempor nunc at nunc.Nullam hendrerit aliquet pede. Integer iaculis dolor placerat ipsum.Vestibulum elementum hendrerit arcu. Vestibulum a dui.Aliquam nunc. Duis. </ p > ",
				Country = "",
				State = "",
				City = "",
				ReleaseDate = new DateTime(2005, 9, 3, 12, 23, 0),
				ExpireDate = DateTime.MaxValue,
				Approved = true,
				Listed = true,
				CommentsEnabled = true,
				OnlyForMembers = false,
				ViewCount = 3,
				Votes = 1,
				TotalRating = 5
			};
			var article7 = new Article
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 24, 0),
				AddedBy = "marco",
				CategoryId = category5.Id,
				Title = "Dictionary of special terms",
				Abstract = "Sed aliquam rutrum mauris. Cras eu justo sit amet magna placerat porta. Proin rutrum imperdiet ante. Etiam eu neque. Integer diam sem, accumsan metus. ",
				Body = "<p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Quisque metus. Suspendisse ipsum. Integer scelerisque erat id felis. Nunc semper mattis sapien. Quisque quis ante. Praesent imperdiet metus vitae lorem. Maecenas at tortor in justo facilisis egestas. Nulla venenatis, lectus sit amet venenatis scelerisque, augue lorem euismod pede, at facilisis purus magna eget sapien. Ut sapien libero, porta non, tincidunt id, fringilla in, nunc. Etiam in lacus. Donec condimentum ullamcorper enim!</p>< p > Praesent ipsum felis,elementum nec,tincidunt in,nonummy in,justo.Aliquam at lorem sed dui dictum accumsan.Nunc sodales elementum sapien.Suspendisse imperdiet dui egestas risus.Morbi blandit dolor eu mi fringilla lacinia.Duis condimentum suscipit lectus.Etiam id quam.Mauris sed leo sit amet sem dapibus condimentum.Praesent porta diam nec nisl suscipit nonummy.Curabitur volutpat,nulla et hendrerit tristique,erat nulla viverra elit, in lacinia tortor tortor quis erat. </ p >< p > Maecenas convallis ante eleifend nulla.Duis ac est.Vestibulum iaculis varius pede.Class aptent taciti sociosqu ad litora torquent per conubia nostra,per inceptos hymenaeos.In mauris est,elementum vitae,fringilla non,dignissim eu,nunc.Curabitur ullamcorper venenatis purus.Etiam et pede.Curabitur quis orci.Suspendisse nec justo.Nulla adipiscing leo ullamcorper purus egestas sollicitudin.Aliquam ac pede.Pellentesque viverra,erat ut blandit ornare,nisl turpis suscipit orci,vitae tristique lorem metus sit amet tellus.Morbi nec mauris.Aliquam erat volutpat.Integer sem ante,consectetuer in,lobortis ac,suscipit nec,arcu.Donec quis libero.Sed ac odio.Integer et metus in massa bibendum bibendum.Donec lacinia,metus quis ultricies pellentesque,velit mauris nonummy metus,ac mollis metus nisl eu justo. </ p >< p > Nam pede tortor,mollis sit amet,volutpat sed,aliquam vitae,nisl.Aliquam dignissim,arcu ut ullamcorper condimentum,mauris felis interdum sem,sit amet posuere mauris velit quis erat.Aliquam adipiscing pede nec quam facilisis vestibulum.Lorem ipsum dolor sit amet,consectetuer adipiscing elit.Nam aliquet accumsan pede.Lorem ipsum dolor sit amet,consectetuer adipiscing elit.Nulla egestas tortor non eros.Suspendisse tristique.Cras tristique bibendum velit.Quisque tristique mi quis justo.Pellentesque orci dolor,imperdiet et,vulputate interdum,fermentum et,orci.Curabitur feugiat. </ p >< p > Vestibulum nonummy fermentum pede.Nam lobortis purus a dui.Ut bibendum.Donec tempor nunc ut mauris.Fusce at elit.Nullam placerat posuere lacus.Nam rutrum pretium est.Cras id ligula.Donec viverra,ipsum nec viverra vulputate,diam purus lobortis velit,sed dignissim elit dolor in nisi.Curabitur ornare turpis vel turpis.Cras et purus vitae risus facilisis suscipit. </ p >< p > Aliquam ultrices porta urna.Suspendisse ornare,turpis nec lacinia laoreet,leo eros feugiat neque,a consequat justo est sed orci.Nam non pede.Suspendisse sapien.Praesent ac enim eget nisi condimentum aliquam.In hac habitasse platea dictumst.Praesent bibendum.Aenean quam velit,accumsan cursus,pulvinar nec,vestibulum eu,lacus.Praesent eu nibh ut erat pulvinar gravida.Integer ante ligula,iaculis in,vestibulum ut,aliquam sit amet,purus.Morbi lacinia.Maecenas libero lorem,imperdiet vitae,lacinia et,nonummy nec,pede.Aliquam erat volutpat.Duis dui eros,porta ut,vulputate eget,elementum non,tortor.Cum sociis natoque penatibus et magnis dis parturient montes,nascetur ridiculus mus.Nullam posuere fringilla est. </ p >< p > Fusce convallis.Pellentesque ut sapien.Morbi ultricies,lacus porta consequat placerat,urna nunc convallis sem,non varius velit arcu a tortor.In lacus.Suspendisse eget felis.Pellentesque neque massa,tincidunt sit amet,vehicula in,commodo eget,sem.Sed volutpat.Cras et lorem.In fermentum mollis est.Curabitur sollicitudin tristique risus.Suspendisse ut urna vitae augue egestas pretium.Suspendisse potenti.Vestibulum mi erat,lacinia ut,feugiat quis,dignissim a,lectus.Nullam et magna vel felis dignissim auctor. </ p >< p > Lorem ipsum dolor sit amet,consectetuer adipiscing elit.Aenean sed lectus.Nulla quis tellus.Nam tincidunt sapien nec eros.Aliquam sodales,mi at faucibus lacinia,sem diam porta eros,vitae viverra felis sapien ut enim.Ut vestibulum facilisis augue.Praesent tincidunt gravida diam.Phasellus vestibulum sodales ipsum.Maecenas euismod ipsum laoreet leo.Praesent enim leo,malesuada id,pellentesque at,vulputate sit amet,lorem.Aliquam dignissim tempor risus.Suspendisse euismod nisi in nunc.Nunc pretium tempus nunc.Nulla sed pede et purus venenatis imperdiet. </ p >< p > In eu quam non mi pellentesque dignissim.Morbi eu massa.Aenean lectus.Phasellus ornare odio in massa.Aliquam bibendum fermentum neque.Donec eros sapien,ultrices sit. </ p > ",
				Country = "",
				State = "",
				City = "",
				ReleaseDate = new DateTime(2005, 9, 3, 12, 25, 0),
				ExpireDate = DateTime.MaxValue,
				Approved = true,
				Listed = true,
				CommentsEnabled = true,
				OnlyForMembers = false,
				ViewCount = 8,
				Votes = 1,
				TotalRating = 4
			};
			var article8 = new Article
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 26, 0),
				AddedBy = "marco",
				CategoryId = category5.Id,
				Title = "Special Irish concert - FREE",
				Abstract = "Donec accumsan justo iaculis metus. Quisque faucibus orci et purus. Morbi metus. Vivamus vel pede. Aenean aliquam sapien nec nisl. Proin eu enim a ante viverra fermentum. Suspendisse rutrum, sapien convallis fermentum sagittis, nibh augue mattis felis, vel mattis augue ligula id nisl nullam sodales. ",
				Body = "<p>Morbi lorem ipsum, euismod id, convallis nec, mattis sed, dolor. In tempus pede quis lorem. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum rhoncus. Phasellus sollicitudin, orci commodo feugiat bibendum, dolor lorem viverra diam, non luctus odio diam in risus. Donec est tellus, mollis sit amet, sollicitudin id, molestie vitae, enim. Duis non enim. Sed vel magna ac dui pellentesque suscipit. In fringilla nisl non nisl. Integer augue quam, vulputate sit amet, volutpat nec, suscipit at, magna. Vivamus rhoncus ultrices arcu. Suspendisse tempor est vitae tortor. </p>< p > Etiam facilisis.Proin nec magna at orci posuere ullamcorper.Aliquam cursus ligula eu eros.In risus.Pellentesque enim arcu,adipiscing sed,laoreet ac,ultrices ac,tellus.Quisque venenatis sapien non nunc.Donec non tellus.Fusce a augue sit amet sapien pharetra pulvinar.Duis imperdiet,enim et facilisis blandit,arcu nisi elementum mi,quis adipiscing eros enim a dolor.Nunc a ligula et tellus nonummy fermentum.Proin congue diam in libero.Nam felis nisl,porta sed,accumsan posuere,varius vitae,nisl.Vivamus ac dui in nisi venenatis suscipit.Maecenas lacinia,ipsum in porttitor accumsan,nisl arcu interdum mauris,vitae tempor est ante nec risus.In hendrerit sapien rhoncus nisi.Sed euismod libero et lectus.Etiam faucibus sapien ut sapien.Cras at tortor at massa pretium ullamcorper.Nullam ornare nulla ac libero. </ p >< p > Integer arcu arcu,dignissim eget,sodales ut,accumsan id,nunc.Etiam volutpat,augue ac interdum convallis,purus pede egestas orci,vel dignissim urna metus ut est.Phasellus lectus magna,iaculis vel,auctor ac,tempus et,justo.Curabitur ornare erat id felis.Suspendisse aliquet convallis tellus.Sed est.Quisque rhoncus.Duis blandit.Donec ut augue.Integer consectetuer viverra massa.Quisque ipsum orci,lacinia non,lobortis id,tincidunt quis,massa.Vivamus sed augue nec mauris feugiat elementum.Donec venenatis nulla ut nisi.Integer mauris dui,condimentum a,laoreet at,eleifend ut,lacus.Pellentesque vestibulum pellentesque eros.Duis euismod consequat magna.Ut et nulla.Maecenas ante erat,malesuada eget,egestas vitae,placerat ut,odio. </ p >< p > Etiam neque risus,venenatis ut,feugiat at,venenatis eget,odio.Etiam congue,dolor et iaculis ornare,velit lectus volutpat metus,pulvinar blandit mi mauris et augue.Maecenas elit eros,consequat quis,placerat eget. </ p > ",
				Country = "Italy",
				State = "BO",
				City = "",
				ReleaseDate = new DateTime(2005, 9, 3, 12, 27, 0),
				ExpireDate = DateTime.MaxValue,
				Approved = true,
				Listed = true,
				CommentsEnabled = true,
				OnlyForMembers = false,
				ViewCount = 7,
				Votes = 1,
				TotalRating = 5
			};
			var article9 = new Article
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 28, 0),
				AddedBy = "marco",
				CategoryId = category5.Id,
				Title = "Photos from the Irish concert",
				Abstract = "Vivamus lacinia placerat urna. Phasellus fringilla libero imperdiet velit. Duis aliquam tellus et velit. Donec elit ante, auctor sit amet, auctor nec, vulputate a, mi. Curabitur sed nulla ac volutpat. ",
				Body = "<p>In placerat risus id orci. Maecenas varius mattis dui. Integer nibh nibh, iaculis non, laoreet ac, fermentum vitae, sapien. Donec ut nunc in nulla condimentum mollis. Sed vulputate enim vel sem. Pellentesque blandit metus eu odio. Sed aliquet felis ac diam. Cras nec purus. Integer quis nibh. Nullam neque. Proin volutpat lectus id ante. Sed quis lorem. Maecenas placerat varius orci. Sed pretium, sapien sit amet molestie lobortis, mi velit cursus ligula, nec placerat ipsum erat ac massa. In felis dolor, euismod in, facilisis sed, blandit at, arcu. </p>< p >< font color = '#800000' > Donec nec nunc.Quisque in nulla id tellus molestie interdum.Phasellus ut ante nec nibh faucibus rutrum.Proin quam felis,commodo eget,sollicitudin a,blandit eu,diam.Pellentesque vitae enim non nisi adipiscing condimentum.Nulla quam.Phasellus risus lorem,malesuada ut,venenatis non,blandit elementum,augue.Praesent sodales turpis at est.Aenean quis turpis in mi fringilla porttitor.Quisque sit amet neque.Donec tempus.Integer leo metus,accumsan a,mattis at,facilisis quis,justo.</ font > </ p >< p >< font color = '#000080' > Proin eget sem.Cum sociis natoque penatibus et magnis dis parturient montes,nascetur ridiculus mus.Quisque ultricies aliquam lorem.Proin sed elit sagittis velit faucibus consectetuer.Phasellus sit amet elit in sem tempor sagittis.Nunc tincidunt.Maecenas nulla sem,facilisis sed,venenatis ut,dictum sit amet,velit.Donec hendrerit suscipit sapien.Fusce sagittis metus quis dui.Pellentesque sit amet massa.Maecenas a sem in mi rhoncus tempor.Morbi eleifend dui quis nisl.Donec felis.Donec porta est sit amet mauris.</ font > </ p >< p > Aenean condimentum egestas enim.Donec sit amet mauris ut ipsum ornare mollis.Suspendisse ultricies semper eros.Cras sapien.Ut sed sem id justo malesuada condimentum.Cras libero nunc,nonummy ut,mollis at,interdum ut,nunc.Praesent ac purus.Vivamus metus tellus,volutpat id,aliquet sit amet,ornare a,turpis.Pellentesque tortor sapien,convallis sed,commodo ac,tempor id,felis.Maecenas vel lacus. </ p >< p > Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Aliquam sed diam adipiscing tellus iaculis consectetuer.Vestibulum vestibulum.Curabitur vulputate,tortor a molestie dapibus,elit est tempus nisi,ut pulvinar lorem justo in arcu.Donec ut massa sed augue ornare malesuada.In hac habitasse platea dictumst.Pellentesque sollicitudin nisi sit amet lacus.Vestibulum cursus lacus accumsan neque.Sed ullamcorper arcu quis dui.Phasellus magna lacus,porttitor aliquam,condimentum eu,feugiat eu,nisi.Curabitur orci. </ p >< p > Donec at justo.Ut sit amet tellus.Etiam a dolor.In hac habitasse platea dictumst.Etiam eget eros ut mi convallis varius.Donec mauris nisi,rutrum nec,cursus quis,mattis quis,quam.Pellentesque ante.Morbi feugiat,sapien vel adipiscing vehicula,est neque feugiat tortor,eget malesuada lectus risus non enim.Integer porta facilisis nisl.Pellentesque et dui in pede euismod adipiscing.Class aptent taciti sociosqu ad litora torquent per conubia nostra,per inceptos hymenaeos.Sed vel dolor sit amet libero consequat gravida.Suspendisse nisi risus,porttitor in,elementum eu,rutrum vel,est.Phasellus lobortis.Integer at nulla in arcu malesuada adipiscing.Sed vehicula eleifend ligula.Aliquam arcu nisl,tristique ut,ultrices at,tincidunt a,purus.Proin venenatis auctor mi. </ p >< p > Cum sociis natoque penatibus et magnis dis parturient montes,nascetur ridiculus mus.Sed viverra risus nec sapien.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc tincidunt consequat nisi. Sed tincidunt nunc vel velit.Maecenas vestibulum lorem.Mauris vulputate magna id eros.Nullam tincidunt justo.Quisque eget dolor sit amet metus sagittis sagittis. Mauris viverra lacus id dolor.Vestibulum faucibus, quam in tincidunt tincidunt, mi orci dapibus nunc, ut vehicula nisi nunc ut ante. Aliquam sed enim.Nam tincidunt, nulla quis malesuada ullamcorper, risus elit nonummy nulla, et aliquet sem nisi sit amet elit. Vestibulum luctus tincidunt odio. Praesent tristique vehicula erat. Duis at augue. </ p >< p > Duis blandit blandit nunc.Praesent eleifend viverra urna. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.Cras a enim.Maecenas vulputate lectus non eros.In lorem eros, mollis eu, euismod a, fringilla ut, felis. Quisque sem. Phasellus erat dui, sodales fermentum, nonummy ac, vestibulum ut, nisi. Duis commodo viverra nulla. Etiam eleifend augue vel lorem.In volutpat elementum tellus. Nam arcu purus, gravida a, gravida eget, mattis nec, velit. In massa libero, tincidunt et, facilisis at, ultrices id, elit. Integer vitae elit.Suspendisse ut sapien. </ p >< p > Pellentesque urna tortor, posuere quis, rhoncus at, tincidunt in, ante. Aenean lectus leo, varius vel, tincidunt a, fermentum sit amet, elit.Vestibulum rutrum ipsum eu arcu.Integer gravida dolor et urna.Quisque metus felis, cursus vitae, ullamcorper nec, imperdiet in, turpis.Suspendisse quam. Nullam condimentum, elit id tincidunt sagittis, mi leo ornare lacus, in porta libero nisl in diam.Aenean condimentum odio vitae eros.Vestibulum facilisis. Donec ut felis.Nunc non justo. </ p >< p > Nunc eros enim, molestie ut, faucibus eget, tempus sit amet, libero. Cras in quam ac ligula venenatis consectetuer.Pellentesque eget magna nec lorem convallis pellentesque.Praesent aliquet, massa non porttitor tempus, nisl nisl interdum pede, eget suscipit nisi lectus iaculis ipsum.Mauris sem magna, sagittis at, aliquam vulputate, porta sed, odio. Vivamus mattis dolor a nisi.Nunc lobortis nonummy dolor. Suspendisse mauris mi, rutrum et, ornare non, tempor sed, diam. Phasellus egestas diam a risus vestibulum pretium.Aliquam non nunc.Cras interdum bibendum dolor. Pellentesque sollicitudin purus ut dui scelerisque ultricies.Mauris sem nunc, cursus non, egestas id, volutpat sit amet, mi.Vivamus metus. Fusce a sapien. </ p >< p > Aenean adipiscing.Vestibulum et pede ac sapien sollicitudin luctus.Mauris lectus arcu, imperdiet ac, hendrerit eget, pharetra id, erat. Donec tempus felis at urna.Donec congue tristique ante. Proin dignissim porta enim. Ut a libero.Proin lorem justo, iaculis eu, elementum sit amet, consequat sit amet, mi. Quisque posuere lorem at augue.Morbi dui justo, pellentesque in, ultrices at, venenatis sit amet, purus. Nulla facilisis libero et lorem tincidunt molestie.Duis nec pede.Nam quis urna.Vestibulum aliquet adipiscing nulla. Proin luctus. Cras eu felis non velit viverra pretium. </ p >< p > Proin rhoncus dapibus velit.Integer eget orci sed nunc cursus ullamcorper.Sed aliquam ante eget massa.Nullam quis lacus.Nam congue fermentum diam. Nam ac tortor sit amet lectus vestibulum scelerisque. Integer at tellus.Etiam lorem ante, lobortis vel, viverra eu, consequat id, lorem. Nunc orci. Fusce sollicitudin bibendum turpis. Sed adipiscing. In faucibus, felis ut ullamcorper iaculis, felis felis mollis enim, a dapibus arcu elit ut sem. </ p >< p > Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Mauris sit amet augue vel velit tristique fermentum. Donec eu neque.Sed congue dapibus erat. Integer molestie adipiscing dolor. Integer eget ipsum congue dolor fermentum euismod.Sed lacinia, diam et sollicitudin porta, sapien ante blandit quam, vel mollis turpis tellus a enim.Suspendisse nisi magna, luctus ac, tempus at, interdum sed, risus. Proin non ante.Aenean semper quam quis leo.Vestibulum vitae elit non tortor imperdiet sagittis.Vivamus sem orci, tempus a, facilisis eu, blandit sit amet, lorem.Aenean pede. Mauris rutrum lectus sit amet lectus. Nunc ipsum odio, pulvinar at, nonummy at, malesuada non, tellus. Sed fermentum cursus libero. Vestibulum pretium magna at diam.Nulla facilisi. In tempus suscipit enim. Aenean rutrum lacinia ligula. </ p >< p > Maecenas quis lorem. Mauris nulla enim, nonummy quis, ultricies volutpat, fermentum vel, velit. Sed pulvinar, nisi in egestas feugiat, eros odio congue arcu, vitae posuere sapien nibh at libero. Fusce mollis tortor interdum nisi.Quisque feugiat cursus velit. Phasellus ut risus vel eros aliquam euismod.Curabitur ante. Phasellus hendrerit odio eget dui.Aenean egestas fermentum dolor. Pellentesque dictum, lacus ut tincidunt commodo, tortor purus tincidunt felis, at iaculis nisl erat dapibus sem.Nullam nonummy quam ut nibh.In et pede.Nunc semper justo ut est.In sodales velit et nunc.Suspendisse venenatis, velit quis porta convallis, massa turpis tincidunt massa, id convallis dolor neque in elit. </ p >< p > Integer pede metus, pharetra id, gravida eget, egestas vel, nunc.Curabitur egestas lectus non neque.Vivamus erat nisi, fermentum in, congue eu, consequat eu, leo.Proin rhoncus ipsum vitae leo luctus adipiscing.Quisque a sem nec est porta ornare.Cras ac pede.Aenean dictum, nisl at tristique mollis, purus velit accumsan orci, a dapibus massa felis vel ante.Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Aenean et metus sed turpis molestie imperdiet.Etiam imperdiet volutpat orci. In posuere magna nec ligula.Vivamus hendrerit ultrices nisl. Pellentesque id neque.Nullam euismod fermentum mi. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Sed malesuada leo sed est.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Vivamus luctus est in nisl.Sed eget. </ p > ",
				Country = "Italy",
				State = "BO",
				City = "",
				ReleaseDate = new DateTime(2005, 9, 3, 12, 29, 0),
				ExpireDate = DateTime.MaxValue,
				Approved = true,
				Listed = true,
				CommentsEnabled = true,
				OnlyForMembers = true,
				ViewCount = 4,
				Votes = 1,
				TotalRating = 5
			};
			var article10 = new Article
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 30, 0),
				AddedBy = "marco",
				CategoryId = category6.Id,
				Title = "Weekend in Dublin",
				Abstract = "Sed vel dui et tellus mollis pellentesque. Vestibulum consectetuer tincidunt odio. Nam auctor, justo vel auctor congue, quam eros ullamcorper ante, rutrum vestibulum elit risus a ante. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Cras nec velit sed urna amet. ",
				Body = "<p>Suspendisse potenti. Aliquam in sem eu eros ultricies commodo. Quisque interdum imperdiet lorem. Nam euismod nibh vel ligula vulputate sollicitudin. Pellentesque nec magna vel diam blandit viverra. Etiam convallis orci congue odio. Morbi lobortis. In id libero. Integer a leo eget pede tincidunt convallis. Sed ac leo. Nulla facilisi. Aenean sagittis rutrum est. Mauris imperdiet ligula nec pede ornare porttitor. Phasellus sodales, pede id rutrum adipiscing, odio tortor lobortis purus, in adipiscing mi est eget tortor. Pellentesque ut orci. Phasellus consectetuer, metus id hendrerit ornare, ligula tortor varius metus, eget interdum nunc diam id elit. </p>< p > Vivamus adipiscing consectetuer mauris.Aliquam erat volutpat.Suspendisse potenti.Praesent porttitor metus hendrerit lorem.Cras vitae ipsum quis nisi venenatis imperdiet.Praesent ornare nulla non lorem ultrices fringilla.Suspendisse potenti.Ut tempor,neque a accumsan elementum,elit lectus adipiscing lacus,vel blandit augue neque viverra leo.Nullam pharetra interdum odio.Sed malesuada turpis at eros.Sed aliquet varius velit.Praesent ac dolor.Proin odio.& nbsp; < img src = '/TheBeerHouse/FCKeditor/editor/images/smiley/msn/tounge_smile.gif' alt = '' /></ p >< p > Morbi non orci eu elit vestibulum egestas. Suspendisse aliquam blandit lacus. Donec at lorem in lacus tincidunt blandit.Nulla id nibh.Vivamus non quam.Fusce nisi diam, interdum non, auctor nec, ultricies eget, diam. Nullam malesuada, mi et malesuada dignissim, nibh turpis iaculis leo, quis adipiscing velit dui ac mi.Nullam malesuada egestas orci. Sed blandit porta tellus. Donec ultricies faucibus ligula. Etiam sapien libero, auctor at, aliquet ac, eleifend id, mi. Vestibulum eleifend ornare arcu. Nullam quis magna.Duis porta pede ac lacus.Vivamus commodo, est vel dignissim tincidunt, ligula lectus gravida lectus, nec condimentum ante magna mollis quam. </ p >< p > Morbi at nisi sit amet orci suscipit volutpat.Nam interdum bibendum nulla. Ut tempus, nisi et luctus vestibulum, eros nisi pretium tortor, ac tempor justo quam non nulla.Donec nec lectus ac turpis commodo euismod.Sed elementum pellentesque eros. Nulla facilisi. < br /></ p > ",
				Country = "",
				State = "",
				City = "",
				ReleaseDate = new DateTime(2005, 9, 3, 12, 31, 0),
				ExpireDate = DateTime.MaxValue,
				Approved = true,
				Listed = true,
				CommentsEnabled = true,
				OnlyForMembers = false,
				ViewCount = 11,
				Votes = 1,
				TotalRating = 4
			};
			db.Articles.Add(article1);
			db.Articles.Add(article2);
			db.Articles.Add(article3);
			db.Articles.Add(article4);
			db.Articles.Add(article5);
			db.Articles.Add(article6);
			db.Articles.Add(article7);
			db.Articles.Add(article8);
			db.Articles.Add(article9);
			db.Articles.Add(article10);
			db.SaveChanges();


			#endregion
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Articles] OFF");

			if (db.Comments.Any())
			{
				return;
			}
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Comments] ON");
			#region Comments

			var comment1 = new Comment
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 22, 36),
				AddedBy = "marco",
				AddedByEmail = "a1@mail.ru",
				AddedByIp = "127.0.0.1",
				ArticleId = article1.Id,
				Body = "Best concert ever! Thanks!"
			};
			var comment2 = new Comment
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 22, 36),
				AddedBy = "marco",
				AddedByEmail = "a1@mail.ru",
				AddedByIp = "127.0.0.1",
				ArticleId = article2.Id,
				Body = "Thanks for the help"
			};
			var comment3 = new Comment
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 22, 36),
				AddedBy = "marco",
				AddedByEmail = "a1@mail.ru",
				AddedByIp = "127.0.0.1",
				ArticleId = article2.Id,
				Body = "Wow, this article rocks!"
			};
			var comment4 = new Comment
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 22, 36),
				AddedBy = "jan",
				AddedByEmail = "a1@mail.ru",
				AddedByIp = "127.0.0.1",
				ArticleId = article2.Id,
				Body = "What about stout beers?"
			};
			var comment5 = new Comment
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 22, 36),
				AddedBy = "jeff",
				AddedByEmail = "a1@mail.ru",
				AddedByIp = "127.0.0.1",
				ArticleId = article4.Id,
				Body = "Not bad"
			};
			var comment6 = new Comment
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 22, 36),
				AddedBy = "marco",
				AddedByEmail = "a1@mail.ru",
				AddedByIp = "127.0.0.1",
				ArticleId = article6.Id,
				Body = "I know it all now!"
			};
			var comment7 = new Comment
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 9, 3, 12, 22, 36),
				AddedBy = "Jack",
				AddedByEmail = "a1@mail.ru",
				AddedByIp = "127.0.0.1",
				ArticleId = article7.Id,
				Body = "Ahaha"
			};
			db.Comments.Add(comment1);
			db.Comments.Add(comment2);
			db.Comments.Add(comment3);
			db.Comments.Add(comment4);
			db.Comments.Add(comment5);
			db.Comments.Add(comment6);
			db.Comments.Add(comment7);
			db.SaveChanges();
			#endregion
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Comments] OFF");

			if (db.Departments.Any())
			{
				return;
			}
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Departments] ON");
			#region Departments
			var department1 = new Department
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 13, 12, 16, 14),
				Title = "Glasses",
				Importance = 0,
				Description = "Glasses of all types, to drink your beer with style!",
				ImageUrl = "~/Images/Beers.gif"

			};
			var department2 = new Department
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 15, 19, 25, 38),
				Title = "Gadgets for beer fanatics",
				Importance = 0,
				Description = "T-Shirts, caps, keychains and more nice gadgets. Find the perfect gift for yourself or your beer-fanatic friends.",
				ImageUrl = "~/Images/Tshirt.gif"
			};
			db.Departments.Add(department1);
			db.Departments.Add(department2);
			db.SaveChanges();
			#endregion
			db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Departments] OFF");

			#region Products
			//var product1 = new Product
			//{
			//	Id = Guid.NewGuid(),
			//	AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
			//	AddedBy = "Marco",
			//	DepartmentId = department1.Id,
			//	Title = "Beer Cap",
			//	Description = "<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin a tortor non dolor pulvinar adipiscing. Ut sagittis aliquet felis. In et eros id leo pulvinar suscipit. Curabitur euismod mauris ut sapien. Nam odio arcu, suscipit vitae, adipiscing eu, vestibulum sed, ligula. Maecenas orci nunc, dictum a, pretium in, luctus ac, mauris. Vestibulum ut risus et nisi venenatis porta. Donec vestibulum, quam non hendrerit auctor, felis nulla hendrerit nibh, sit amet scelerisque leo neque id turpis. Donec gravida. Cras accumsan viverra velit. Maecenas enim sem, facilisis vel, imperdiet et, placerat a, quam. Proin id est. Etiam condimentum. In mollis, ligula eget sollicitudin euismod, lorem arcu ultricies velit, nec adipiscing libero diam ac leo. In eu velit. Phasellus tristique sem vitae pede. Nam est nisl, volutpat non, pellentesque vitae, volutpat nec, nulla. </p>",
			//	SKU = "CAP1",
			//	UnitPrice = 12.50M,
			//	DiscountPercentage = 0,
			//	UnitsInStock = 1000000,
			//	SmallImageUrl = "~/Images/Store/cap1_small.jpg",
			//	Votes = 1,
			//	TotalRating = 3
			//};
			//var product2 = new Product
			//{
			//	Id = Guid.NewGuid(),
			//	AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
			//	AddedBy = "Marco",
			//	DepartmentId = department1.Id,
			//	Title = "Beer Cap",
			//	Description = "<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin a tortor non dolor pulvinar adipiscing. Ut sagittis aliquet felis. In et eros id leo pulvinar suscipit. Curabitur euismod mauris ut sapien. Nam odio arcu, suscipit vitae, adipiscing eu, vestibulum sed, ligula. Maecenas orci nunc, dictum a, pretium in, luctus ac, mauris. Vestibulum ut risus et nisi venenatis porta. Donec vestibulum, quam non hendrerit auctor, felis nulla hendrerit nibh, sit amet scelerisque leo neque id turpis. Donec gravida. Cras accumsan viverra velit. Maecenas enim sem, facilisis vel, imperdiet et, placerat a, quam. Proin id est. Etiam condimentum. In mollis, ligula eget sollicitudin euismod, lorem arcu ultricies velit, nec adipiscing libero diam ac leo. In eu velit. Phasellus tristique sem vitae pede. Nam est nisl, volutpat non, pellentesque vitae, volutpat nec, nulla. </p>",
			//	SKU = "CAP1",
			//	UnitPrice = 12.50M,
			//	DiscountPercentage = 0,
			//	UnitsInStock = 1000000,
			//	SmallImageUrl = "~/Images/Store/cap1_small.jpg",
			//	Votes = 1,
			//	TotalRating = 3
			//};
			//var product3 = new Product
			//{
			//	Id = Guid.NewGuid(),
			//	AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
			//	AddedBy = "Marco",
			//	DepartmentId = department1.Id,
			//	Title = "Beer Cap",
			//	Description = "<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin a tortor non dolor pulvinar adipiscing. Ut sagittis aliquet felis. In et eros id leo pulvinar suscipit. Curabitur euismod mauris ut sapien. Nam odio arcu, suscipit vitae, adipiscing eu, vestibulum sed, ligula. Maecenas orci nunc, dictum a, pretium in, luctus ac, mauris. Vestibulum ut risus et nisi venenatis porta. Donec vestibulum, quam non hendrerit auctor, felis nulla hendrerit nibh, sit amet scelerisque leo neque id turpis. Donec gravida. Cras accumsan viverra velit. Maecenas enim sem, facilisis vel, imperdiet et, placerat a, quam. Proin id est. Etiam condimentum. In mollis, ligula eget sollicitudin euismod, lorem arcu ultricies velit, nec adipiscing libero diam ac leo. In eu velit. Phasellus tristique sem vitae pede. Nam est nisl, volutpat non, pellentesque vitae, volutpat nec, nulla. </p>",
			//	SKU = "CAP1",
			//	UnitPrice = 12.50M,
			//	DiscountPercentage = 0,
			//	UnitsInStock = 1000000,
			//	SmallImageUrl = "~/Images/Store/cap1_small.jpg",
			//	Votes = 1,
			//	TotalRating = 3
			//};
			//db.Products.Add(product1);
			//db.Products.Add(product2);
			//db.Products.Add(product3);
			db.SaveChanges();
			#endregion


			if (db.Newsletters.Any())
			{
				return;
			}
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Newsletters] ON");
			#region Newsletters

			var newsletter1 = new Newsletter
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2005, 11, 20, 2, 30, 15),
				AddedBy = "Marco",
				Subject = "TheBeerHouse, Issue #0: Welcome!",
				PlainTextBody = "Dear <%username%>, welcome!Lorem ipsum dolor sit amet,consectetuer adipiscing elit.Donec quis sapien.Morbi tincidunt nibh.Nullam vitae turpis.Quisque feugiat est non ipsum.Morbi fermentum,augue sit amet suscipit aliquet,erat arcu congue tellus,vitae porta dui erat ultricies nisl.Ut aliquet aliquet magna.Cras cursus ultrices eros.Vivamus ipsum.Fusce in nulla.Aliquam erat volutpat.Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Mauris neque quam,rhoncus sit amet,suscipit id,venenatis a,diam.Pellentesque dui ante,ullamcorper sit amet,auctor non,vehicula ut,quam.Suspendisse varius tortor a erat.Cras vestibulum purus eu magna.Duis eu pede id urna rutrum lacinia.Integer lorem.Maecenas condimentum eros posuere metus.Curabitur facilisis mollis ante.Nam consequat arcu quis turpis.Maecenas tellus nibh,facilisis in,condimentum ac,aliquet ac,mauris.Aliquam erat volutpat.Vivamus sit amet nisi.Proin semper.Morbi hendrerit nisl eu dui.Cras nisi quam,adipiscing eu,rhoncus ultricies,bibendum vitae,nisi.Duis malesuada convallis mauris.Maecenas egestas,diam ac convallis consequat,nisl elit ullamcorper ante,eu mollis elit massa at sem.Nunc nibh leo,tempus in,pulvinar et,lacinia et,mi.Donec in mi sed nibh fringilla lacinia.Suspendisse consectetuer posuere massa.Integer fermentum rhoncus lectus.Nullam pellentesque,magna vel tincidunt nonummy,massa magna feugiat libero,sit amet suscipit odio ligula id felis.Nulla facilisi.Quisque feugiat metus eget ante.Sed odio.Quisque semper.Class aptent taciti sociosqu ad litora torquent per conubia nostra,per inceptos hymenaeos.Vivamus lacinia risus a risus.Praesent pulvinar blandit dui.Phasellus dictum.Phasellus aliquet nonummy felis.Aenean sapien.",
				HtmlBody = "<p><strong>Dear &lt;%username%&gt;, welcome!</strong></p>< p >< font  > Lorem ipsum dolor sit amet,consectetuer adipiscing elit.Donec quis sapien.Morbi tincidunt nibh.Nullam vitae turpis.Quisque feugiat est non ipsum.Morbi fermentum,augue sit amet suscipit aliquet,erat arcu congue tellus,vitae porta dui erat ultricies nisl.Ut aliquet aliquet magna.Cras cursus ultrices eros.Vivamus ipsum.Fusce in nulla. < font style =  >< font> Aliquam erat volutpat </ font >.</ font > Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Mauris neque quam,mi.Donec in mi sed nibh fringilla lacinia.Suspendisse consectetuer posuere massa.Integer fermentum rhoncus lectus.Nullam pellentesque,magna vel tincidunt nonummy,massa magna feugiat libero,sit amet suscipit odio ligula id felis.Nulla facilisi.Quisque feugiat metus eget ante.Sed odio.Quisque semper.Class aptent taciti sociosqu ad litora torquent per conubia nostra,per inceptos hymenaeos.Vivamus lacinia risus a risus.Praesent pulvinar blandit dui.Phasellus dictum.Phasellus aliquet nonummy felis.Aenean sapien. < br /></ u ></ p > "
			};
			db.Newsletters.Add(newsletter1);
			db.SaveChanges();
			#endregion
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Newsletters] OFF");


			if (db.Polls.Any())
			{
				return;
			}
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Polls] ON");
			#region Polls
			var poll1 = new Poll
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				QuestionText = "What do you like to eat with your beer?",
				IsCurrent = true,
				IsArchived = false,
				ArchivedDate = null
			};
			var poll2 = new Poll
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2009, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				QuestionText = "What d+++++++++++++++h your beer?",
				IsCurrent = true,
				IsArchived = false,
				ArchivedDate = null
			};
			var poll3 = new Poll
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2025, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				QuestionText = "What--------------er?",
				IsCurrent = true,
				IsArchived = false,
				ArchivedDate = null
			};
			db.Polls.Add(poll1);
			db.Polls.Add(poll2);
			db.Polls.Add(poll3);
			db.SaveChanges();
			var poll4 = new Poll
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				QuestionText = "What do you like to eat with your beer?",
				IsCurrent = true,
				IsArchived = false,
				ArchivedDate = null
			};
			db.Polls.Add(poll4);
			db.SaveChanges();
			#endregion
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Polls] OFF");

			if (db.PollOptions.Any())
			{
				return;
			}
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[PollOptions] ON");
			#region PollOptions
			var pollOption1 = new PollOption
			{
				Id = Guid.NewGuid(),
				AddedDate = new DateTime(2006, 1, 16, 17, 14, 11),
				AddedBy = "Marco",
				PollId = poll1.Id,
				OptionText = "Sandwiches",
				Votes = 4
			};
			db.PollOptions.Add(pollOption1);
			db.SaveChanges();
			#endregion
			//db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[PollOptions] OFF");

			
			db.Database.CloseConnection();
		}
	}
}
