using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Game.Web.Data
{
    public class GameService : IGameService
    {
        private readonly DataContext _context;
        private readonly NavigationManager _navigationManager;

        public GameService(DataContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
            _context.Database.EnsureCreated();
        }

        public List<Game> Games { get; set; } = new List<Game>();

        public async Task CreateGame(Game game)
        {
            _context.Game.Add(game);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("videogames");
        }

        public async Task DeleteGame(int id)
        {
            var dbGame = await _context.Game.FindAsync(id);
            if (dbGame == null)
                throw new Exception("No game here. :/");

            _context.Game.Remove(dbGame);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("videogames");
        }

        public async Task<Game> GetSingleGame(int id)
        {
            var game = await _context.Game.FindAsync(id);
            if (game == null)
                throw new Exception("No game here. :/");
            return game;
        }

        public async Task LoadGames()
        {
            Games = await _context.Game.ToListAsync();
        }

        public async Task<List<Game>> SearchGame(string searchText)
        {
            return await _context.Game.Where(p => p.Name.Contains(searchText) || p.Developer.Contains(searchText)).ToListAsync();
        }

        public async Task UpdateGame(Game game, int id)
        {
            var dbGame = await _context.Game.FindAsync(id);
            if (dbGame == null)
                throw new Exception("No game here. :/");

            dbGame.Name = game.Name;
            dbGame.Developer = game.Developer;
            dbGame.Release = game.Release;

            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("videogames");
        }
    }
}
