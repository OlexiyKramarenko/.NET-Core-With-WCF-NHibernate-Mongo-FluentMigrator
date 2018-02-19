using MShop.DataLayer.Entities.Articles;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.EF.Entities.Articles
{
	public class Category : ICategory
	{
		public Guid Id { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }
		public int Importance { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }		
		public List<Article> Articles { get; set; }
	}
}
