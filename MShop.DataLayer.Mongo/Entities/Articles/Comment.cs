using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MShop.DataLayer.Entities.Articles;
using System;

namespace MShop.DataLayer.Mongo.Entities.Articles
{
	[BsonIgnoreExtraElements]
	public class Comment : IComment
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string AddedByEmail { get; set; }
		public string AddedByIp { get; set; }
		public string Body { get; set; }

		public string ArticleId { get; set; }
	}
}
