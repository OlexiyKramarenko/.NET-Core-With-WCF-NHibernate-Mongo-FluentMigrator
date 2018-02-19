using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MShop.DataLayer.Entities.Polls;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.Mongo.Entities.Polls
{
	[BsonIgnoreExtraElements]
	public class Poll: IPoll
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string QuestionText { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsArchived { get; set; }
        public int Votes { get; set; }
        public DateTime? ArchivedDate { get; set; } 
    }
}
