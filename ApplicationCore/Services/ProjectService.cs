using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.Common.Enums;
using MojeVlastniStranka.ApplicationCore.Dto.Project;
using MojeVlastniStranka.ApplicationCore.Requests;
using Microsoft.AspNetCore.Http;

namespace MojeVlastniStranka.ApplicationCore.Services
{
    public class ProjectService
	{
		private readonly DataContext context;

		public ProjectService(DataContext context)
		{
			this.context = context;
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
				Slug = project.Slug,
				FileUpload = project.ImagePath,
				ProjectStatus = project.projectStatus,
			};

			return projectEditDto;
		}

		/// <summary>
		/// Ukládá projekt do databáze.
		/// </summary>
		public async Task UpdateProject(UpdateProjectRequest request)
		{
			var project = context.Projects.Find(request.Id);

			if (project == null)
			{
				return;
			}

			project.ImagePath = await UploadImageAsync(request.FileUpload);

			project.Name = request.Name;
			project.Description = request.Description;
			project.Slug = request.Slug;
			project.projectStatus = request.Status;

			context.Projects.Update(project);
			await context.SaveChangesAsync();
		}


		/// <summary>
		/// Vrací projekty podle jejich statusu.
		/// </summary>
		public List<ProjectSummaryDto> GetProjectsByStatusDateSearchString(ProjectStatusEnum? status, DateTime? timePublic, string? searchString)
		{
			var query = context.Projects.AsQueryable();

			if (status.HasValue)
			{
				query = query.Where(p => p.projectStatus == status.Value);
			}

			if (timePublic.HasValue)
			{
				query = query.Where(p => p.Date.Date == timePublic.Value.Date);
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

		/// <summary>
		/// Ukládá obrázků do složky images/project.
		/// </summary>)
		private async Task<string> UploadImageAsync(IFormFile file)
		{
			var currentDirectory = Directory.GetCurrentDirectory();

			var uploadsDirectory = currentDirectory + "\\wwwroot\\images\\project";
			var filePath = Path.Combine(uploadsDirectory, file.FileName);

			if (!Directory.Exists(uploadsDirectory))

			{
				Directory.CreateDirectory(uploadsDirectory);
			}

			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}

			return ("/images/project/" + file.FileName);
		}
	}
}
