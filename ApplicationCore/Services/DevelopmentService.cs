using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.ApplicationCore.Dto;
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

		public async Task<List<ReportedBugDto>> GetAllReports()
		{
			var listReports = await context.ReportedBugs.ToListAsync();

			var contactFormDtos = listReports.Select(cf => new ReportedBugDto()
			{
				Id = cf.Id,
				Url = cf.Url,
				Bug = cf.Bug
				
			}).ToList();

			return contactFormDtos;
		}

		public async Task<List<IdeaToReleaseDto>> GetAllIdeas()
		{
			var listideacontext = await context.IdeaToReleases.ToListAsync();

			var ideatoReleaseDtos = listideacontext.Select(cf => new IdeaToReleaseDto()
			{
				Id = cf.Id,
				Idea = cf.Idea

			}).ToList();

			return ideatoReleaseDtos;
		}

		public async Task DeleteBugAsync(int bugId)
		{
			var bugToRemove = await context.ReportedBugs.FindAsync(bugId);
			if (bugToRemove != null)
			{
				context.ReportedBugs.Remove(bugToRemove);
				await context.SaveChangesAsync();
			}
		}

		public async Task DeleteIdeaAsync(int ideaId)
		{
			var ideaToRemove = await context.IdeaToReleases.FindAsync(ideaId);
			if (ideaToRemove != null)
			{
				context.IdeaToReleases.Remove(ideaToRemove);
				await context.SaveChangesAsync();
			}
		}

	}


}
