using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MShop.DataLayer.Entities.Forums;
using System;
using System.Collections.Generic;
namespace MShop.DataLayer.Mongo.Entities.Forums
{
	[BsonIgnoreExtraElements]
	public class Forum: IForum
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string Title { get; set; }
        public bool Moderated { get; set; }
        public int Importance { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; } 
    }
}
