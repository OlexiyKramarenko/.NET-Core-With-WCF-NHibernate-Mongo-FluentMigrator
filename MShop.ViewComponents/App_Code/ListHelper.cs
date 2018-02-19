using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MShop.ViewComponents.Models;
using System.Collections.Generic;
using System.Text.Encodings.Web;

namespace MShop.ViewComponents.Helpers
{
	public static class ListHelper
	{
		public static HtmlString CreateList(this IHtmlHelper html, IEnumerable<ProductItemViewModel> items)
		{
			TagBuilder table = new TagBuilder("table");
			TagBuilder td_product = new TagBuilder("td");
			TagBuilder td_rating = new TagBuilder("td");
			TagBuilder td_availablity = new TagBuilder("td");
			TagBuilder td_price = new TagBuilder("td");

			td_product.InnerHtml.Append("Product");
			td_rating.InnerHtml.Append("Rating");
			td_availablity.InnerHtml.Append("Availablity");
			td_price.InnerHtml.Append("Price");

			TagBuilder tr = new TagBuilder("tr");
			tr.InnerHtml.AppendHtml(td_product);
			tr.InnerHtml.AppendHtml(td_rating);
			tr.InnerHtml.AppendHtml(td_availablity);
			tr.InnerHtml.AppendHtml(td_price);
			table.InnerHtml.AppendHtml(tr);
			
			foreach (ProductItemViewModel item in items)
			{
				TagBuilder td_product_item = new TagBuilder("td");
				TagBuilder td_rating_item = new TagBuilder("td");
				TagBuilder td_availablity_item = new TagBuilder("td");
				TagBuilder td_price_item = new TagBuilder("td");

				td_product_item.InnerHtml.Append(item.Title);
				td_rating_item.InnerHtml.Append(item.AverageRating.ToString());
				td_availablity_item.InnerHtml.Append("?");
				td_price_item.InnerHtml.Append(item.UnitPrice.ToString());
			}

			var writer = new System.IO.StringWriter();
			table.WriteTo(writer, HtmlEncoder.Default);
			return new HtmlString(writer.ToString());
		}
	}
}
