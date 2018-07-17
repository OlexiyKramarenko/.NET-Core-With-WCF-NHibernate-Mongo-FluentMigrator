using System;

namespace MShop.DataLayer.Entities.Polls
{
	public interface IPollOption
	{ 
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string OptionText { get; set; }
		int Votes { get; set; }
		double Percentage { get; set; }
		IPoll Poll { get; set; } 
	}
}
