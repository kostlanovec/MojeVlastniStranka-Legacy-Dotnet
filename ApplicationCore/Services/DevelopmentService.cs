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

		/// <summary>
		/// Přidání nápadu do databáze.
		/// </summary>
		public async Task<bool> AddIdeaToRelease(IdeaToReleaseRequest ideaToReleaseRequest)
		{
			var addingIdeaToRel = IdeaToRelease.Create(ideaToReleaseRequest.Idea, DateTime.Now);

			context.IdeaToReleases.Add(addingIdeaToRel);
			context.SaveChanges();
			return true;
		}

		/// <summary>
		/// Přidání chyby do databáze.
		/// </summary>
		public async Task<bool> ReportBug(ReportedBugRequest reporetedBug)
		{
			var bug = ReportedBug.Create(reporetedBug.Url, reporetedBug.Bug, DateTime.Now);
			context.ReportedBugs.Add(bug);
			context.SaveChangesAsync();
			return true;
		}

		/// <summary>
		/// Získání všech chyb z databáze.
		/// </summary>
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

		/// <summary>
		/// Źískání všech nápadu z databáze.
		/// </summary>
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

		/// <summary>
		/// Smazání chyby z databáze.
		/// </summary>
		public async Task DeleteBugAsync(int bugId)
		{
			var bugToRemove = await context.ReportedBugs.FindAsync(bugId);
			if (bugToRemove != null)
			{
				context.ReportedBugs.Remove(bugToRemove);
				context.SaveChanges();
			}
		}

		/// <summary>
		/// Smazání nápadu z databáze.
		/// </summary>
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
