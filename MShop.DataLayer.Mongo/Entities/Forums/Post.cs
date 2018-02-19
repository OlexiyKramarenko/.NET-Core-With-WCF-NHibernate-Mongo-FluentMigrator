using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MShop.DataLayer.Entities.Forums;
using System;

namespace MShop.DataLayer.Mongo.Entities.Forums
{
	[BsonIgnoreExtraElements]
	public class Post: IPost
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string AddedByIP { get; set; } 
        public string ParentPostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool Approved { get; set; }
        public bool Closed { get; set; }
        public int ViewCount { get; set; }
        public int ReplyCount { get; set; }
        public DateTime LastPostDate { get; set; }
        public string LastPostBy { get; set; }
        public bool IsThreadPost { get; set; }

		public string ForumId { get; set; }
	}
}
