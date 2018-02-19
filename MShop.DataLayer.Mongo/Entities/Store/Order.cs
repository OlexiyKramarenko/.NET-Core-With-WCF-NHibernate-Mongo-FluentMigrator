using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MShop.DataLayer.Entities.Store;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.Mongo.Entities.Store
{
	[BsonIgnoreExtraElements]
	public class Order : IOrder
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string StatusId { get; set; }
		public string ShippingMethod { get; set; }
		public decimal SubTotal { get; set; }
		public decimal Shipping { get; set; }
		public string ShippingFirstName { get; set; }
		public string ShippingLastName { get; set; }
		public string ShippingStreet { get; set; }
		public string ShippingPostalCode { get; set; }
		public string ShippingCity { get; set; }
		public string ShippingState { get; set; }
		public string ShippingCountry { get; set; }
		public string CustomerEmail { get; set; }
		public string CustomerPhone { get; set; }
		public string CustomerFax { get; set; }
		public string TransactionId { get; set; }
		public DateTime? ShippedDate { get; set; }
		public string TrackingId { get; set; }
	}
}
