using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WpfAndMVVM.Infrastructure;
using WpfAndMVVM.Models;

namespace WpfAndMVVM.Repositories
{
    public class GameRepository
    {
        GamingDbContext _dbContext;

        public GameRepository(GamingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Game> Get()
        {
            return _dbContext.Games.ToList();
        }

        public Game Get(int id)
        {
            return _dbContext.Games.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Game game)
        {
            _dbContext.Games.Add(game);
            _dbContext.SaveChanges();
        }

        public void Update(Game game)
        {
            _dbContext.Games.Update(game);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var game = _dbContext.Games.FirstOrDefault(x => x.Id == id);
            _dbContext.Games.Remove(game);
            _dbContext.SaveChanges();
        }
    }
}
