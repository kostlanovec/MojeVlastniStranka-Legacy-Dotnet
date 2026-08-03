using MojeVlastniStranka.ApplicationCore.Interfaces;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace MojeVlastniStranka.ApplicationCore.Interfaces
{
    public interface IGameIdeaService
    {
		Task<List<GameIdea>> GetAllAsync();
		Task<GameIdea?> GetByIdAsync(Guid id);
		Task CreateAsync(GameIdea gameIdea);
		Task UpdateAsync(GameIdea gameIdea);
		Task DeleteAsync(Guid id);
    }
}
