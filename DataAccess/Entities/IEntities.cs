using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.DataAccess.Entities
{
	public interface IEntities
	{
		[Key]
		public Guid Id { get; set; }

	}
}
