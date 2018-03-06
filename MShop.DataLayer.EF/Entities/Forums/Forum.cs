using MShop.DataLayer.Entities.Forums;
using System;
using System.Collections.Generic;
namespace MShop.DataLayer.EF.Entities.Forums
{
    public class Forum: IForum
	{
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string Title { get; set; }
        public bool Moderated { get; set; }
        public int Importance { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IList<IPost> Posts { get; set; }
    }
}
