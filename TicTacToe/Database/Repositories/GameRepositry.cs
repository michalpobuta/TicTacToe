using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Database.Model;

namespace TicTacToe.Database.Repositories
{
    public class GameRepository : IBaseRepository<Game>
    {
        private readonly AppDbContext _dbContext;

        public GameRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteItem(int id)
        {
            var item = _dbContext.Games.FirstOrDefaultAsync(x => x.Id == id);
            if (item!= null)
            {
                _dbContext.Remove(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        public Task<Game> GetItem(int id)
        {
            return _dbContext.Games.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Game>> GetItems()
        {
            return _dbContext.Games.ToListAsync();
        }

        public Task<List<Game>> GetItems(Expression<Func<Game, bool>> predicate)
        {
            return _dbContext.Games.Include(x => x.User).Where(predicate).ToListAsync();
        }

        public async Task<Game> SaveItem(Game item)
        {
            await _dbContext.Games.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task SaveItems(List<Game> items)
        {
            await _dbContext.Games.AddRangeAsync(items);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Game> UpdateItem(Game item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return item;
        }
    }
}
