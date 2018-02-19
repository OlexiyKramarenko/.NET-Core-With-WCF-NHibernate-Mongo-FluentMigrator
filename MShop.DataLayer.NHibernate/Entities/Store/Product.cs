using MShop.DataLayer.Entities.Store;
using System;

namespace MShop.DataLayer.NHibernate.Entities.Store
{
	public class Product : IProduct
	{
		public virtual Guid Id { get; set; }
		public virtual DateTime AddedDate { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual Guid DepartmentId { get; set; }
		public virtual string Title { get; set; }
		public virtual string Description { get; set; }
		public virtual string SKU { get; set; }
		public virtual decimal UnitPrice { get; set; }
		public virtual int DiscountPercentage { get; set; }
		public virtual int UnitsInStock { get; set; }
		public virtual string SmallImageUrl { get; set; }
		public virtual string FullImageUrl { get; set; }
		public virtual int Votes { get; set; }
		public virtual int TotalRating { get; set; }
		public virtual Department Department { get; set; }
	}
}
