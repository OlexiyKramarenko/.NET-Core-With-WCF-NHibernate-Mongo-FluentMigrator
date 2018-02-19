
namespace MShop.ViewComponents.Models
{
	public class PageSizeViewModel
	{
		public string SelectTagId { get; set; } = "js-page-size";
		public string TextAbove { get; set; }
		public string Action { get; set; }
		public int PageSize { get; set; }
	}
}
