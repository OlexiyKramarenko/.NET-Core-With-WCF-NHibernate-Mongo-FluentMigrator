using MShop.DataLayer.Entities.Articles;
using MShop.DataLayer.Entities.Forums;
using MShop.DataLayer.Entities.Newsletters;
using MShop.DataLayer.Entities.Polls;
using MShop.DataLayer.Entities.Store;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer
{
	public class TestData<Poll, PollOption, Department, Product, OrderStatus, Order, OrderItem, ShippingMethod, Newsletter, Forum, Post, Category, Article, Comment>
		where Poll : class, IPoll, new()
		where PollOption : class, IPollOption, new()
		where Department : class, IDepartment, new()
		where Product : class, IProduct, new()
		where OrderStatus : class, IOrderStatus, new()
		where Order : class, IOrder, new()
		where OrderItem : class, IOrderItem, new()
		where ShippingMethod : class, IShippingMethod, new()
		where Newsletter : class, INewsletter, new()
		where Forum : class, IForum, new()
		where Post : class, IPost, new()
		where Category : class, ICategory, new()
		where Article : class, IArticle, new()
		where Comment : class, IComment, new()
	{
		public static Poll[] polls = new Poll[]
		{
			new Poll
			{
				 
				 QuestionText = "Has the European economic integration failed to bring stability?",
				 AddedBy = "John",
				 AddedDate = DateTime.Now,
				 ArchivedDate = DateTime.Now,
				 IsArchived = false,
				 IsCurrent = true,
				 Votes = 22,
				 PollOptions = new List<IPollOption>
				 {
				  	 new PollOption {
						   OptionText = "Yes. It only helps spread economic stability.",
						   Votes = 10,
						   AddedBy = "John",
						   AddedDate = DateTime.Now
					   },
					 new PollOption {
						 OptionText = "No. It brings economic development to the region." ,
						 Votes = 5,
						 AddedBy = "John",
						 AddedDate = DateTime.Now
					 },
					 new PollOption {
						 OptionText = "No. It brings economic benefits as well as problems to the region.",
						 Votes = 7,
						 AddedBy = "John",
						 AddedDate = DateTime.Now
					 },
				 }
			},
			new Poll
			{
				 QuestionText = "Should the ban on commercial whaling be repealed in order to save whales?",
				 AddedBy = "John",
				 AddedDate = DateTime.Now,
				 ArchivedDate = DateTime.Now,
				 IsArchived = false,
				 IsCurrent = false,
				 Votes = 80,
				 PollOptions = new List<IPollOption>
				 {
					 new PollOption {
						 OptionText = "No. This would legalize the presently illegal whaling by Japan, Iceland and Norway.",
						 Votes = 30,
						 AddedBy = "John",
						 AddedDate = DateTime.Now
					 },
					 new PollOption {
						 OptionText = "No. The ban should stay in force until replaced by a more effective measure." ,
						 Votes = 20,
						 AddedBy = "John",
						 AddedDate = DateTime.Now
					 },
					 new PollOption {
						 OptionText = "Yes. The ban is already out of date. ",
						 Votes = 15,
						 AddedBy = "John",
						 AddedDate = DateTime.Now
					 },
					 new PollOption {
						 OptionText = "Whatever.",
						 Votes = 15,
						 AddedBy = "John",
						 AddedDate = DateTime.Now
					 },
				 }
			},

		};

		public static Department[] departments = new Department[]
		{
			new Department
			{
				 Title = "Department #1",
				 AddedDate = DateTime.Now,
				 AddedBy = "John",
				 Description = "Department #1 is the best department in the whole world.",
				 Importance = 1,
				 Products = new List<IProduct>
				 {
					 new Product
					 {
						  Title = "Shoes",
						  Description = "Awesome shoes.",
						  AddedBy = "David",
						  AddedDate = DateTime.Now,
						  DiscountPercentage = 20,
						  SKU = "#123456",
						  TotalRating = 5,
						  UnitPrice = 100,
						  UnitsInStock = 40,
						  Votes = 50
					 },
					 new Product
					 {
						  Title = "Trousers",
						  Description = "Awesome trousers.",
						  AddedBy = "David",
						  AddedDate = DateTime.Now,
						  DiscountPercentage = 20,
						  SKU = "#189732",
						  TotalRating = 5,
						  UnitPrice = 100,
						  UnitsInStock = 40,
						  Votes = 50
					 },
					 new Product
					 {
						  Title = "Skirt",
						  Description = "Awesome skirt.",
						  AddedBy = "David",
						  AddedDate = DateTime.Now,
						  DiscountPercentage = 20,
						  SKU = "#198796",
						  TotalRating = 5,
						  UnitPrice = 100,
						  UnitsInStock = 40,
						  Votes = 50
					 },
				 }
			},
			new Department
			{
				 Title = "Department #2",
				 AddedBy = "Julia",
				 AddedDate = DateTime.Now,
				 Description = "Department #2 is the best department in the whole world.",
				 Importance = 1,
				 Products = new List<IProduct>
				 {
					 new Product
					 {
						  Title = "Shoes",
						  Description = "Awesome shoes.",
						  AddedBy = "David",
						  AddedDate = DateTime.Now,
						  DiscountPercentage = 20,
						  SKU = "#123456",
						  TotalRating = 5,
						  UnitPrice = 100,
						  UnitsInStock = 40,
						  Votes = 50
					 },
					 new Product
					 {
						  Title = "Trousers",
						  Description = "Awesome trousers.",
						  AddedBy = "David",
						  AddedDate =DateTime.Now,
						  DiscountPercentage = 20,
						  SKU = "#189732",
						  TotalRating = 5,
						  UnitPrice = 100,
						  UnitsInStock = 40,
						  Votes = 50
					 },
					 new Product
					 {
						  Title = "Skirt",
						  Description = "Awesome skirt.",
						  AddedBy = "David",
						  AddedDate = DateTime.Now,
						  DiscountPercentage = 20,
						  SKU = "#198796",
						  TotalRating = 5,
						  UnitPrice = 100,
						  UnitsInStock = 40,
						  Votes = 50
					 },
				 }
			},
			new Department
			{
				 Title = "Department #3",
				 AddedBy = "Julia",
				 AddedDate = DateTime.Now,
				 Description = "Department #3 is the best department in the whole world.",
				 Importance = 1,
				 Products = new List<IProduct>
				 {
					 new Product
					 {
						  Title = "Shoes",
						  Description = "Awesome shoes.",
						  AddedBy = "David",
						  AddedDate = DateTime.Now,
						  DiscountPercentage = 20,
						  SKU = "#123456",
						  TotalRating = 5,
						  UnitPrice = 100,
						  UnitsInStock = 40,
						  Votes = 50
					 },
					 new Product
					 {
						  Title = "Trousers",
						  Description = "Awesome trousers.",
						  AddedBy = "David",
						  AddedDate =DateTime.Now,
						  DiscountPercentage = 20,
						  SKU = "#189732",
						  TotalRating = 5,
						  UnitPrice = 100,
						  UnitsInStock = 40,
						  Votes = 50
					 },
					 new Product
					 {
						  Title = "Skirt",
						  Description = "Awesome skirt.",
						  AddedBy = "David",
						  AddedDate = DateTime.Now,
						  DiscountPercentage = 20,
						  SKU = "#198796",
						  TotalRating = 5,
						  UnitPrice = 100,
						  UnitsInStock = 40,
						  Votes = 50
					 },
				 }
			},
		};

		public static OrderStatus[] orderStatuses = new OrderStatus[]
		{
			new OrderStatus
			{
				 AddedBy = "Julian",
				 AddedDate = DateTime.Now,
				 Title = "Pending",
				 Orders = orders 
			},
			new OrderStatus
			{
				 AddedBy = "Julian",
				 AddedDate = DateTime.Now,
				 Title = "Awaiting Payment",

			},
			new OrderStatus
			{
				 AddedBy = "Julian",
				 AddedDate = DateTime.Now,
				 Title = "Awaiting Fulfillment",
			},
			new OrderStatus
			{
				 AddedBy = "Julian",
				 AddedDate = DateTime.Now,
				 Title = "Awaiting Shipment",

			},
			new OrderStatus
			{
				 AddedBy = "Julian",
				 AddedDate = DateTime.Now,
				 Title = "Awaiting Pickup"
			},
			new OrderStatus
			{
				 AddedBy = "Julian",
				 AddedDate = DateTime.Now,
				 Title = "Partially Shipped"
			},
			new OrderStatus
			{
				 AddedBy = "Julian",
				 AddedDate = DateTime.Now,
				 Title = "Shipped"
			},
			new OrderStatus
			{
				 AddedBy = "Julian",
				 AddedDate = DateTime.Now,
				 Title = "Cancelled"
			},
			new OrderStatus
			{
				 AddedBy = "Julian",
				 AddedDate = DateTime.Now,
				 Title = "Declined"
			},
			new OrderStatus
			{
				 AddedBy = "Julian",
				 AddedDate = DateTime.Now,
				 Title = "Refunded"
			},
			new OrderStatus
			{
				 AddedBy = "Julian",
				 AddedDate = DateTime.Now,
				 Title = "Disputed"
			},
			new OrderStatus
			{
				 AddedBy = "Julian",
				 AddedDate = DateTime.Now,
				 Title = "Verification Required"
			},
			new OrderStatus
			{
				 AddedBy = "Julian",
				 AddedDate = DateTime.Now,
				 Title = "Partially Refunded"
			},
		};

		public static Order[] orders = new Order[]
		{
			new Order
			{
				AddedBy = "Anna",
				AddedDate = DateTime.Now,
				CustomerEmail = "awesome@mail.usa",
				CustomerPhone="+0997804758",
				ShippedDate = DateTime.Now,
				ShippingCity = "Ukraine",
				ShippingCountry = "Lviv",
				ShippingFirstName = "Ivo",
				ShippingLastName ="Bobul",
				ShippingMethod ="",
				ShippingStreet = "SomeStreet",
				ShippingPostalCode = "21027",
				OrderStatus = orderStatuses[1],
				ShippingState = "",
				SubTotal = 50,
				TrackingId = "",
				TransactionId = "",
				OrderItems = new List<IOrderItem>
				{
					new OrderItem
					{
						 AddedBy = "Inna",
						 Title = "Product #1",
						 Quantity = 10,
						 Product = departments[0].Products[0],
						 SKU = departments[0].Products[0].SKU,
						 UnitPrice = departments[0].Products[0].UnitPrice,
						 AddedDate = DateTime.Now
					},
					new OrderItem
					{
						 AddedBy = "Yana",
						 Title = "Product #2",
						 Quantity = 10,
						 Product = departments[0].Products[1],
						 SKU = departments[0].Products[1].SKU,
						 UnitPrice = departments[0].Products[1].UnitPrice,
						 AddedDate = DateTime.Now
					},
					new OrderItem
					{
						 AddedBy = "Viktoria",
						 Title = "Product #3",
						 Quantity = 10,
						 Product = departments[0].Products[2],
						 SKU = departments[0].Products[2].SKU,
						 UnitPrice = departments[0].Products[2].UnitPrice,
						 AddedDate = DateTime.Now
					},
				}
			},
			new Order
			{
				AddedBy = "Janna",
				AddedDate = DateTime.Now,
				CustomerEmail = "awesome@mail.usa",
				CustomerPhone="+0997804758",
				ShippedDate = DateTime.Now,
				ShippingCity = "Ukraine",
				ShippingCountry = "Lviv",
				ShippingFirstName = "Ivo",
				ShippingLastName ="Bobul",
				ShippingMethod ="",
				ShippingStreet = "SomeStreet",
				ShippingPostalCode = "37084",
				OrderStatus = orderStatuses[0],
				ShippingState = "",
				SubTotal = 50,
				TrackingId = "",
				TransactionId = "",
				OrderItems = new List<IOrderItem>
				{
					new OrderItem
					{
						 AddedBy = "John",
						 Title = "Product #1",
						 Quantity = 10,
						 Product = departments[1].Products[0],
						 SKU = departments[1].Products[0].SKU,
						 UnitPrice = departments[1].Products[0].UnitPrice,
						 AddedDate = DateTime.Now
					},
					new OrderItem
					{
						 AddedBy = "David",
						 Title = "Product #2",
						 Quantity = 10,
						 Product = departments[1].Products[1],
						 SKU = departments[1].Products[1].SKU,
						 UnitPrice = departments[1].Products[1].UnitPrice,
						 AddedDate = DateTime.Now
					},
					new OrderItem
					{
						 AddedBy = "Julian",
						 Title = "Product #3",
						 Quantity = 10,
						 Product = departments[1].Products[2],
						 SKU = departments[1].Products[2].SKU,
						 UnitPrice = departments[1].Products[2].UnitPrice,
						 AddedDate = DateTime.Now
					},
				}
			},
		};

		public static ShippingMethod[] shippingMethods = new ShippingMethod[]
		{
			new ShippingMethod
			{
				AddedDate = DateTime.Now,
				AddedBy = "Frank",
				Price = 50,
				Title = "Economy",
				Description = "Will ship the most economical carrier based on the delivery destination and the package characteristics. Most orders will deliver within 3-6 business days. When free or reduced shipping promotions are offered, they will usually be for the economy service level.",

			},
			new ShippingMethod
			{
				AddedDate = DateTime.Now,
				AddedBy = "Frank",
				Price = 50,
				Title = "Standard",
				Description = "Most packages will ship FedEx Home, FedEx Ground, or USPS Priority Mail for delivery within 4-6 business days."
			},
			new ShippingMethod
			{
				AddedDate = DateTime.Now,
				AddedBy = "Frank",
				Price = 50,
				Title = "Standard",
				Description = "Will ship FedEx 2-day air."
			},
			new ShippingMethod
			{
				AddedDate = DateTime.Now,
				AddedBy = "Frank",
				Price = 50,
				Title = "Overnight",
				Description = "Will ship FedEx Standard overnight."
			},
		};

		public static Newsletter[] newsletters = new Newsletter[]
		{
			new Newsletter
			{
				AddedBy = "Victor",
				AddedDate = DateTime.Now,
				Subject = "War and Piece.",
				HtmlBody = "",
				PlainTextBody = ""
			},
			new Newsletter
			{
				AddedBy = "Vladimir",
				AddedDate = DateTime.Now,
				Subject = "Madness.",
				HtmlBody = "",
				PlainTextBody = ""
			},
			new Newsletter
			{
				AddedBy = "Inna",
				AddedDate = DateTime.Now,
				Subject = "Love is all you need.",
				HtmlBody = "",
				PlainTextBody = ""
			},
		};

		public static Forum[] forums = new Forum[]
		{
			new Forum
			{
				Title = "Entity Framework",
				Description = "Entity Framework",
				AddedBy = "Anna",
				AddedDate = DateTime.Now,
				Importance = 4,
				Moderated = true,
				Posts = new List<IPost>
				{
					new Post
					{
						AddedBy = "Nina",
						AddedDate = DateTime.Now,
						Title = "Correct way to get multiple rows from a table in Entity Framework ",
						Body = "So I have a bios controller, and a user can have multiple bios. I'm working on a bio viewer page where you can see all the bios for a user and so I have an action inside my BioController.",
						Approved = true,
						Closed = false,
						IsThreadPost = false,
						AddedByIP = ":1",
						ReplyCount = 5,
						ViewCount = 10,
						LastPostDate = DateTime.Now,
						LastPostBy = "David"
					},
					new Post
					{
						AddedBy = "Anna",
						AddedDate = DateTime.Now,
						Title = "How to validate entity against the context in Entity Framework?",
						Body = "I usually validate entities in Entity Framework by calling entity.IsValid() and creating appropriate ValidationAttribute class for the entity.Now, however, I run into a case when I need to validate an entity not just on its own, but within the context to which it belongs",
						Approved = true,
						Closed = false,
						IsThreadPost = false,
						AddedByIP = ":1",
						ReplyCount = 5,
						ViewCount = 10,
						LastPostDate = DateTime.Now,
						LastPostBy = "David"
					},
					new Post
					{
						AddedBy = "Nina",
						AddedDate = DateTime.Now,
						Title = "Calling a custom scalar DB function inside a LINQ to Entities query?",
						Body = "Is there a way I can call a custom scalar DB function as part of my LINQ to Entities query? The only thing I can find on the web about this is this page.However the instructions given here seem to assume you are using a DB-first approach and talk about modifying the.edmx file.",
						Approved = true,
						Closed = false,
						IsThreadPost = false,
						AddedByIP = ":1",
						ReplyCount = 5,
						ViewCount = 10,
						LastPostDate = DateTime.Now,
						LastPostBy = "David"
					},
				}
			},
			new Forum
			{
				Title = "ASP.NET is a Microsoft web application development framework.",
				AddedBy = "Dima",
				AddedDate = DateTime.Now,
				Description = "ASP.NET is a Microsoft web application development framework that allows programmers to build dynamic web sites.",
				Importance = 4,
				Moderated = true,
				Posts = new List<IPost>
				{
					new Post
					{
						AddedBy = "Vova",
						AddedDate = DateTime.Now,
						Title = "How to check if the Array has Duplicates column values",
						Body = "Here AccountNum, locNum, LocName and CountryCode are the Columns on e Excel Sheet. The moment User selects the Excel File from UI and click on the Submit button, I do the validations. Here LocName value should be unique. I need to display the validation error message if the LocName is not unique. For Example: Here Loc1 is repeated. What is the best way to check if LocName has Duplicates or not?",
						Approved = true,
						Closed = false,
						IsThreadPost = false,
						AddedByIP = ":1",
						ReplyCount = 5,
						ViewCount = 10,
						LastPostDate = DateTime.Now,
						LastPostBy = "David"
					},
					new Post
					{
						AddedBy = "Anna",
						AddedDate = DateTime.Now,
						Title = "Load modal after post",
						Body = "When I executed method it return me an Error message who I want to display in bootstrap modal.",
						Approved = true,
						Closed = false,
						IsThreadPost = false,
						AddedByIP = ":1",
						ReplyCount = 5,
						ViewCount = 10,
						LastPostDate = DateTime.Now,
						LastPostBy = "David"
					},
					new Post
					{
						AddedBy = "Vova",
						AddedDate = DateTime.Now,
						Title = "how to add background color to last line of GridView after pdf export using iText",
						Body = "I am using iText to export GridView to pdf, i was able to add header color to my pdf. But how do i add color to line row of pdf in the Gridview?",
						Approved = true,
						Closed = false,
						IsThreadPost = false,
						AddedByIP = ":1",
						ReplyCount = 5,
						ViewCount = 10,
						LastPostDate = DateTime.Now,
						LastPostBy = "David"
					},
				}
			},
		};

		public static Category[] categories = new Category[]
		{
			new Category
			{
				AddedBy = "Victor",
				AddedDate = DateTime.Now,
				Description = "Science articles.",
				Importance = 4,
				Title = "Science & Environment",
				Articles = new List<IArticle>
				{
					 new Article
					 {
						AddedBy = "Ethan",
						Title = "Signal detected from 'cosmic dawn'",
						Country = "Ukraine",
						City = "Lviv",
						AddedDate = new DateTime(2005, 9, 3, 12, 14, 0),
						ReleaseDate = new DateTime(2005, 9, 3, 12, 15, 0),
						ExpireDate = new DateTime(2025, 10, 5, 12, 15, 0),
						Approved = true,
						Listed = true,
						CommentsEnabled = true,
						OnlyForMembers = false,
						ViewCount = 8,
						Votes = 1,
						TotalRating = 3,
						Abstract = "Scientists say they have observed a signature on the sky from the very...",
						Body = @"Scientists say they have observed a signature on the sky from the very first stars to shine in the Universe.
								 They did it with the aid of a small radio telescope in the Australian outback that was tuned to detect the earliest ever evidence for hydrogen.
								 This hydrogen was in a state that could only be explained if it had been touched by the intense light of stars.
								 The team puts the time of this interaction at a mere 180 million years after the Big Bang.
								 Given that the cosmos is roughly 13.8 billion years old, it means the first stars lit up a full nine billion years before even our own Sun flickered into life.",
						Comments = new List<IComment>
						{
							new Comment
							{
								AddedBy = "Oleg",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":1",
								Body = "Nice article.",
								AddedDate = DateTime.Now
							},
							new Comment
							{
								AddedBy = "Igor",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":2",
								Body = "LOL.",
								AddedDate = DateTime.Now
							},
							new Comment
							{
								AddedBy = "Nina",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":3",
								Body = "Thanks.",
								AddedDate = DateTime.Now
							},
							new Comment
							{
								AddedBy = "Oleg",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":4",
								Body = "Very useful.",
								AddedDate = DateTime.Now
							},
						}
					 },
					 new Article
					 {
						AddedBy = "Anonymus",
						Title = "Penguin super-colony spotted from space",
						Country = "Ukraine",
						City = "Lviv",
						AddedDate = new DateTime(2005, 9, 3, 12, 14, 0),
						ReleaseDate = new DateTime(2005, 9, 3, 12, 15, 0),
						ExpireDate = new DateTime(2025, 10, 5, 12, 15, 0),
						Approved = true,
						Listed = true,
						CommentsEnabled = true,
						OnlyForMembers = false,
						ViewCount = 8,
						Votes = 1,
						TotalRating = 3,
						Abstract = "Scientists have stumbled across a huge group of previously unknown Adélie penguins on the most northerly point of the Antarctic Peninsula.",
						Body = @"Numbering more than 1.5 million birds, they were first noticed when great patches of their poo, or guano, showed up in pictures taken from space.The animals are crammed on to a rocky archipelago called the Danger Islands.The researchers, who detail the discovery in the journal Scientific Reports, say it is a total surprise.""It's a classic case of finding something where no-one really looked! The Danger Islands are hard to reach, so people didn't really try that hard,"" team-member Dr Tom Hart from Oxford University, UK, told BBC News.",
						Comments = new List<IComment>
						{
							new Comment
							{
								AddedBy = "Anton",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":1",
								Body = "I know it.",
								AddedDate = DateTime.Now
							},
							new Comment
							{
								AddedBy = "Vika",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":2",
								Body = "LOL.",
								AddedDate = DateTime.Now
							},
							new Comment
							{
								AddedBy = "Ruslan",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":3",
								Body = "Thanks.",
								AddedDate = DateTime.Now
							},
						}
					 },
					 new Article
					 {
						AddedBy = "Vasiliy",
						Title = "Gove lambasts water company chiefs",
						Country = "Ukraine",
						City = "Lviv",
						AddedDate = new DateTime(2005, 9, 3, 12, 14, 0),
						ReleaseDate = new DateTime(2005, 9, 3, 12, 15, 0),
						ExpireDate = new DateTime(2025, 10, 5, 12, 15, 0),
						Approved = true,
						Listed = true,
						CommentsEnabled = true,
						OnlyForMembers = false,
						ViewCount = 8,
						Votes = 1,
						TotalRating = 3,
						Abstract = "Water firms have been accused of exploiting their monopoly power and neglecting the environment.",
						Body = @"The critcism comes from Environment Secretary Michael Gove, who said some firms had paid no tax and hidden their earnings offshore.And he promised to back the regulator Ofwat in tightening up rules to protect bill-payers and the environment.The industry body Water UK has yet to respond.But Mr Gove’s speech to a water industry conference must have made uncomfortable listening.He complained that water firms had paid out almost all of their £18bn profits to shareholders, instead of re-investing it in mending leaks and protecting the environment.And he named names: The boss of United Utilities taking home £2.8m a year; the head of Severn Trent, £2.4m.The secretary of state said last year Anglian and Southern paid zero corporation tax, whilst Thames has paid no corporation tax for a decade.He suggested: ""Some of their best brains appear to be as intent on financial engineering as much as real engineering.""",
						Comments = new List<IComment>
						{
							new Comment
							{
								AddedBy = "Anton",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":1",
								Body = "You may be private companies, but you have a responsibility to the public who can’t take their custom elsewhere.",
								AddedDate = DateTime.Now
							},
							new Comment
							{
								AddedBy = "Vika",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":2",
								Body = "The environmental problems with the industry are a signal of financial problems.",
								AddedDate = DateTime.Now
							},
							new Comment
							{
								AddedBy = "Ruslan",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":3",
								Body = "We need effective regulation – it’s clearly not happening at the moment. Politicians can’t just have an obsession with bills.",
								AddedDate = DateTime.Now
							},
						}
					 },
				}
			},
			new Category
			{
				AddedBy = "Jogn",
				AddedDate = DateTime.Now,
				Description = "Business.",
				Importance = 4,
				Title = "Business articles and news",
				Articles = new List<IArticle>
				{
					 new Article
					 {
						AddedBy = "Ethan",
						Title = "Carney calls for crackdown on cryptocurrency 'mania'",
						Country = "Ukraine",
						City = "Lviv",
						AddedDate = new DateTime(2005, 9, 3, 12, 14, 0),
						ReleaseDate = new DateTime(2005, 9, 3, 12, 15, 0),
						ExpireDate = new DateTime(2025, 10, 5, 12, 15, 0),
						Approved = true,
						Listed = true,
						CommentsEnabled = true,
						OnlyForMembers = false,
						ViewCount = 8,
						Votes = 1,
						TotalRating = 3,
						Abstract = "Cryptocurrencies such as Bitcoin should be regulated to crack down on illegal activities and protect the financial system, Mark Carney has warned....",
						Body = @"""The time has come to hold the crypto-asset ecosystem to the same standards as the rest of the financial system,"" Mr Carney said in a speech on Friday.Cryptocurrencies do not yet pose risks to financial stability, he said.But he said that could change if more people began investing in them. Although some countries have banned them, Mr Carney said regulation would be a better approach.""A better path would be to regulate elements of the rypto-asset ecosystem to combat illicit activities, promote market integrity, and protect the safety and soundness of the financial system,"" he said.",
						Comments = new List<IComment>
						{
							new Comment
							{
								AddedBy = "Oleg",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":1",
								Body = "Nice article.",
								AddedDate = DateTime.Now
							},
							new Comment
							{
								AddedBy = "Igor",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":2",
								Body = "LOL.",
								AddedDate = DateTime.Now
							},
							new Comment
							{
								AddedBy = "Nina",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":3",
								Body = "Thanks.",
								AddedDate = DateTime.Now
							},
							new Comment
							{
								AddedBy = "Oleg",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":4",
								Body = "Very useful.",
								AddedDate = DateTime.Now
							},
						}
					 },
					 new Article
					 {
						AddedBy = "Anonymus",
						Title = "Trump steel tariffs: Trading partners threaten retaliation",
						Country = "Ukraine",
						City = "Lviv",
						AddedDate = new DateTime(2005, 9, 3, 12, 14, 0),
						ReleaseDate = new DateTime(2005, 9, 3, 12, 15, 0),
						ExpireDate = new DateTime(2025, 10, 5, 12, 15, 0),
						Approved = true,
						Listed = true,
						CommentsEnabled = true,
						OnlyForMembers = false,
						ViewCount = 8,
						Votes = 1,
						TotalRating = 3,
						Abstract = "The main trading partners of the US have reacted angrily after President Donald Trump announced plans to impose tariffs on steel and aluminium imports.",
						Body = @"Canada and the EU said they would bring forward their own countermeasures to the steep new tariffs.Mexico, China and Brazil have also said they are weighing up retaliatory steps.Mr Trump tweeted that the US had been ""decimated by unfair trade and bad policy"". He said steel imports would face a 25% tariff and aluminium 10%.However, critics argue that the tariffs would fail to protect American jobs and would ultimately put up prices for consumers.The news sent shares in Asia down on Friday, with Japan's benchmark Nikkei 225 losing more than 2% by mid-morning.",
						Comments = new List<IComment>
						{
							new Comment
							{
								AddedBy = "Anton",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":1",
								Body = "I know it.",
								AddedDate = DateTime.Now
							},
							new Comment
							{
								AddedBy = "Vika",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":2",
								Body = "LOL.",
								AddedDate = DateTime.Now
							},
							new Comment
							{
								AddedBy = "Ruslan",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":3",
								Body = "Thanks.",
								AddedDate = DateTime.Now
							},
						}
					 },
					 new Article
					 {
						AddedBy = "Vasiliy",
						Title = "What could China do in a US trade war?",
						Country = "Ukraine",
						City = "Lviv",
						AddedDate = new DateTime(2005, 9, 3, 12, 14, 0),
						ReleaseDate = new DateTime(2005, 9, 3, 12, 15, 0),
						ExpireDate = new DateTime(2025, 10, 5, 12, 15, 0),
						Approved = true,
						Listed = true,
						CommentsEnabled = true,
						OnlyForMembers = false,
						ViewCount = 8,
						Votes = 1,
						TotalRating = 3,
						Abstract = "President Trump's backing for slapping tariffs on imports of washing machines and solar panels will hit China and South Korea hardest.",
						Body = @"And it has opened up the prospect of some retaliation - especially from Beijing.The hardline Chinese publication Global Times says ""nothing good"" would come out of a trade war with President Trump, and has warned that China could fight back.There's lots at stake. The two countries did $578.6bn worth of trade in 2016.And by the US government's own estimates that trade supports just under a million American jobs.",
						Comments = new List<IComment>
						{
							new Comment
							{
								AddedBy = "Anton",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":1",
								Body = "You may be private companies, but you have a responsibility to the public who can’t take their custom elsewhere.",
								AddedDate = DateTime.Now
							},
							new Comment
							{
								AddedBy = "Vika",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":2",
								Body = "The environmental problems with the industry are a signal of financial problems.",
								AddedDate = DateTime.Now
							},
							new Comment
							{
								AddedBy = "Ruslan",
								AddedByEmail = "oleg@gmail.com",
								AddedByIp = ":3",
								Body = "We need effective regulation – it’s clearly not happening at the moment. Politicians can’t just have an obsession with bills.",
								AddedDate = DateTime.Now
							},
						}
					 },
				}
			},
		};
	}
}
