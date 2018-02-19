using MShop.DataLayer.Entities.Articles;
using System; 

namespace MShop.DataLayer.EF.Entities.Articles
{
    public class Comment: IComment
	{ 
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string AddedByEmail { get; set; }
        public string AddedByIp { get; set; }
        public string Body { get; set; } 
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
