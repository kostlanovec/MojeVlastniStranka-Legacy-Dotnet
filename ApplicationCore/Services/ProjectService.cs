using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.Common.Enums;

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
		/// Vrací projekty podle jejich statusu.
		/// </summary>
		public async Task<List<Project>> GetProjectsByStatus(ProjectStatus status)
		{
			return context.Projects.Where(p => p.projectStatus == status).ToList();
		}
	}
}
