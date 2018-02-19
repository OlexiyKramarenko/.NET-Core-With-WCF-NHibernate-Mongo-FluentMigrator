using System;

namespace MShop.ViewComponents.Models
{
	public class PagerViewModel
	{
		public PagerViewModel()
		{

		}
		public PagerViewModel(int itemsCount, int pageSize, int pageIndex, string controller, string action)
		{
			_itemsCount = itemsCount;
			_controller = controller;
			PageSize = pageSize;
			PageIndex = pageIndex;
			Action = action;
		}

		private int _itemsCount;
		private string _controller;

		public string Action { get; set; }
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
		public string Controller => _controller.Replace("Controller", "");
		public int PageCount => (int)Math.Ceiling((double)_itemsCount / PageSize);
	}
}

