using System.Collections.Generic;
using System;
using System.Linq;
using MShop.DataLayer.Repositories;
using MShop.DataLayer.EF.Entities.Polls;
using Microsoft.EntityFrameworkCore;

namespace MShop.DataLayer.EF.Repositories
{
	public class PollsRepository : IPollsRepository<Poll, PollOption, Guid>
	{
		private readonly EfUnitOfWork _unitOfWork;

		public PollsRepository(EfUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		#region Public Methods
		public void ArchivePoll(Guid pollId)
		{
			Poll poll = this.GetPollById(pollId);
			if (poll != null)
			{
				poll.IsCurrent = false;
				poll.IsArchived = true;
				poll.ArchivedDate = DateTime.Now;
			}
		}

		public void DeleteOption(Guid optionId)
		{
			PollOption pollOption = this.GetPollOptionById(optionId);
			if (pollOption != null)
			{
				_unitOfWork.Context.PollOptions.Remove(pollOption);
			}
		}

		public void DeletePoll(Guid pollId)
		{
			Poll poll = this.GetPollById(pollId);
			if (poll != null)
			{
				_unitOfWork.Context.Polls.Remove(poll);
			}
		}

		public Guid GetCurrentPollId()
		{
			Poll poll = _unitOfWork.Context
								   .Polls
								   .AsNoTracking()
								   .FirstOrDefault(p => p.IsCurrent && !p.IsArchived);
			if (poll == null)
			{
				return Guid.Empty;
			}
			return poll.Id;
		}

		public PollOption GetOptionById(Guid optionId)
		{
			PollOption pollOption = this.GetPollOptionById(optionId);
			if (pollOption != null)
			{
				int totVotes = _unitOfWork.Context
										  .PollOptions
										  .AsNoTracking()
										  .Where(a => a.PollId == pollOption.Id)
										  .Sum(a => a.Votes);
				if (totVotes == 0)
				{
					totVotes = 1;
				}
				pollOption.Percentage = (double)pollOption.Votes * 100 / totVotes;
			}
			return pollOption;
		}

		public List<PollOption> GetOptions(Guid pollId)
		{
			int totVotes = _unitOfWork.Context
									  .PollOptions
									  .AsNoTracking()
									  .Where(a => a.PollId == pollId)
									  .Sum(a => a.Votes);

			if (totVotes == 0)
			{
				totVotes = 1;
			}
			List<PollOption> pollOptions = _unitOfWork.Context
													  .PollOptions
													  .Where(a => a.PollId == pollId)
													  .OrderBy(a => a.AddedDate)
													  .Select(a => new PollOption
													  {
														  Id = a.Id,
														  AddedDate = a.AddedDate,
														  AddedBy = a.AddedBy,
														  PollId = a.PollId,
														  OptionText = a.OptionText,
														  Votes = a.Votes,
														  Percentage = (double)a.Votes * 100 / totVotes
													  })
													  .AsNoTracking()
													  .ToList();
			return pollOptions;
		}


		public Poll GetPollWithVotesById(Guid pollId)
		{
			Poll poll = this.GetPollById(pollId);
			if (poll != null)
			{
				poll.Votes = _unitOfWork.Context
										.PollOptions
										.Where(a => a.PollId == pollId)
										.AsNoTracking()
										.Sum(a => a.Votes);
			};
			return poll;
		}

		public int GetPollsCount(bool includeActive, bool includeArchived)
		{
			bool isArchived1 = true;
			bool isArchived2 = false;

			if (includeActive && !includeArchived)
			{
				isArchived1 = false;
			}

			if (!includeActive && includeArchived)
			{
				isArchived2 = true;
			}

			int pollsCount = _unitOfWork.Context
										  .Polls
										  .Where(a => a.IsArchived == isArchived1 ||
													 a.IsArchived == isArchived2)
										  .Count();
			return pollsCount;
		}

		public void InsertOption(PollOption option)
		{
			_unitOfWork.Context.PollOptions.Add(option);
		}

		public void InsertPoll(Poll poll)
		{
			_unitOfWork.Context.Polls.Add(poll);
		}

		public void InsertVote(Guid optionId, Guid pollId, string currentUserIpAdress)
		{
			_unitOfWork.Context
					   .AnsweredUsers
					   .Add(new AnsweredUser
					   {
						   PollId = pollId,
						   PollOptionId = optionId,
						   UserIpAdress = currentUserIpAdress
					   });

			PollOption pollOption = _unitOfWork.Context
											   .PollOptions
											   .Find(optionId);
			if (pollOption != null)
			{
				pollOption.Votes++;
			}
		}

		public void UpdateOption(Guid optionId, string optionText)
		{
			PollOption pollOption = this.GetPollOptionById(optionId);
			if (pollOption != null)
			{
				pollOption.OptionText = optionText;
			}
		}

		public void UpdatePoll(Guid pollId, string questionText, bool isCurrent)
		{
			if (isCurrent)
			{
				foreach (Poll poll in _unitOfWork.Context.Polls)
				{
					poll.IsCurrent = false;
				}
			}
			Poll ctxPoll = this.GetPollById(pollId);
			if (ctxPoll != null)
			{
				ctxPoll.QuestionText = questionText;
				ctxPoll.IsCurrent = isCurrent;
				ctxPoll.IsArchived = false;
			}
		}
		public Poll GetPollById(Guid id)
		{
			Poll poll = _unitOfWork.Context
								   .Polls
								   .Include(p => p.PollOptions)
								   .FirstOrDefault(a => a.Id == id);
			return poll;
		}
		#endregion

		#region Private Methods
		private PollOption GetPollOptionById(Guid id)
		{
			PollOption pollOption = _unitOfWork.Context
											   .PollOptions
											   .Find(id);
			return pollOption;
		}


		public List<Poll> GetPolls(bool includeActive, bool includeArchived, int pageIndex, int pageSize)
		{
			bool isArchived1 = true;
			bool isArchived2 = false;

			if (includeActive && !includeArchived)
			{
				isArchived1 = false;
			}

			if (!includeActive && includeArchived)
			{
				isArchived2 = true;
			}
			int skipCount = (pageIndex - 1) * pageSize;
			List<Poll> polls = _unitOfWork.Context
										  .Polls
										  .Where(a => a.IsArchived == isArchived1 ||
													 a.IsArchived == isArchived2)
										  .Select(p => new Poll
										  {
											  Id = p.Id,
											  AddedBy = p.AddedBy,
											  AddedDate = p.AddedDate,
											  ArchivedDate = p.ArchivedDate,
											  IsArchived = p.IsArchived,
											  IsCurrent = p.IsCurrent,
											  QuestionText = p.QuestionText,
											  Votes = _unitOfWork.Context
															   .PollOptions
															   .Where(a => a.PollId == p.Id)
															   .Sum(a => a.Votes)
										  })
										  .OrderBy(a => a.IsArchived)
										  .ThenByDescending(a => a.ArchivedDate)
										  .ThenByDescending(a => a.AddedDate)
										  .Skip(skipCount)
										  .Take(pageSize)
										  .AsNoTracking()
										  .ToList();
			return polls;
		}

		public bool ShowPoll(string currentUserIpAdress, Guid pollId)
		{
			AnsweredUser user = _unitOfWork.Context
										   .AnsweredUsers
										   .FirstOrDefault(a => a.UserIpAdress == currentUserIpAdress && a.PollId == pollId);
			if (user != null)
			{
				return false;
			}
			return true;
		}

		#endregion
	}
}
