using System;

namespace MShop.DataLayer.EF.Entities.Polls
{
    public class AnsweredUser
    {
		public Guid Id { get; set; }
		public string UserIpAdress { get;set;}
		public Guid PollId { get; set; }
		public Guid PollOptionId { get; set; }
    }
}
