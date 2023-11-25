using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	public class DevelopmentService
	{
		private readonly DataContext context;
		public DevelopmentService(DataContext context)
		{
			this.context = context;
		}

		public async Task<bool> AddIdeaToRelease(IdeaToReleaseRequest ideaToReleaseRequest)
		{
#if DEBUG
			var addingIdeaToRel = IdeaToRelease.Create(null, ideaToReleaseRequest.Idea, DateTime.Now);
#else
			var addingIdeaToRel = IdeaToRelease.Create(ideaToReleaseRequest.Idea, DateTime.Now);

#endif
			context.IdeaToReleases.Add(addingIdeaToRel);
			context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> ReportBug(ReportedBugRequest reporetedBug)
		{
#if DEBUG
			var bug = ReportedBug.Create(null, reporetedBug.Url, reporetedBug.Bug, DateTime.Now);
#else
			var bug = IdeaToRelease.Create(ideaToReleaseRequest.Idea, DateTime.Now);
#endif
			context.ReportedBugs.Add(bug);
			context.SaveChangesAsync();
			return true;
		}
	}
}
