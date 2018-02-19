using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MShop.DataLayer.Entities.Store;
using System;

namespace MShop.DataLayer.Mongo.Entities.Store
{
	[BsonIgnoreExtraElements]
	public class Product : IProduct
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string SKU { get; set; }
		public decimal UnitPrice { get; set; }
		public int DiscountPercentage { get; set; }
		public int UnitsInStock { get; set; }
		public string SmallImageUrl { get; set; }
		public string FullImageUrl { get; set; }
		public int Votes { get; set; }
		public int TotalRating { get; set; }
		public Department Department { get; set; }

		public string DepartmentId { get; set; }
	}
}
