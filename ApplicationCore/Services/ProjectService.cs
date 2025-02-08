using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.Common.Enums;
using MojeVlastniStranka.ApplicationCore.Dto.Project;
using MojeVlastniStranka.ApplicationCore.Requests;
using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.Common.Models;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	public class ProjectService
	{
		private readonly DataContext context;
		private readonly ImageService imageService;

		public ProjectService(DataContext context, ImageService imageService)
		{
			this.context = context;
			this.imageService = imageService;
		}

		public async Task<ResponseViewModel> AddProject(AddProjectRequest projectRequest)
		{
			var response = new ResponseViewModel();

			if (string.IsNullOrEmpty(projectRequest.Description) ||
				string.IsNullOrEmpty(projectRequest.Content) ||
				string.IsNullOrEmpty(projectRequest.Title) ||
				string.IsNullOrEmpty(projectRequest.Keywords) ||
				string.IsNullOrEmpty(projectRequest.Name) ||
				Equals(projectRequest.projectStatus, null) ||
				string.IsNullOrEmpty(projectRequest.Slug))
			{
				response.IsSuccess = false;
				response.Errors.Add("Všechna políčka jsou povinná!");
				return response;
			}

			bool slugExists = await context.BlogPosts.AnyAsync(bp => bp.Slug == projectRequest.Slug);
			if (slugExists)
			{
				response.IsSuccess = false;
				response.Errors.Add($"Projekt se slugem: '{projectRequest.Slug}' ¨již existuje.");
			}

			bool nameExists = await context.BlogPosts.AnyAsync(bp => bp.Name == projectRequest.Name);
			if (nameExists)
			{
				response.IsSuccess = false;
				response.Errors.Add($"Projekt s tímto názvem: '{projectRequest.Name}' již existuje..");
			}

			if (!response.IsSuccess)
			{
				return response;
			}

			string imagePath = await imageService.UploadImageAsync(projectRequest.File);

			var blogPost = Project.Create(
				projectRequest.Description,
				projectRequest.Content,
				projectRequest.Title,
				projectRequest.Keywords,
				projectRequest.Name,
				imagePath,
				projectRequest.Slug,
				DateTime.Now,
				projectRequest.projectStatus
			);

			context.Projects.Add(blogPost);
			await context.SaveChangesAsync();

			response.IsSuccess = true;
			response.SuccessMessage = "Projekt byl úspěšně přidán.";
			return response;
		}

		/// <summary>
		/// Vrací všechny projekty.
		/// </summary>
		/// <returns></returns>
		public List<Project> GetAllProjects()
		{
			return context.Projects.ToList();
		}

		/// <summary>
		/// Ukládá projekt do databáze.
		/// </summary>
		public void DeleteProjectById(Guid id)
		{
			var project = context.Projects.Find(id);

			if (project == null)
			{
				return;
			}

			context.Projects.Remove(project);
			context.SaveChanges();
		}

		/// <summary>
		/// Vrací projekt podle jeho ID.
		/// </summary>
		public ProjectEditDto GetProjectById(Guid id)
		{
			var project = context.Projects.Find(id);

			if (project == null)
			{
				return null;
			}

			var projectEditDto = new ProjectEditDto
			{
				Id = project.Id,
				Name = project.Name,
				Description = project.Description,
				Keywords = project.Keywords,
				Content = project.Content,
				Slug = project.Slug,
				FileUpload = project.ImagePath,
				ProjectStatus = project.projectStatus,
				Title = project.Title,
			};

			return projectEditDto;
		}

		/// <summary>
		/// Ukládá projekt do databáze.
		/// </summary>
		public async Task<ResponseViewModel> UpdateProject(UpdateProjectRequest request)
		{
			var response = new ResponseViewModel();
			var project = context.Projects.Find(request.Id);

			if (project == null)
			{
				response.IsSuccess = false;
				response.Errors.Add("Blog příspěvek nebyl nalezen.");
				return response;
			}

			if (request.FileUpload != null)
			{
				project.ImagePath = await imageService.UploadImageAsync(request.FileUpload);
			}

			project.Name = request.Name;
			project.Description = request.Description;
			project.Slug = request.Slug;
			project.projectStatus = request.Status;
			project.Content = request.Content;
			project.Date = DateTime.Now;
			project.Title = request.Title;
			project.Keywords = request.Keywords;

			context.Projects.Update(project);
			await context.SaveChangesAsync();

			response.IsSuccess = true;
			response.SuccessMessage = "Blog příspěvek byl úspěšně aktualizován.";
			return response;
		}

		/// <summary>
		/// Vrací projekty podle jejich statusu.
		/// </summary>
		public List<ProjectSummaryDto> GetProjectsByStatusDateSearchString(ProjectStatusEnum? status, string? searchString)
		{
			var query = context.Projects.AsQueryable();

			if (status.HasValue)
			{
				query = query.Where(p => p.projectStatus == status.Value);
			}

			if (!string.IsNullOrEmpty(searchString))
			{
				query = query.Where(p => p.Name.Contains(searchString));
			}

			var projects = query
				.Select(p => new ProjectSummaryDto
				{
					Id = p.Id,
					Name = p.Name,
					Slug = p.Slug,
					Description = p.Description,
					ImagePath = p.ImagePath,
					PublicDate = p.Date,
					ProjectStatus = p.projectStatus
				})
				.ToList();

			return projects;
		}
	}
}