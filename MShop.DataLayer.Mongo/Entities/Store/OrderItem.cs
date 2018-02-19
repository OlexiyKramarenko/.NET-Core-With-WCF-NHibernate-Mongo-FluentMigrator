using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MShop.DataLayer.Entities.Store;
using System;

namespace MShop.DataLayer.Mongo.Entities.Store
{
	[BsonIgnoreExtraElements]
	public class OrderItem : IOrderItem
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string ProductId { get; set; }
		public string Title { get; set; }
		public string SKU { get; set; }
		public decimal UnitPrice { get; set; }
		public int Quantity { get; set; } 
		public string OrderId { get; set; }
	}
}
