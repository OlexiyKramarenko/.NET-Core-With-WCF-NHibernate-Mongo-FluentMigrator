using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MShop.DataLayer.Entities.Store;
using System;
 
namespace MShop.DataLayer.Mongo.Entities.Store
{
	[BsonIgnoreExtraElements]
	public class OrderStatus: IOrderStatus
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string Title { get; set; }
    }
}
