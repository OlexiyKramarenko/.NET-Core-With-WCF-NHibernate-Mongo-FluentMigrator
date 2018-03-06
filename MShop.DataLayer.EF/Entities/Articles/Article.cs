using MShop.DataLayer.Entities.Articles;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.EF.Entities.Articles
{
	public class Article : IArticle
	{
		public Guid Id { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public Guid CategoryId { get; set; }
		public string Title { get; set; }
		public string Abstract { get; set; }
		public string Body { get; set; }
		public string Country { get; set; }
		public string State { get; set; }
		public string City { get; set; }
		public DateTime ReleaseDate { get; set; }
		public DateTime ExpireDate { get; set; }
		public bool Approved { get; set; }
		public bool Listed { get; set; }
		public bool CommentsEnabled { get; set; }
		public bool OnlyForMembers { get; set; }
		public int ViewCount { get; set; }
		public int Votes { get; set; }
		public int TotalRating { get; set; }
		public IList<IComment> Comments { get; set; }
		public ICategory Category { get; set; }
	}
}
