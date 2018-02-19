using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MShop.DataLayer.Entities.Users;

namespace MShop.DataLayer.Mongo.Entities.Users
{
	[BsonIgnoreExtraElements]
	public class ApplicationUser : IApplicationUser
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public int Year { get; set; }
		public string Email { get; set; }
		public bool EmailConfirmed { get; set; }
		public string PasswordHash { get; set; }
		public string SecurityStamp { get; set; }
		public string PhoneNumber { get; set; }
		public bool PhoneNumberConfirmed { get; set; }
		public bool TwoFactorEnabled { get; set; }
		public bool LockoutEnabled { get; set; }
		public int AccessFailedCount { get; set; }
		public string UserName { get; set; }
	}
}
