using MojeVlastniStranka.ApplicationCore.Interfaces;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.Common.Enums;
using MojeVlastniStranka.ApplicationCore.Dto.Project;
using MojeVlastniStranka.ApplicationCore.Requests;
using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.Common.Models;

namespace MojeVlastniStranka.ApplicationCore.Interfaces
{
    public interface IProjectService
    {
		Task<ResponseViewModel> AddProject(AddProjectRequest projectRequest);
		List<Project> GetAllProjects();
		void DeleteProjectById(Guid id);
		ProjectEditDto? GetProjectById(Guid id);
		Task<ResponseViewModel> UpdateProject(UpdateProjectRequest request);
		List<ProjectSummaryDto> GetProjectsByStatusDateSearchString(ProjectStatusEnum? status, string? searchString);
    }
}
