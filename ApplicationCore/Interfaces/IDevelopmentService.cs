using MojeVlastniStranka.ApplicationCore.Interfaces;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.ApplicationCore.Interfaces
{
    public interface IDevelopmentService
    {
		Task<bool> AddIdeaToRelease(IdeaToReleaseRequest ideaToReleaseRequest);
		Task<bool> ReportBug(ReportedBugRequest reporetedBug);
		Task<List<ReportedBugDto>> GetAllReports();
		Task<List<IdeaToReleaseDto>> GetAllIdeas();
		Task DeleteBugAsync(int bugId);
		Task DeleteIdeaAsync(int ideaId);
    }
}
