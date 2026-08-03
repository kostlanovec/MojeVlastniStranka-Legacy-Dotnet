using MojeVlastniStranka.ApplicationCore.Interfaces;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace MojeVlastniStranka.ApplicationCore.Services
{
    public class GameIdeaService : IGameIdeaService
    {
        private readonly DataContext _context;
        private readonly IImageService _imageService;

        public GameIdeaService(DataContext context, IImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        public async Task<List<GameIdea>> GetAllAsync()
        {
            return await _context.GameIdeas.AsNoTracking().OrderByDescending(g => g.DateAdded).ToListAsync();
        }

        public async Task<GameIdea?> GetByIdAsync(Guid id)
        {
            return await _context.GameIdeas.FindAsync(id);
        }

        public async Task CreateAsync(GameIdea gameIdea)
        {
            _context.GameIdeas.Add(gameIdea);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GameIdea gameIdea)
        {
            _context.GameIdeas.Update(gameIdea);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var gameIdea = await _context.GameIdeas.FindAsync(id);
            if (gameIdea != null)
            {
                _context.GameIdeas.Remove(gameIdea);
                await _context.SaveChangesAsync();
                await _imageService.DeleteFileAsync(gameIdea.ImageUrl);
            }
        }
    }
}
