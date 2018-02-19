using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MShop.DataLayer.Entities.Polls;
using System;

namespace MShop.DataLayer.Mongo.Entities.Polls
{
	[BsonIgnoreExtraElements]
	public class PollOption : IPollOption
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string OptionText { get; set; }
		public int Votes { get; set; }
		public double Percentage { get; set; }

		public string PollId { get; set; }
	}
}
