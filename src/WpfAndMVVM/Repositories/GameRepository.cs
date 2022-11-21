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

        public void Add(Game game)
        {
            _dbContext.Add(game);
            _dbContext.SaveChanges();
        }
    }
}
