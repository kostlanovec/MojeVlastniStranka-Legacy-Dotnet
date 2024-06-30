using Microsoft.Identity.Client;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.DataAccess.Enums;

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
		public List<Project> GetProjectsAllProjects()
		{
			return context.Projects.ToList();
		}

		/// <summary>
		/// Vrací nebo nastavuje projekty podle jeho statusu.
		/// </summary>
		public async Task< List<Project>> GetProjectsByStatus(ProjectStatus status)
		{
			return context.Projects.Where(p => p.projectStatus == status).ToList();
		}
	}
}
