using MShop.DataLayer.Entities.Store;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.NHibernate.Entities.Store
{
	public class Department : IDepartment
	{
		public virtual Guid Id { get; set; }
		public virtual DateTime AddedDate { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual string Title { get; set; }
		public virtual int Importance { get; set; }
		public virtual string Description { get; set; }
		public virtual string ImageUrl { get; set; }
		public virtual IList<IProduct> Products { get; set; }
	}
}
