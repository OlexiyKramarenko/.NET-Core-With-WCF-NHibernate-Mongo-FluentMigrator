using System.Collections.Generic;
using MShop.DataLayer.Entities.Polls;

namespace MShop.DataLayer.Repositories
{
	public interface IPollsRepository<Poll, PollOption, IdType> 
		where Poll : IPoll
		where PollOption : IPollOption
	{
		List<Poll> GetPolls(bool includeActive, bool includeArchived);
		Poll GetPollWithVotesById(IdType pollId);
		IdType GetCurrentPollId();
		void DeletePoll(IdType pollId);
		void ArchivePoll(IdType pollId);
		void UpdatePoll(IdType pollId, string questionText, bool isCurrent);
		void InsertPoll(Poll poll);
		void InsertVote(IdType optionId);
		List<PollOption> GetOptions(IdType pollId);
		PollOption GetOptionById(IdType optionId);
		void DeleteOption(IdType optionId);
		void UpdateOption(IdType optionId, string optionText);
		void InsertOption(PollOption option);
	}
}
