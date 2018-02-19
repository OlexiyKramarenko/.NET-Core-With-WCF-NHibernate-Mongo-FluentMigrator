using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MShop.DataLayer.Entities.Newsletters;
using System;

namespace MShop.DataLayer.Mongo.Entities.Newsletters
{
	[BsonIgnoreExtraElements]
	public class Newsletter: INewsletter
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string Subject { get; set; }
        public string PlainTextBody { get; set; }
        public string HtmlBody { get; set; }
    }
}
