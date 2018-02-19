using System;

namespace MShop.DataLayer.Entities.Polls
{
	public interface IPoll
	{ 
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string QuestionText { get; set; }
		bool IsCurrent { get; set; }
		bool IsArchived { get; set; }
		int Votes { get; set; }
		DateTime? ArchivedDate { get; set; } 
	}
}
