using Microsoft.AspNetCore.Mvc;

namespace MShop.Presentation.MPA.Admin.Infrastructure.Extensions
{
	public static class ControllerExtensions
	{
		public static string ShortControllerName<T>() where T : Controller
		{
			return typeof(T).Name.Replace("Controller", "");
		}
		
			public static string ShortName(this string fullControllerClassName)
			{
				return fullControllerClassName.Replace("Controller", "")
				                              .Replace("ViewComponent","");
			}
		
	}
}
