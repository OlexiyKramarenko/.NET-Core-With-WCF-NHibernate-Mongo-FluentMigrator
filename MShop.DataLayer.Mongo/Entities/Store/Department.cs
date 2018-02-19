﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MShop.DataLayer.Entities.Store;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.Mongo.Entities.Store
{
	[BsonIgnoreExtraElements]
	public class Department: IDepartment
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string Title { get; set; }
        public int Importance { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; } 
    }
}